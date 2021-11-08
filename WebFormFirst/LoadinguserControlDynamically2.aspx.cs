using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormFirst
{
    public partial class LoadinguserControlDynamically2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedValue =="DDL")
            {
                //create dropdownlist control and then 
                DropDownList DDL1 = new DropDownList();
                DDL1.ID = "DDL1";
                DDL1.Items.Add("cairo");
                DDL1.Items.Add("minia");
                DDL1.Items.Add("zrbo");
                DDL1.Items.Add("elno");
                PlaceHolder1.Controls.Add(DDL1);
            }
        }
    }
}