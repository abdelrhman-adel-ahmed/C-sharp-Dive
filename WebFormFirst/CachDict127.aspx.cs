using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web.Caching;

namespace WebFormFirst
{
    public partial class CachDict127 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected DataSet GetVideos()
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using(SqlConnection conn = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from videos",conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime Start = DateTime.Now;
            StringBuilder message = new StringBuilder();
            if(Cache["videos"] != null)
            {
                DataSet ds = (DataSet)Cache["videos"];
                GridView1.DataSource = ds;
                GridView1.DataBind();
                message.Append(ds.Tables[0].Rows.Count + " Row retrievred from Cach ");
            }
            else
            {
                DataSet ds = GetVideos();
                // Cache["videos"] = ds;
                //we can use add or insert function that provide extra capabilities
                // Cache.Insert("videos", ds);

                CacheItemRemovedCallback onremove = videosGetremoved;
                Cache.Add("videos", ds,null,Cache.NoAbsoluteExpiration,Cache.NoSlidingExpiration,CacheItemPriority.Normal, onremove);

                GridView1.DataSource = ds;
                GridView1.DataBind();
                message.Append(ds.Tables[0].Rows.Count + " Row retrievred from database ");
            }
            DateTime End = DateTime.Now;
            double totalsecond = (End - Start).TotalSeconds;
            message.Append(totalsecond + " Seconds to load");
            Label1.Text = message.ToString();
        }

        private void videosGetremoved(string key, object value, CacheItemRemovedReason reason)
        {
            Response.Write("dsda");
            Response.Write(key.ToString());
            Label1.Text = key;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Cache.Remove("videos");
        }
    }
}