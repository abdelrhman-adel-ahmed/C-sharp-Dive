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
            //Response.Cache.GetType().GetMethods().ToList().ForEach(x => Response.Write(x.Name + "<br/>"));


            //<%@ OutputCache Duration="30" VaryByParam="DropDownList1" Location="Server"%>
            //OutputCache but using the Cache proprties and methods 
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(30));
            Response.Cache.VaryByParams["none"] = true;
            Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
            //we had to add this to make the code work
            Response.Cache.SetValidUntilExpires(true);

            Label1.Text = DateTime.Now.ToString();



        }
    }
}