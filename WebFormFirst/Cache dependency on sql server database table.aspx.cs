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
using System.Data.OracleClient;

namespace WebFormFirst
{
    public partial class Cache_dependency_on_sql_server_database_table : System.Web.UI.Page
    {
        /*
         * we establish the cache dependecy with the file (xml) by giving the cachedependency object the path to the 
         * file , now we want to do the same using the database , when we update the table in the database ,we want 
         * the cache to get deleted ,because the table is updated and the cache is not up to date ,and if we want 
         * we can then add the new updated table back to the db.
         */
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          
            if (Cache["videos"] != null)
            {

                GridView1.DataSource = Cache["videos"];
                GridView1.DataBind();
                Label1.Text = "data retrived from cache at " + DateTime.Now.ToString();
            }
            else
            {
                string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from videos", conn);

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    SqlCacheDependencyAdmin.EnableNotifications(cs);
                    SqlCacheDependencyAdmin.EnableTableForNotifications(cs, "videos");
                    SqlCacheDependency sqlCacheDependency = new SqlCacheDependency("firstdb", "videos");
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                    Cache.Insert("videos", ds, sqlCacheDependency, DateTime.Now.AddSeconds(20), Cache.NoSlidingExpiration,
                        CacheItemPriority.Default, null);
                    Label1.Text = "data retrived from db at " + DateTime.Now.ToString();
                }
            }
        }
    }
}