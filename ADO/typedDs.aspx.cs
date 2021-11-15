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
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                //here we cannot make any mistake because it auto generated fileds if we right the name of the coloumes
                //wrong it will not work because its auto generated from the schema of the table it self
                GridView1.DataSource = from student in StudentDataTable
                                       select new { student.ID, student.Name, student.Gender, student.TotalMarks };
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = from student in StudentDataTable
                                       where student.Name.ToLower().StartsWith(TextBox1.Text.ToLower().Trim())
                                       select new { student.ID, student.Name, student.Gender, student.TotalMarks };
                GridView1.DataBind();
            }
        }
    }
}