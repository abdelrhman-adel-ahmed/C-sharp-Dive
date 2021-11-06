using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace ADO
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = ConfigurationManager.ConnectionStrings["Cs"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("select top 5 customerid,companyname,contactname,contacttitle from customers", conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }
        }
    }
}