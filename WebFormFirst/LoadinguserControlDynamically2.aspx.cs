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
            //problem with this approach that we save unnecessary data in the viewstate so we have additional 
            //bytes get saved in the view state ,if you open the trace you wil see the droplist and the text
            //box is saved beacuse we create them but we set the visiabliry to false ,also we have anothe problem
            //which is we have to do all this work despite we will not use all of those controls 
            //how we can solve that ?!!

            //create dropdownlist control and then 
            DropDownList DDL1 = new DropDownList();
            DDL1.AutoPostBack = true;
            DDL1.ID = "DDL1";
            DDL1.Items.Add("cairo");
            DDL1.Items.Add("minia");
            DDL1.Items.Add("zrbo");
            DDL1.Items.Add("elno");
            TextBox text2 = new TextBox();
            PlaceHolder1.Controls.Add(DDL1);
            PlaceHolder1.Controls.Add(text2);
            text2.Visible = false;
            DDL1.Visible = false;


            TextBox text1 = new TextBox();
            text1.Text = DropDownList1.SelectedValue;
            Panel1.Controls.Add(text1);
            PlaceHolder2.Controls.Add(text1);
            text1.Visible = true;

            if (DropDownList1.SelectedValue == "DDL")
            {
                text2.Text= DDL1.SelectedValue;
                text2.Visible = true;
                DDL1.Visible = true;

            }
            else if (DropDownList1.SelectedValue == "TB")
            {
                text1.Visible = true;
            }
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
                TextBox t =PlaceHolder2.FindControl("text1") as TextBox;
                Response.Write(t.Text);
            }
        }
    }
    }