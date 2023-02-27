using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Caching;
using System.Collections.Generic;
using System.Web;

namespace ADO
{
    public partial class cachingDataSets : System.Web.UI.Page
    {
               
      

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LoadData_Click(object sender, EventArgs e)
        {

            if (Cache["tblemployees"] != null)
            {
                GridView1.DataSource = Cache["tblemployees"];
                GridView1.DataBind();
                Label1.Text = "retrive data from cach at " + DateTime.Now.ToString();
            }
            else
            {
                string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand command = new SqlCommand("select * from tblemployees;select * from videos", conn);
                    conn.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    DataSet ds = new DataSet();

                    List<DataTable> dtList = new List<DataTable>();
                    DataTable t = new DataTable();
                    //we dont need to use nextresult data load function advance it implicilty
                    t.Load(dr);
                    dtList.Add(t);

                    DataTable t2 = new DataTable();
                    t2.Load(dr);
                    dtList.Add(t2);


                    ds.Tables.Add(dtList[0]);
                    ds.Tables.Add(dtList[1]);

                    GridView1.DataSource = ds.Tables[1];
                    GridView1.DataBind();

                    Label1.Text = "retrive data from db at "+ DateTime.Now.ToString();
                    //cach the first table that in ds which is emp table not the one the shows at first (video table)
                    Cache["tblemployees"] = ds;

                    SqlCacheDependencyAdmin.EnableNotifications(cs);
                    SqlCacheDependencyAdmin.EnableTableForNotifications(cs, "tblemployees");

                    SqlCacheDependency sqlCacheDependency = new SqlCacheDependency("firstdb", "tblemployees");

                    CacheItemRemovedCallback cacheItemRemoved = new CacheItemRemovedCallback(cachItemRemoved);
                    CacheItemUpdateCallback cacheItemUpdateCallback = new CacheItemUpdateCallback(cachItemUpdate);
                    Cache.Insert("tblemployees", ds, sqlCacheDependency);
                    Response.Write(HttpRuntime.Cache["tblemployees"]);
                }
            }
        }

        protected void ClearCach_Click(object sender, EventArgs e)
        {
            if (Cache["tblemployees"] != null)
                Cache.Remove("tblemployees");
        }
        private void cachItemRemoved(string key, object value, CacheItemRemovedReason reason)
        {
        }
        private void cachItemUpdate(string key, CacheItemUpdateReason reason, out object expensiveObject, out CacheDependency dependency, out DateTime absoluteExpiration, out TimeSpan slidingExpiration)
        {
            expensiveObject = 1;
            dependency = null;
            absoluteExpiration  =Cache.NoAbsoluteExpiration;
            slidingExpiration = Cache.NoSlidingExpiration;

        }

    }
}