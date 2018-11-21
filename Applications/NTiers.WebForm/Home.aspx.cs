using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NTiers.AppLogic;


namespace NTiers.WebForm
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddlTables.Items.Count < 2) { ddlTables_Fill(); }
        }

        /// <summary>
        /// gets a list of the database tables name and append it
        /// to the tables drop down list
        /// </summary>
        protected void ddlTables_Fill()
        {
            //TODO: Reference Database tables Retreive Methods
            List<string> tables = ViewData.GetTables();
            foreach(string table in tables)
            {
                ddlTables.Items.Add(table);
            }
        }

        protected void dataGrid_Update(DataTable dataTable)
        {
            dataGrid.DataSource = dataTable;
            dataGrid.DataBind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            string SelectedTable = ddlTables.SelectedValue;
            string SelectedFilter = ddlFilter.SelectedValue;
            string IdInput = txtFilterID.Text;

            ViewData viewData = new ViewData(SelectedTable);
            DataTable dataTable;

            if(SelectedFilter != "None")
            {
                dataTable = viewData.GetFilterdData(SelectedFilter, IdInput);
            }
            else
            {
                dataTable = viewData.GetUnFilterdData();
            }

            dataGrid_Update(dataTable);
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string SelectedTable = ddlTables.SelectedValue;
            InsertData insertData = new InsertData(SelectedTable);
            if (SelectedTable != "Courses")
            {
                string InputId = txtID.Text;
                string InputName = txtName.Text;

                insertData.InsertItem(InputId, InputName);
            }
            else
            {
                string InputId = txtID.Text;
                string InputName = txtName.Text;
                string courseDesc = txtCourseDesc.Text;
                string coursInst = txtCourseInst.Text;

                insertData.InsertItem(InputId, InputName, courseDesc, coursInst);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string SelectedTable = ddlTables.SelectedValue;
            DeleteData deleteData = new DeleteData(SelectedTable);
            string deleteID = txtDeleteID.Text;
            deleteData.DeleteItem(deleteID);
        }
    }
}