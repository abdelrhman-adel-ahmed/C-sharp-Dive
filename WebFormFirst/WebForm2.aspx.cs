using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormFirst
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Text = "0";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //since we send the value of the textbox when we post we can access that value
            //so server controls internally uses view state to pass the data around
            Response.Write(sender + "<br/>");
            int count = Convert.ToInt32(TextBox1.Text) + 1;
            TextBox1.Text = count.ToString();
        }
    }
}