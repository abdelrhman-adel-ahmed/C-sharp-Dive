﻿using System;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.SessionState;

namespace WebFormFirst
{
    public partial class Caching : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void LoadData_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from tblemployees", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                Label1.Text = DateTime.Now.ToString();
            }
        }


        protected void ClearCach_Click(object sender, EventArgs e)
        {
            Response.Write("ahmed");
        }
    }
}