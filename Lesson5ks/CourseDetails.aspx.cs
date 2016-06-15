using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using statements required for EF DB access
using Lesson5ks.Models;
using System.Web.ModelBinding;

namespace Lesson5ks
{
    public partial class CourseDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetCourse();
            }

        }

        protected void GetCourse()
        {
            //populate the form with existing data from the db
            int CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);

            //connect through the EF DB
            using (DefaultConnection db = new DefaultConnection())
            {
                //populate a course object instance with the courseID from the url parameter
                Course updatedCourse = (from course
                                         in db.Courses
                                          where course.CourseID == CourseID
                                          select course).FirstOrDefault();

                //map the course properties through the form controls
                if (updatedCourse != null)
                {
                    //CourseIDTextBox.Text = Convert.ToInt32(updatedCourse.CourseIDTextBox.Text);
                    TitleTextBox.Text = updatedCourse.Title;
                    //CreditsTextBox.Text = Convert.ToInt32(updatedCourse.CreditsTextBox.Text);
                    //DepartmentIDTextBox.Text = Convert.ToInt32(updatedCourse.DepartmentIDTextBox.Text);
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //redirect back to Courses page
            Response.Redirect("~/Courses.aspx");

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //use EF to connect to the server
            using (DefaultConnection db = new DefaultConnection())
            {
                //use the Course model to create a new course object and 
                //save a new record
                Course newCourse = new Course();

                int CourseID = 0;

                if (Request.QueryString.Count > 0) //our URL has a courseID in it 
                {
                    //get the id from the URL
                    CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);

                    //get the current course from the EF DB
                    newCourse = (from course in db.Courses
                                  where course.CourseID == CourseID
                                  select course).FirstOrDefault();
                }


                //add data to the new Course record
                newCourse.Title = TitleTextBox.Text;
                newCourse.Credits = Convert.ToInt32(CreditsTextBox.Text);
                newCourse.DepartmentID = Convert.ToInt32(DepartmentIDTextBox);

                //use LINQ to ADO.net to add / insert my new Course into the DB
                if (CourseID == 0)
                {
                    db.Courses.Add(newCourse);
                }

                //save our changes / also updates and inserts
                db.SaveChanges();

                //redirect back to the updated Courses page
                Response.Redirect("~/Courses.aspx");


            }
        }
    }
}