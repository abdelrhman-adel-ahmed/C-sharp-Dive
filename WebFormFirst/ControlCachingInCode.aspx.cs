using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebFormFirst
{
    public partial class ControlCachingInCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get all properties of the response object
            // Response.GetType().GetProperties().ToList().ForEach(x=>Response.Write(x.Name +"<br/>"));

            //get all properties of the Cache object
            //Response.Cache.GetType().GetProperties().ToList().ForEach(x => Response.Write(x.Name + "<br/>"));

            //get all methods of the Cache object
            Response.Cache.GetType().GetMethods().ToList().ForEach(x => Response.Write(x.Name + "<br/>"));

            //<%@ OutputCache Duration="30" VaryByParam="DropDownList1" Location="Server"%>
            //OutputCache but using the Cache proprties and methods 
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(30));
            Response.Cache.VaryByParams["None"] = true;
            Response.Cache.SetCacheability(HttpCacheability.Server);

            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from videos", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
    }
}