using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO.ADO.NET_by_Example
{
    public partial class disconnectedModel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("select * from employees", conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds,"employees");
           //ds.Tables["employees"].Constraints.Add("Empno_pk", ds.Tables["employees"].Columns["Id"], true);
            DataRow row = ds.Tables["employees"].NewRow();
            row["Name"] = TextBox1.Text;
            row["Gender"] = TextBox2.Text;
            row["Departmentid"] = TextBox3.Text;
            da.Update(ds, "employees");


        }
    }
}