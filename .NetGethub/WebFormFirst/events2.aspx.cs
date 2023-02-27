using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormFirst
{
    public partial class events2 : System.Web.UI.Page
    {
        //how this static instance live accross all request repsonse cycle despite in each cycle we create new object!!
        static List<int> x = new List<int>();
        int t=1;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("load first" + "<br/>");
           
        }
        protected void p(object sender, EventArgs e)
        {
            Response.Write("load first" + "<br/>");

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Response.Write("TextBox1_TextChanged" + "<br/>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Write(TextBox1.Text + "<br/>");
            int i = 0;
            //foreach (var item in Request.Params)
            //{
            //    Response.Write(item + ":" + Request.Params[i] + "<br/>");
            //    i++;
            //}

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Response.Write("TextBox2_TextChanged" + "<br/>");

        }
    }
}