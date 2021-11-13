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
namespace WebFormFirst
{
    public partial class Cache_dependency_on_sql_server_database_table : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using (SqlConnection conn= new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from videos", conn);
               
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();

                Cache.Insert("videos", ds, null, DateTime.Now.AddSeconds(20), Cache.NoSlidingExpiration,
                    CacheItemPriority.Default, null);
                Label1.Text = "data retrived from db at " + DateTime.Now.ToString();
            }
        }
    }
}