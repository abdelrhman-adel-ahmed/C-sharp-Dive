using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ADO
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //adding Connection Timeout solve the timeout problem
            SqlConnection conn = new SqlConnection("Data Source=.;Integrated Security = SSPI; Initial Catalog = Northwind;Connection Timeout=30;");
            try
            {
                SqlCommand cmd = new SqlCommand("select top 5 customerid,companyname,contactname,contacttitle from customers", conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }
            catch 
            {

                throw;
            }
            finally
            {
                //if any exception occur , then we have to make sure that the connection closed 
                conn.Close();

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}