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
    public partial class loadXmlDataIntoSqlTableUsingSqlbulkcopy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/App_Data/employee.xml"));
                //the ds cotain two tables now Department and Employee ,the names comes from the schema of the xml
                DataTable DtDept= ds.Tables["Department"];
                DataTable DtEmp = ds.Tables["Employee"];

                //we created two tables in the db Employees,Departmentss
                conn.Open();
                using (SqlBulkCopy bc= new SqlBulkCopy(conn))
                {
                    //first we need to specife the table name 
                    //then we need to specife the sourceColumns Names and the destination columns Names
                    bc.DestinationTableName = "Departmentss";
                    bc.ColumnMappings.Add("ID", "ID");
                    bc.ColumnMappings.Add("Name", "Name");
                    bc.ColumnMappings.Add("Location", "Location");
                    bc.WriteToServer(DtDept);

                }
                using (SqlBulkCopy bc = new SqlBulkCopy(conn))
                {
              
                    bc.DestinationTableName = "Employees";
                    bc.ColumnMappings.Add("ID", "ID");
                    bc.ColumnMappings.Add("Name", "Name");
                    bc.ColumnMappings.Add("Gender", "Gender");
                    bc.ColumnMappings.Add("DepartmentId", "DepartmentId");
                    bc.WriteToServer(DtEmp);

                }
            }
        }
    }
}