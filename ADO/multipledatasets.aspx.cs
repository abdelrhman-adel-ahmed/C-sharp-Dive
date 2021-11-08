using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ADO
{
    public partial class multipledatasets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("spgetempandvideos", cs);
                da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                //you can acces the tables inside the data set using the index , or using the name 
                //by diffult the name os table then table1 ... ,
                //you can give each table a name using tablename property
                ds.Tables[0].TableName = "Employeetbl";
                ds.Tables[1].TableName = "videostbl";

                GridView1.DataSource = ds.Tables["Employeetbl"];
                GridView1.DataBind();
                GridView2.DataSource = ds.Tables["videostbl"]; ;
                GridView2.DataBind();
            }

        }
    }
}