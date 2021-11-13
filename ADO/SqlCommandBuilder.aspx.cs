using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO
{
    public partial class SqlCommandBuilder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            string query = "select * from tblstudents where id =" + TextBox1.Text;
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "student");

            ViewState["sql_query"] = query;

            if (ds.Tables["student"].Rows.Count > 0)
            {
                //we only retrive one tuple from the query 
                DataRow dr = ds.Tables["student"].Rows[0];
                TextBox3.Text = dr["Name"].ToString();
                DropDownList1.SelectedValue = dr["Gender"].ToString();
                TextBox6.Text = dr["totalmarks"].ToString();

            }
            else
            {
                Label1.Text = "no student with that id";
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {


        }
    }
}