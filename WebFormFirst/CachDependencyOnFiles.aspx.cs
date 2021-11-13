using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Caching;

namespace WebFormFirst
{
    public partial class CachDependencyOnFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Cache["Countries"]!=null)
            {
                DataSet ds = (DataSet)Cache["Countries"];
                GridView1.DataSource = ds;
                GridView1.DataBind();
                Label1.Text = ds.Tables[0].Rows.Count.ToString() + " rows retrieved from cach";
            }
            else
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/App_Data/countries.xml"));
                //here ther is no dependecy so if we change in the xml and the countries is not expried yet 
                //it will view normal version without the changes 
                //Cache.Insert("Countries", ds, null, DateTime.Now.AddSeconds(20), Cache.NoSlidingExpiration);
               
                //when the file change it will no longer read from the cach it delete it acutomaticlly
                //even if the expiration time not come it will go and read from the date source
                Cache.Insert("Countries", ds, new CacheDependency(Server.MapPath("~/App_Data/countries.xml")), DateTime.Now.AddSeconds(20), Cache.NoSlidingExpiration);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                Label1.Text = ds.Tables[0].Rows.Count.ToString() + " rows retrieved from xml file";

            }

        }
    }
}