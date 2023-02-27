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
    public partial class Reloading_or_refreshing_cache_automatically_when_cached_data_is_removed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_InitCach(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/App_Data/countries.xml"));
            CacheItemRemovedCallback OnCacheItemRemovedCallback = new CacheItemRemovedCallback(Countires_Removed);
            Cache.Insert("countries", ds, new CacheDependency(Server.MapPath("~/App_Data/countries.xml")), DateTime.Now.AddSeconds(20)
                , Cache.NoSlidingExpiration, CacheItemPriority.Default, OnCacheItemRemovedCallback);

            GridView1.DataSource = ds;
            GridView1.DataBind();
            Label1.Text = ds.Tables[0].Rows.Count.ToString() + " rows retreived from xml";
        }

        protected void btn_LoadFromCach(object sender, EventArgs e)
        {
            if(Cache["countries"] !=null)
            {
                DataSet ds = (DataSet)Cache["countries"];
                GridView1.DataSource = ds;
                GridView1.DataBind();
                Label1.Text = ds.Tables[0].Rows.Count.ToString() + " rows retreived from Cach";
            }
            else
            {
                Label1.Text ="cach item with key countries is not present in the cach";
            }
        }

        private void Countires_Removed(string key, object value, CacheItemRemovedReason reason)
        {
            string data = $"cach item {key} is no longer in the cach resason {reason.ToString()}";
            Cache["countriesStatus"] = data;
        }

        protected void btn_removeCach(object sender, EventArgs e)
        {
            Cache.Remove("countries");
        }

        protected void btn_GetCachStatus(object sender, EventArgs e)
        {
            if(Cache["countries"] !=null)
            {
                Label1.Text = "cach item with key countires is still in the cach";
            }
            else if (Cache["countriesStatus"]!=null)
            {
                Label1.Text = Cache["countriesStatus"].ToString();
            }
            else
            {
                Label1.Text = "the countries is never cached";
            }
        }
    }
}