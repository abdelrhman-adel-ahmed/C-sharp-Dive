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
    public partial class typeVSuntypedDS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string SelectQuery = "select * from tblStudents";
                SqlDataAdapter da = new SqlDataAdapter(SelectQuery, conn);
                DataSet ds = new DataSet();
                da.Fill(ds,"students");
                List<Student> StudentList = new List<Student>();
                foreach (DataRow row in ds.Tables["students"].Rows)
                {
                    Student st = new Student
                    {
                        ID = Convert.ToInt32(row["Id"]),
                        Name = row["Name"].ToString(),
                        Gender = row["Gender"].ToString(),
                        TotalMarks = (int)row["TotalMarks"]
                    };
                    StudentList.Add(st);
                }
                GridView1.DataSource = StudentList;
                GridView1.DataBind();
                //or we can use linq 
                GridView1.DataSource= from row in ds.Tables["students"].AsEnumerable()
                                      select new Student
                                      {
                                          ID = Convert.ToInt32(row["Id"]),
                                          Name = row["Name"].ToString(),
                                          Gender = row["Gender"].ToString(),
                                          TotalMarks = (int)row["TotalMarks"]
                                      };
                GridView1.DataBind();
            }
        }
    }
}