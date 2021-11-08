using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormFirst
{
    public partial class LoadinguserControlDynamically : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            calenderControl calendercontrol = (calenderControl) LoadControl("~/usercontrols/calenderControl.ascx");
            calendercontrol.ID = "cc1";
            //we need to add placeholder to make the page placed inside the form not outside the form
            // Panel1.Controls.Add(LoadControl("~/usercontrols/calenderControl.ascx"));
            Panel1.Controls.Add(calendercontrol);


        }
    }
}