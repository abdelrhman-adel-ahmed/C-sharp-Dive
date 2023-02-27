using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormFirst
{
    public partial class sessionstate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["counter"]==null)
                {
                    Session["counter"] = 0;
                }
                TextBox1.Text = Session["counter"].ToString();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int clickcount = (int)Session["counter"] + 1;
            TextBox1.Text = clickcount.ToString();
            Session["counter"]=clickcount;
            
        }
    }
}