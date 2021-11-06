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
    public partial class sqlinjection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using(SqlConnection conn = new SqlConnection(cs))
            {
                string commnad = "select * from videos where title like '" +TextBox1.Text+"%'";
                SqlCommand cmd1 = new SqlCommand(commnad, conn);
                conn.Open();
                
                GridView1.DataSource = cmd1.ExecuteReader();
                GridView1.DataBind();
            }

        }
    }
}