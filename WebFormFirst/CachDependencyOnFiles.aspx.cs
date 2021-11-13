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
                Label1.Text = ds.Tables[0].Rows.Count.ToString() + " retrieved from cach";
            }
            else
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/App_Data/countries.xml"));
                Cache.Insert("Countries", ds, null, DateTime.Now.AddSeconds(20), Cache.NoSlidingExpiration);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                Label1.Text = ds.Tables[0].Rows.Count.ToString() + " retrieved from db";

            }

        }
    }
}