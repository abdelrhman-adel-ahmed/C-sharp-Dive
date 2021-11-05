using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormFirst
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int counter=1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //TextBox1.Text = "0";
            if(Context.Request.HttpMethod != "POST")
                TextBox1.Text = "0";
            Response.Write("total application " + Application["totalapplications"]);
            Response.Write("<br/>");
            Response.Write("total sessions " + Application["totalusersession"]);
            Response.Write("<br/>");
            typeof(WebForm1).Assembly.GetTypes().ToList().ForEach(t=>Response.Write(t+ "<br/>"));


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*each time we will click the button and object of WebForm1 ,button,textbox
             * will get created ,so for each request response cycle we have new instances
             * and then get destroyed ,because we deal with statless protocol (http)
             * but the text will not be zero because its post request and we zero the 
             * text if it get request, but the value will remain 1 always because the 
             * counter get intialize to zero each time
            */
           
            if (ViewState["clicks"] !=null)
            {
                counter =(int)ViewState["clicks"] + 1;

            }
            TextBox1.Text = counter.ToString();
            ViewState["clicks"] = counter;
            //counter = counter + 1;
            //TextBox1.Text = counter.ToString();
        }

     
    }
}