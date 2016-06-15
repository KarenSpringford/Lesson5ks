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
    public partial class DepartmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetDepartment();
            }
        }

        protected void GetDepartment()
        {
            //populate the form with existing data from the db
            int DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

            //connect through the EF DB
            using (DefaultConnection db = new DefaultConnection())
            {
                //populate a department object instance with the departmentID from the url parameter
                Department updatedDepartment = (from Departments
                                         in db.Departments
                                        where Departments.DepartmentID == DepartmentID
                                        select Departments).FirstOrDefault();

                //map the department properties through the form controls
                if (updatedDepartment != null)
                {
                    //DepartmentIDTextBox.Text = Convert.ToInt32(updatedDepartment.DepartmentIDTextBox.Text);
                    //DepartmentTextBox.Text = updatedDepartment.DepartmentTextBox.Text;
                    //BudgetTextBox.Text = Convert.ToDecimal(updatedDepartment.BudgetTextBox.Text);
                    
                }
            }

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //redirect back to Departments page
            Response.Redirect("~/Departments.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //use EF to connect to the server
            using (DefaultConnection db = new DefaultConnection())
            {
                //use the Course model to create a new course object and 
                //save a new record
                Department newDepartment = new Department();

                int DepartmentID = 0;

                if (Request.QueryString.Count > 0) //our URL has a studentId in it 
                {
                    //get the id from the URL
                    DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    //get the current student from the EF DB
                    newDepartment = (from department in db.Departments
                                  where department.DepartmentID == DepartmentID
                                  select department).FirstOrDefault();
                }

                //add data to the new Department record
                newDepartment.Name = DepartmentTextBox.Text;
                newDepartment.Budget = Convert.ToInt32(BudgetTextBox.Text);

                //use LINQ to ADO.net to add / insert my new Department into the DB
                if (DepartmentID == 0)
                {
                    db.Departments.Add(newDepartment);
                }

                //save our changes / also updates and inserts
                db.SaveChanges();

                //redirect back to the updated Departments page
                Response.Redirect("~/Departments.aspx");
            }
        }
    }
}