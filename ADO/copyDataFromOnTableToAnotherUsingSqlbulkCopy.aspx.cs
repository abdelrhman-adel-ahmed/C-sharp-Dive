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
    public partial class copyDataFromOnTableToAnotherUsingSqlbulkCopy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string SoruceCs = ConfigurationManager.ConnectionStrings["sourcedb"].ConnectionString;
            string DestinationCs = ConfigurationManager.ConnectionStrings["destinationdb"].ConnectionString;

            using (SqlConnection SourceConnection = new SqlConnection(SoruceCs))
            {

                SqlCommand command = new SqlCommand("select * from departments", SourceConnection);
                SourceConnection.Open();
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    using (SqlConnection DestinationConn = new SqlConnection(DestinationCs))
                    {

                        using (SqlBulkCopy bc = new SqlBulkCopy(DestinationConn))
                        {

                            bc.DestinationTableName = "Departments";
                            DestinationConn.Open();
                            //scince the column names in the source and destination is the same so we dont need to map them
                            bc.WriteToServer(dr);

                        }
                    }
                }
                command = new SqlCommand("select * from Employees", SourceConnection);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    using (SqlConnection DestinationConn = new SqlConnection(DestinationCs))
                    {

                        using (SqlBulkCopy bc = new SqlBulkCopy(DestinationConn))
                        {

                            bc.DestinationTableName = "Employees";
                            DestinationConn.Open();
                            bc.WriteToServer(dr);
                        }
                    }
                }
            }
        }
    }
}