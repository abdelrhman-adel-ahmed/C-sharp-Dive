using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WebFormFirst
{
    public partial class CachingMultipleResponsesForSingleWebform : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("Page_PreInit" + "<br/>");
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("Page_Init" + "<br/>");

        }
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            Response.Write("Page_InitComplete" + "<br/>");

        }
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Response.Write("Page_PreLoad" + "<br/>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if(!IsPostBack)
            {
                GetVideoByTitle("All");
            }
            Label1.Text = DateTime.Now.ToString();
        }
        private void GetVideoByTitle(string title)
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand("spGetVideosByTitle", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", title);

                SqlDataAdapter da = new SqlDataAdapter(command);

                DataSet ds = new DataSet();
                da.Fill(ds);

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
      
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetVideoByTitle(DropDownList1.SelectedValue);
        }
    }
}