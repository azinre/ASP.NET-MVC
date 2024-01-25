using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["students"] == null)
                {
                    Response.Redirect("AddStudent.aspx");
                }
                else
                {
                    List<Student> students = (List<Student>)Session["Students"];
                    ddlStudent.Items.Add(new ListItem("Select...", "-1"));
                    foreach (Student student in students)
                    {
                        ddlStudent.Items.Add(new ListItem(student.ToString(), Convert.ToString(student.Id)));
                    }
                }
                foreach (Course course in Helper.GetAvailableCourses())
                {
                    string chcklstLabel = course.Title + " - " + course.WeeklyHours + " hours/week";
                    coursesSelectedLst.Items.Add(new ListItem(chcklstLabel, course.Code));
                }
            }

        }
        protected void StudentSelectChange(object sender, EventArgs e)
        {
            if (ddlStudent.SelectedValue != "-1")
            {
                studentSummary.Visible = true;
                studentSummary.Text = "Selected student has registered 0 course(s), 0 hours weekly.";

            }
        }
        List<Course> doingRegisteredcourses = new List<Course>();
        protected void CourseSelectChange(object sender, EventArgs e)
        {

            if (ddlStudent.SelectedValue != "-1")
            {
                studentSummary.Visible = true;

                int selectedHours = 0;
                int selectedCourses = 0;
                foreach (ListItem lstItem in coursesSelectedLst.Items)
                {
                    if (lstItem.Selected)
                    {
                        Course course = Helper.GetCourseByCode(lstItem.Value);
                        selectedHours += course.WeeklyHours;
                        selectedCourses++;
                        doingRegisteredcourses.Add(course);
                    }
                }
                studentSummary.Text = "Selected student has registered " + Convert.ToString(selectedCourses) + " course(s), " + Convert.ToString(selectedHours) + " hours weekly.";
                
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblErrorMsg.Visible = true)
                {
                    int selectedId = Convert.ToInt32(ddlStudent.SelectedValue);
                    List<Student> students = (List<Student>)Session["Students"];

                    List<Course> registerCourses = new List<Course>();
                    int selectedCourses = 0;
                    int selectedHours = 0;

                    foreach (ListItem lstItem in coursesSelectedLst.Items)
                    {
                        if (lstItem.Selected)
                        {

                            Course c = Helper.GetCourseByCode(lstItem.Value);
                            registerCourses.Add(c);
                            selectedCourses++;
                            selectedHours += Helper.GetCourseByCode(lstItem.Value).WeeklyHours;
                        }
                    }
                    if (registerCourses.Count == 0)
                    {
                        lblErrorMsg.Text = "You need to select at least one course";
                        lblErrorMsg.Visible = true;
                        studentSummary.Visible = false;
                        return;
                    }

                    foreach (Student student in students)
                    {
                        if (student.Id == selectedId)
                        {
                            student.RegisterCourses(registerCourses);
                            studentSummary.Visible = true;
                            studentSummary.Text = "Selected student has registered " + Convert.ToString(selectedCourses) + " course(s), " + Convert.ToString(selectedHours) + " hours weekly.";
                            lblErrorMsg.Visible = false;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                studentSummary.Visible = false;
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = ex.Message;
            }
        }
     }

}

    


