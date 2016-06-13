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

                //add data to the new Department record
                newDepartment.Name = DepartmentTextBox.Text;
                newDepartment.Budget = Convert.ToInt32(BudgetTextBox.Text);

                //use LINQ to ADO.net to add / insert my new Student into the DB
                db.Departments.Add(newDepartment);

                //save our changes
                db.SaveChanges();

                //redirect back to the updated Students page
                Response.Redirect("~/Departments.aspx");
            }
        }
    }
}