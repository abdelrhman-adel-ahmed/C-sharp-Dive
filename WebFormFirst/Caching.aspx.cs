using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebFormFirst
{
    public partial class Caching : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand("spgetempandvideos", conn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataTable table in ds.Tables)
                {
                    var coloume_names = table.Columns;
                    int i =0;
                    foreach (DataRow row in table.Rows)
                    {
                        var data = row.ItemArray;
                        foreach (var item in data)
                        {
                            Response.Write(item + " ");
                        }
                        Response.Write("<br/>");
                    }
                }

            }
        }
    }
}