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
    public partial class disconnected_data_access : System.Web.UI.Page
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
            if(Cache["dataset"]!=null)
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

                Cache.Insert("dataset", ds,null,Cache.NoAbsoluteExpiration,Cache.NoSlidingExpiration);

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

        protected void gvStudents_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            DataSet ds = (DataSet) Cache["dataset"];
            //thats why we let the data set know that the id colume as primary key in the dataset 
            //because find method take 
            DataRow row = ds.Tables["student"].Rows.Find(e.Keys["ID"]);
            row["Name"] = e.NewValues["Name"];
            row["Gender"] = e.NewValues["Gender"];
            row["Totalmarks"] = e.NewValues["Totalmarks"];
            //overwrite the cach, instead we can create sql dependecy
            Cache.Insert("dataset", ds, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration);

            gvStudents.EditIndex = -1;

        }
    }
}