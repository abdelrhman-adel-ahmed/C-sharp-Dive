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
    public partial class datareaderNextResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand("select * from videos;select * from tblemployees", conn);
                conn.Open();
                SqlDataReader dr = command.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();

                // here we read a batch of two dataset the nextresult will advance the datareader to the next dataset
                while(dr.NextResult())
                {
                    GridView2.DataSource = dr;
                    GridView2.DataBind();
                }
             
            }
        }
    }
}