using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Caching;

namespace ADO
{
    public partial class acceptAndRejectChanges : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetDataFromDb_Click(object sender, EventArgs e)
        {
            GetData();

        }
        private void GetData()
        {
            if (Cache["dataset"] != null)
            {
                GetDataFromCach();
            }
            else
            {
                GetDataFromDb();
            }
        }
        private void GetDataFromDb()
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string SelectQuery = "select * from tblStudents";
                SqlDataAdapter da = new SqlDataAdapter(SelectQuery, conn);

                DataSet ds = new DataSet();
                da.Fill(ds, "student");

                ds.Tables["student"].PrimaryKey = new DataColumn[]
                                            {ds.Tables["student"].Columns["ID"]};
                SqlCacheDependencyAdmin.EnableNotifications(cs);
                SqlCacheDependencyAdmin.EnableTableForNotifications(cs, "tblStudents");

                SqlCacheDependency sqlCacheDependency = new SqlCacheDependency("firstdb", "tblStudents");

                Cache.Insert("dataset", ds, sqlCacheDependency, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration);

                gvStudents.DataSource = ds;
                gvStudents.DataBind();



                lblStatus.Text = "data loaded from db";

            }
        }
        private void GetDataFromCach()
        {
            gvStudents.DataSource = Cache["dataset"];
            gvStudents.DataBind();
            lblStatus.Text = "data loaded from cach";

        }

        protected void gvStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStudents.EditIndex = e.NewEditIndex;
            Response.Write(gvStudents.EditIndex + "</br>");
            GetDataFromCach();
        }

        protected void gvStudents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStudents.EditIndex = -1;
            GetDataFromCach();
        }

        protected void gvStudents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataSet ds = (DataSet)Cache["dataset"];
            //thats why we let the data set know that the id colume as primary key in the dataset 
            //because find method take 
            DataRow row = ds.Tables["student"].Rows.Find(e.Keys["ID"]);
            row["Name"] = e.NewValues["Name"];
            row["Gender"] = e.NewValues["Gender"];
            row["TotalMarks"] = e.NewValues["TotalMarks"];
            //overwrite the cach, instead we can create sql dependecy
            //Cache.Insert("dataset", ds, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration);

            gvStudents.EditIndex = -1;

            GetDataFromCach();
        }

        protected void btnUpdateTable_Click(object sender, EventArgs e)
        {
            //UpdateUsingSqlCommmandBuilder();
            UpdateUsingSqlCommand();
        }
        private void UpdateUsingSqlCommmandBuilder()
        {
            if (Cache["dataset"] != null)
            {
                string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from tblStudents", conn);
                    SqlCommandBuilder builder = new SqlCommandBuilder(da);
                    DataSet ds = (DataSet)Cache["dataset"];

                    //we will use sqlcommand instead of sqlcommnadbuilder
                    da.Update(ds, "student");
                    Cache.Insert("dataset", ds, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration);
                    Response.Write(builder.GetUpdateCommand().CommandText + "</br>");
                    lblStatus.Text = "table get updated in db";
                }
            }
        }
        private void UpdateUsingSqlCommand()
        {
            if (Cache["dataset"] != null)
            {
                string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from tblStudents", conn);
                    DataSet ds = (DataSet)Cache["dataset"];

                    string updateQuery = "update tblStudents set Name=@Name , Gender = @Gender,TotalMarks=@TotalMarks " +
                        "where Id = @Id";

                    SqlCommand UpdateCommmand = new SqlCommand(updateQuery, conn);

                    Mapping(ref UpdateCommmand);


                    //associate the dataadapter updatecommand with the update command we created 
                    da.UpdateCommand = UpdateCommmand;



                    //---------------------we assoicate two commands delete and update
                    //the associated command will get executed depend on the change happen in the dataset--------
                    string deletequery = "delete from tblStudents where Id =@Id";

                    SqlCommand deletecommand = new SqlCommand(deletequery, conn);

                    deletecommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");


                    da.DeleteCommand = deletecommand;

                    da.Update(ds, "student");

                    lblStatus.Text = "table get updated in db";
                }
            }
        }

        private void Mapping(ref SqlCommand sqlcommand)
        {

            sqlcommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            sqlcommand.Parameters.Add("@Gender", SqlDbType.NVarChar, 20, "Gender");
            sqlcommand.Parameters.Add("@TotalMarks", SqlDbType.Int, 0, "TotalMarks");
            sqlcommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
        }

        protected void gvStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = (DataSet)Cache["dataset"];
            DataRow row = ds.Tables["student"].Rows.Find(e.Keys["ID"]);

            row.Delete();
            GetDataFromCach();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["dataset"];

            DataRow newrow = ds.Tables["student"].NewRow();
            newrow["ID"] = 100;
            Response.Write(newrow.RowState+"</br>");

            foreach (DataRow row in ds.Tables["student"].Rows)
            {
                //if row is deleted we cannot access it 
                if (row.RowState == DataRowState.Deleted)
                {
                    Response.Write(row["ID",DataRowVersion.Original].ToString() + " - " + row.RowState + "</br>");
                }
                else
                    Response.Write(row["ID"].ToString() + " - " + row.RowState + "</br>");
            }
        }
    }


}