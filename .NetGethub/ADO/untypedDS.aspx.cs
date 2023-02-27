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
            if (!IsPostBack)
            {
                string cs = ConfigurationManager.ConnectionStrings["firstdb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string SelectQuery = "select * from tblStudents";
                    SqlDataAdapter da = new SqlDataAdapter(SelectQuery, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "students");

                    Session["dataset"] = ds;

                    List<Student> StudentList = GetStudentList();
                    GridView1.DataSource = StudentList;
                    GridView1.DataBind();


                    //or we can use linq 
                    //GridView1.DataSource = from row in ds.Tables["students"].AsEnumerable()
                    //                       select new Student
                    //                       {
                    //                           ID = Convert.ToInt32(row["Id"]),
                    //                           Name = row["Name"].ToString(),
                    //                           Gender = row["Gender"].ToString(),
                    //                           TotalMarks = (int)row["TotalMarks"]
                    //                       };
                    //GridView1.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Session["dataset"];
            //if the textbox is empty 
            if(string.IsNullOrEmpty(TextBox1.Text))
            {
                List<Student> StudentList = GetStudentList();
                GridView1.DataSource = StudentList;
                GridView1.DataBind();
            }
            //filter the rows on Name column
            else
            {
                //here we using untyped dataset meaning that we specife the object that the data take ,any
                //Misspelled on the naming of the columns we map will result in an error
                // e.x id = row["id1"];
                GridView1.DataSource = from row in ds.Tables["students"].AsEnumerable()
                                       where row["Name"].ToString().ToLower().StartsWith(TextBox1.Text.ToLower().Trim())
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


        private List<Student> GetStudentList()
        {
            List<Student> StudentList = new List<Student>();

            DataSet ds = (DataSet)Session["dataset"];

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
            return StudentList;
        }
    }
}