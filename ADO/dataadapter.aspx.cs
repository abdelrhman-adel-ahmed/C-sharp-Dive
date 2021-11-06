using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ADO
{
    public partial class dataadapter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //diff between datareader and dataadapter ,the first is connection orinted ,the later provide 
            //disconncte data acess model
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from tblemployees", cs);
                DataSet ds = new DataSet();
                da.Fill(ds);
                
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                //data adapter can deal with stored procedures 
                SqlDataAdapter da = new SqlDataAdapter("spAddEmployee", cs);
                //select command return sqlcommand so from here on its like you deal with data reader
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Name", txtEmployeeName.Text);
                da.SelectCommand.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                da.SelectCommand.Parameters.AddWithValue("@Salary", txtSalary.Text);

                SqlParameter outParameter = new SqlParameter
                {
                    ParameterName = "@EmployeeId",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                da.SelectCommand.Parameters.Add(outParameter);
                DataSet ds = new DataSet();
                da.Fill(ds);

                string EmpId = outParameter.Value.ToString();
                lblMessage.Text = $"Employee ID = {EmpId}";
                
            }
        }
    }
}