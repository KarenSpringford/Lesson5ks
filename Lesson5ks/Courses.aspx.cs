using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using statements that are requuired to connect the the EF DB
using Lesson5ks.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace Lesson5ks
{
    public partial class Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading the page for the first time, populate the student grid
            if (!IsPostBack)
            {

                Session["SortColumn"] = "CourseID";  //default sort column
                Session["SortDirection"] = "ASC";     //added system.linq.dynamic

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

        /**
 * <summary>
 * This event handler deletes the course from the db using EF
 * </summary>
 * @method CoursesGridView_RowDeleting
 * @param (GridViewDeletingEventArgs) e
 * @returns (void)
 * */

        protected void CoursesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked for deletion
            int selectedRow = e.RowIndex;

            //get the selected studentID using the grids data key collection
            int CourseID = Convert.ToInt32(CoursesGridView.DataKeys[selectedRow].Values["CourseID"]);

            //use EF to find the selected student in the DB and remove it
            using (DefaultConnection db = new DefaultConnection())
            {
                //create object of the student class and store the query string inside of it 
                Course deletedCourse = (from CourseDetails in db.Courses
                                        where CourseDetails.CourseID == CourseID
                                        select CourseDetails).FirstOrDefault();

                //remove the selected student from the db
                db.Courses.Remove(deletedCourse);

                //save the changes back to the database
                db.SaveChanges();

                //refresh the grid
                this.GetCourses();
            }
        }

        /**
        * <summary>
        * This event handler allows pagination for the gridview
        * </summary>
        * @method CoursesGridView_PageIndexChanging
        * @param (object) sender
        * @param (GridViewPageEventArgs) e
        * @returns (void)
        * */

        protected void CoursesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new pge number (index)
            CoursesGridView.PageIndex = e.NewPageIndex;

            //refresh the grid
            this.GetCourses();
        }

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the new page size
            CoursesGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            //refresh
            this.GetCourses();
        }

        protected void CoursesGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the columns to sort by
            Session["SortColumn"] = e.SortExpression;

            //refresh the grid
            this.GetCourses();

            //toggle the direction
            Session["SortDiection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";

        }
    }
}