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
    public partial class datareader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand("select * from employees", conn);
                conn.Open();
                SqlDataReader dr = command.ExecuteReader();
                Response.Write(dr);
            }
        }
    }
}