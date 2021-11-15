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
    public partial class typedDs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                StudentDataSetTableAdapters.StudentsTableAdapter StudentTableAdapter =
                    new StudentDataSetTableAdapters.StudentsTableAdapter();
                StudentDataSet.StudentsDataTable StudentDataTable =
                    new StudentDataSet.StudentsDataTable();

                StudentTableAdapter.Fill(StudentDataTable);

                Session["dataset"] = StudentDataTable;
                GridView1.DataSource = from student in StudentDataTable
                                       select new { student.ID, student.Name, student.Gender, student.TotalMarks };
                GridView1.DataBind();
                //GridView1.DataSource = StudentDataTable;
                //GridView1.DataBind();


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StudentDataSet.StudentsDataTable StudentDataTable =
                   (StudentDataSet.StudentsDataTable)Session["dataset"];
            if(string.IsNullOrEmpty(TextBox1.Text))
            {
                GridView1.DataSource = from student in StudentDataTable
                                       select new { student.ID, student.Name, student.Gender, student.TotalMarks };
                GridView1.DataBind();
            }
        }
    }
}