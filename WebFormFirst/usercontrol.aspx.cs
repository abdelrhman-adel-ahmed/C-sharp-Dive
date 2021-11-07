using System;

namespace WebFormFirst
{
    public partial class usercontrol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }
        
        protected void Button1_Click1(object sender, EventArgs e)
        {
            //if we want to access somthing in the calenderControl we can make properites  
            Response.Write(calenderControl.SelectedDate);

        }
    }
}