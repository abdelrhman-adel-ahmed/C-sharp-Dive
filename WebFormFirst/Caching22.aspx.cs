using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormFirst
{
    public partial class Caching22 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Cache["exm"] != null)
            {
                Shit shit = (Shit)Cache["exm"];
                Label1.Text = shit.name;
            }
            else
            {
                Label1.Text = "nothing in the cach";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cache["exm"] = new Shit { name = "ahhmed" };
            
        }
       
    }

    public class Shit
    {
        public string name { get; set; }
    }
}