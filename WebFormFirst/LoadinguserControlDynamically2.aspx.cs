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
        TextBox textPlaceHolder1 = new TextBox();
        TextBox textPlaceHolder2 = new TextBox();
        DropDownList DDL1 = new DropDownList();

        protected void Page_Load(object sender, EventArgs e)
        {
            //problem with this approach that we save unnecessary data in the viewstate so we have additional 
            //bytes get saved in the view state ,if you open the trace you wil see the droplist and the text
            //box is saved beacuse we create them but we set the visiabliry to false ,also we have anothe problem
            //which is we have to do all this work despite we will not use all of those controls 
            //how we can solve that ?!!

            //create dropdownlist control and then 
            DDL1.AutoPostBack = true;
            DDL1.ID = "DDL1";
            DDL1.Items.Add("cairo");
            DDL1.Items.Add("minia");
            DDL1.Items.Add("zrbo");
            DDL1.Items.Add("elno");

            DDL1.SelectedIndexChanged += DDL1_SelectedIndexChanged;
            PlaceHolder1.Controls.Add(DDL1);
            //the error of returning null when we try to find the textbox controler inside the the placeholder
            //because we find usign the id and we wasnot set the id property to anything !! :)
            textPlaceHolder1.ID = "textbox1";
            PlaceHolder1.Controls.Add(textPlaceHolder1);
            textPlaceHolder1.Visible = false;
            DDL1.Visible = false;


            textPlaceHolder2.Text = DropDownList1.SelectedValue;
            textPlaceHolder2.ID = "textbox2";
            PlaceHolder2.Controls.Add(textPlaceHolder2);
            textPlaceHolder2.Visible = false;

            if (DropDownList1.SelectedValue == "DDL")
            {
                textPlaceHolder1.Text= DDL1.SelectedValue;
                textPlaceHolder1.Visible = true;
                DDL1.Visible = true;

            }
            else if (DropDownList1.SelectedValue == "TB")
            {
                textPlaceHolder2.Visible = true;
            }
        }

        private void DDL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textPlaceHolder1.Text = DDL1.SelectedValue;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
            {
                //problem if we put the code here that any other post back the custom controls will not be 
                //rendered beause it only render when the select changed event happen
            }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedValue=="DDL")
            {
                DropDownList d =(DropDownList) PlaceHolder1.FindControl("DDL1");
                Response.Write(d.SelectedValue);
            }
            else if(DropDownList1.SelectedValue == "TB")
            {
                TextBox t =(TextBox)PlaceHolder2.FindControl("textbox2");
                
                Response.Write(t.Text);
            }
        }
    }
    }