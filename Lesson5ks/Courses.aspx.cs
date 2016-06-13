using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using statements that are requuired to connect the the EF DB
using Lesson5ks.Models;
using System.Web.ModelBinding;

namespace Lesson5ks
{
    public partial class Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading the page for the first time, populate the student grid
            if (!IsPostBack)
            {
                //get the student data
                this.GetCourses();
            }
        }

        /**
      * <summary>
      * This method gets the course data from the DB
      * </summary>
      * @method GetCourses
      * @return (void)
      * */

        protected void GetCourses()
        {
            //connect to the EF
            using (DefaultConnection db = new DefaultConnection())
            {
                //query the students table using EF and LINQ
                var Courses = (from allCourses in db.Courses
                               select allCourses);

                //sends the data to a list
                CoursesGridView.DataSource = Courses.ToList();
                //binds the data to the grid
                CoursesGridView.DataBind();
            }
        }
    }
}