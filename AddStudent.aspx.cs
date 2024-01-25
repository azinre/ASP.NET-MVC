using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab8
{  
        public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Student> students;
            if (Session["Students"] == null)
            {
                students = new List<Student>();
            }
            else
            {
                students = (List<Student>)Session["Students"];
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsValid) return;

            tblMessage.Visible = false;
            // Get the selected student type from the dropdown list
            string selectedType = ddlType.SelectedValue;
            // Get the entered student name from the text box
            string name = txtName.Text;
            List<Student> students;
            if (Session["Students"] == null)
            {
                students = new List<Student>();
            }
            else
            {
                students = (List<Student>)Session["Students"];
            }

            if (selectedType == "FullTime")
            {
                FulltimeStudent newstudent = new FulltimeStudent(name);
                students.Add(newstudent);
            }
            else if (selectedType == "PartTime")
            {
                ParttimeStudent newstudent = new ParttimeStudent(name);
                students.Add(newstudent);
            }
            else if (selectedType == "Coop")
            {
                CoopStudent newstudent = new CoopStudent(name);
                students.Add(newstudent);
            }
            // Store the updated list of students in Session
            Session["Students"] = students;
            foreach (Student student in students)
            {
                TableRow row = new TableRow();
                TableCell idCell = new TableCell();
                TableCell nameCell = new TableCell();

                idCell.Text = Convert.ToString(student.Id);
                nameCell.Text = student.Name;

                row.Cells.Add(idCell);
                row.Cells.Add(nameCell);
                tblStudents.Rows.Add(row);
            }

            // Clear the student name text box
            txtName.Text = "";

            // Reset the student type dropdown list
            ddlType.SelectedValue = "";

        }

    }
}
