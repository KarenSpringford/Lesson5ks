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
    public partial class Departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading the page for the first time, populate the departments grid
            if (!IsPostBack)
            {
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
    }
}