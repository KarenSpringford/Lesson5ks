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
    public partial class Departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading the page for the first time, populate the departments grid
            if (!IsPostBack)
            {

                Session["SortColumn"] = "DepartmentID";  //default sort column
                Session["SortDirection"] = "ASC";     //added system.linq.dynamic

                //get the departments data
                this.GetDepartments();
            }
        }
        protected void GetDepartments()
        {
            //connect to the EF
            using (DefaultConnection db = new DefaultConnection())
            {
                //query the students table using EF and LINQ
                var Departments = (from allDepartments in db.Departments
                                   select allDepartments);

                //sends the data to a list
                DepartmentsGridView.DataSource = Departments.ToList();
                //binds the data to the grid
                DepartmentsGridView.DataBind();
            }
        }

        /**
         * <summary>
         * This event handler deletes the Department from the db using EF
         * </summary>
         * @method DepartmentsGridView_RowDeleting
         * @param (GridViewDeletingEventArgs) e
         * @returns (void)
         * */

        protected void DepartmentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked for deletion
            int selectedRow = e.RowIndex;

            //get the selected studentID using the grids data key collection
            int DepartmentID = Convert.ToInt32(DepartmentsGridView.DataKeys[selectedRow].Values["DepartmentID"]);

            //use EF to find the selected student in the DB and remove it
            using (DefaultConnection db = new DefaultConnection())
            {
                //create object of the student class and store the query string inside of it 
                Department deletedDepartment = (from DepartmentDetails in db.Departments
                                          where DepartmentDetails.DepartmentID == DepartmentID
                                          select DepartmentDetails).FirstOrDefault();

                //remove the selected student from the db
                db.Departments.Remove(deletedDepartment);

                //save the changes back to the database
                db.SaveChanges();

                //refresh the grid
                this.GetDepartments();
            }
        }
        /**
         * <summary>
         * This event handler allows pagination for the gridview
         * </summary>
         * @method DepartmentsGridView_PageIndexChanging
         * @param (object) sender
         * @param (GridViewPageEventArgs) e
         * @returns (void)
         * */

        protected void DepartmentsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new pge number (index)
            DepartmentsGridView.PageIndex = e.NewPageIndex;

            //refresh the grid
            this.GetDepartments();
        }

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the new page size
            DepartmentsGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            //refresh
            this.GetDepartments();
        }

        protected void DepartmentsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the columns to sort by
            Session["SortColumn"] = e.SortExpression;

            //refresh the grid
            this.GetDepartments();

            //toggle the direction
            Session["SortDiection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
    }
}
