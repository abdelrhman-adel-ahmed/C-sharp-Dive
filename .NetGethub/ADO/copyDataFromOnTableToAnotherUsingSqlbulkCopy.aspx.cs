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
            string SourceCs = ConfigurationManager.ConnectionStrings["sourcedb"].ConnectionString;
            string DestinationCs = ConfigurationManager.ConnectionStrings["destinationdb"].ConnectionString;
            using (SqlConnection SourceConnection = new SqlConnection(SourceCs))
            {
                SqlCommand command = new SqlCommand("select * from Employees",SourceConnection);
                SourceConnection.Open();

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    using (SqlConnection DestinationConnection = new SqlConnection(DestinationCs))
                    {
                        using (SqlBulkCopy bc = new SqlBulkCopy(DestinationConnection))
                        {
                            bc.DestinationTableName = "Employees";
                            DestinationConnection.Open();
                            bc.WriteToServer(dr);
                        }   
                    }
                }
                command = new SqlCommand("select * from Departments", SourceConnection);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    using (SqlConnection DestinationConnection = new SqlConnection(DestinationCs))
                    {
                        using (SqlBulkCopy bc = new SqlBulkCopy(DestinationConnection))
                        {
                            bc.DestinationTableName = "Departments";
                            DestinationConnection.Open();
                            bc.WriteToServer(dr);
                        }
                    }
                }

            }


        }
    }
}