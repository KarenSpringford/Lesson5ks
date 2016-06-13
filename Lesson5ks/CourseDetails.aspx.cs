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

                //add data to the new Course record
                newCourse.Title = TitleTextBox.Text;
                newCourse.Credits = Convert.ToInt32(CreditsTextBox.Text);
                newCourse.DepartmentID = Convert.ToInt32(DepartmentIDTextBox);

                //use LINQ to ADO.net to add / insert my new Course into the DB
                db.Courses.Add(newCourse);

                //save our changes
                db.SaveChanges();

                //redirect back to the updated Students page
                Response.Redirect("~/Courses.aspx");


            }
        }
    }
}