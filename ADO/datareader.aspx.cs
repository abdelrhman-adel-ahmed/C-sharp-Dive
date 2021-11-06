using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace ADO
{
    public partial class datareader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand("select * from tblemployees", conn);
                conn.Open();
                SqlDataReader dr = command.ExecuteReader();
                
                DataTable table = new DataTable();
                table.Columns.Add("employeeid");
                table.Columns.Add("name");
                table.Columns.Add("gender");
                table.Columns.Add("salary");
                while (dr.Read())
                {
                    DataRow row = table.NewRow();
                    row["employeeid"] = dr["employeeid"];
                    row["name"] = dr["name"];
                    row["gender"] = dr["gender"];
                    row["salary"] = dr["salary"];
                    Response.Write(row["name"].ToString()+ "<br/>");
                    //as we said datareader is forward only and once we consume the row we cannot get it again 
                    //so we store each row in the table object
                    table.Rows.Add(row);
                }
                GridView1.DataSource = table;
                GridView1.DataBind();
                
            }
        }
    }
}