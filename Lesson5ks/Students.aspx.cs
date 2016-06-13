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
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading the page for the first time, populate the student grid
            if (!IsPostBack)
            {
                //get the student data
                this.GetStudents();
            }
        }

        /**
         * <summary>
         * This method gets the student data from the DB
         * </summary>
         * @method GetStudents
         * @return (void)
         * */

        protected void GetStudents()
        {
            //connect to the EF
            using (DefaultConnection db = new DefaultConnection())
            {
                //query the students table using EF and LINQ
                var Students = (from allStudents in db.Students
                                select allStudents);

                //sends the data to a list
                StudentsGridView.DataSource = Students.ToList();
                //binds the data to the grid
                StudentsGridView.DataBind();
            }
        }

        /**
         * <summary>
         * This event handler deletes the student from the db using EF
         * </summary>
         * @method StudentsGridView_RowDeleting
         * @param (GridViewDeletingEventArgs) e
         * @returns (void)
         * */

        protected void StudentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked for deletion
            int selectedRow = e.RowIndex;

            //get the selected studentID using the grids data key collection
            int StudentID = Convert.ToInt32(StudentsGridView.DataKeys[selectedRow].Values["StudentID"]);

            //use EF to find the selected student in the DB and remove it
            using(DefaultConnection db = new DefaultConnection())
            {
                //create object of the student class and store the query string inside of it 
                Student deletedStudent = (from StudentDetails in db.Students
                                          where StudentDetails.StudentID == StudentID
                                          select StudentDetails).FirstOrDefault();

                //remove the selected student from the db
                db.Students.Remove(deletedStudent);

                //save the changes back to the database
                db.SaveChanges();

                //refresh the grid
                this.GetStudents();
            }
        }

        /**
         * <summary>
         * This event handler allows pagination for the gridview
         * </summary>
         * @method StudentsGridView_PageIndexChanging
         * @param (object) sender
         * @param (GridViewPageEventArgs) e
         * @returns (void)
         * */

        protected void StudentsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new pge number (index)
            StudentsGridView.PageIndex = e.NewPageIndex;

            //refresh the grid
            this.GetStudents();
        }

        /**
         * <summary>
         * sets the new page size
         * </summary>
         * @method PageSizeDropDownList_SelectedIndexChanged
         * */

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the new page size
            StudentsGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            //refresh
            this.GetStudents();

        }
    }
}