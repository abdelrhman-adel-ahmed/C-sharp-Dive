using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO
{
    public partial class storedProcedure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                //procedure name
                cmd.CommandText = "spAddEmployee";
                //by defult command type is text but if we want stroedprocedure we have to explicitly ask for it
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", txtEmployeeName.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);

                //empid output paramater that the procedure will reutrn 
                SqlParameter outParameter = new SqlParameter();
                outParameter.ParameterName = "@EmployeeId";
                outParameter.SqlDbType = System.Data.SqlDbType.Int;
                outParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outParameter);

                conn.Open();
                cmd.ExecuteNonQuery();

                string EmpId = outParameter.Value.ToString();
                lblMessage.Text = $"Employee ID = {EmpId}";

            }
        }
    }
}