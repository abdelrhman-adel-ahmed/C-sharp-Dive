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
            string s = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(s))
            {
                SqlCommand cmd1 = new SqlCommand("delete from videos where title='second title'", conn);
                SqlCommand cmd2 = new SqlCommand("insert into Videos values('second title','despcrtion1',6)", conn);
                SqlCommand cmd3 = new SqlCommand("select count(id) from Videos", conn);

                conn.Open();
                //ExecuteNonQuery when we doesnt return any rows , update delelte insert
                int num_of_row_deleted = cmd1.ExecuteNonQuery();
                int num_of_row_effected = cmd2.ExecuteNonQuery();
                //scalar when we return single value (return type is object)
                int num_of_row_in_video_table =(int) cmd3.ExecuteScalar();
                Response.Write("total row inserted " + num_of_row_effected.ToString() + "<br/>");
                Response.Write("total row deleted " + num_of_row_deleted.ToString() + "<br/>");
                Response.Write("total row in video table " + num_of_row_in_video_table.ToString() + "<br/>");



            }
        }
    }
}