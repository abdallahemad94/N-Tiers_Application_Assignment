using NTiers.AppLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace NTiers.WebForm
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddlTables.Items.Count < 2) { ddlTables_Fill(); }
            ddlTables.Attributes.Add("onchange", "ddlTables_Change()");
            ddlFilter.Attributes.Add("onchange", "ddlFilter_Change()");
        }

        /// <summary>
        /// gets a list of the database tables name and append it
        /// to the tables drop down list
        /// </summary>
        protected void ddlTables_Fill()
        {
            List<string> tables = ViewAccess.GetTables();
            foreach (string table in tables)
            {
                ddlTables.Items.Add(table);
            }
        }

        protected void dataGrid_Update(DataTable dataTable)
        {
            dataGrid.DataSource = dataTable;
            dataGrid.DataBind();
        }

        protected void GetData(string selectedTable, string SelectedFilter = "None")
        {
            ViewAccess viewData = new ViewAccess(selectedTable);
            DataTable dataTable;

            if (SelectedFilter != "None")
            {
                string FilterID = txtFilterID.Text;
                dataTable = viewData.GetFilterdData(SelectedFilter, FilterID);
            }
            else
            {
                dataTable = viewData.GetUnFilterdData();
            }
            test.Text = selectedTable;
            dataGrid_Update(dataTable);
        }

        protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedTable = ddlTables.SelectedValue;
            dataGrid.SelectedIndex = -1;
            lblID.Text = "";
            if (SelectedTable != "None") { GetData(SelectedTable); }
            else
            {
                dataGrid.DataSource = null;
                dataGrid.DataBind();
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string SelectedTable = ddlTables.SelectedValue;
                string SelectedFilter = ddlFilter.SelectedValue;
                GetData(SelectedTable, SelectedFilter);
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string SelectedTable = ddlTables.SelectedValue;
                InsertAccess insertData = new InsertAccess(SelectedTable);
                if (SelectedTable != "Courses")
                {
                    string InputId = txtInsertID.Text;
                    string InputName = txtInsertName.Text;

                    insertData.InsertItem(InputId, InputName);
                }
                else
                {
                    string InputId = txtInsertID.Text;
                    string InputName = txtInsertName.Text;
                    string courseDesc = txtInsertCourseDesc.Text;
                    string coursInst = txtInsertCourseInst.Text;

                    insertData.InsertItem(InputId, InputName, courseDesc, coursInst);
                }
                GetData(SelectedTable);
            }
        }

        protected void btnDelete_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Page.IsValid)
            {
                string SelectedTable = ddlTables.SelectedValue;
                string id = dataGrid.Rows[e.RowIndex].Cells[1].Text;
                DeleteAccess deleteData = new DeleteAccess(SelectedTable);
                deleteData.DeleteItem(id);
                GetData(SelectedTable);
            }
        }

        protected void dataGrid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string id = dataGrid.Rows[e.NewSelectedIndex].Cells[2].Text;
            lblID.Text = id;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string SelectedTable = ddlTables.SelectedValue;
                string id = lblID.Text;
                string name = txtUpdateName.Text;
                UpdateAccess updateData = new UpdateAccess(SelectedTable);
                switch (SelectedTable)
                {
                    case "Courses":
                        string courseDesc = txtUpdateCourseDesc.Text;
                        string courseInst = txtUpdateCourseInst.Text;
                        updateData.UpdateItem(id, name, courseDesc, courseInst);
                        break;
                    case "Enrollments":
                        string stdID = txtUpdateCourseDesc.Text;
                        updateData.UpdateItem(id, name, stdID);
                        break;
                    case "Students":
                    case "Instructors":
                        updateData.UpdateItem(id, name);
                        break;
                }
                GetData(SelectedTable);
            }
        }

        protected void ValidateFilter(object source, ServerValidateEventArgs args)
        {
            string SelectedFilter = ddlFilter.SelectedValue;
            if (SelectedFilter == "None")
            {
                args.IsValid = true;
            }
            else
            {
                ValidateID(source, args);
            }
        }

        protected void ValidateID(object source, ServerValidateEventArgs args)
        {
            Regex pattern = new Regex(@"^\d+$");
            string text = args.Value;
            if (text != "")
            {
                if (pattern.IsMatch(text))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void ValidateName(object source, ServerValidateEventArgs args)
        { 
            if (ddlTables.SelectedValue == "Enrollments")
            {
                ValidateInsertName.Text = "Please enter a valid number!";
                ValidateID(source, args);
            }
            else
            {
                ValidateInsertName.Text = "Please enter a name!";
                if (args.Value.Length > 0) { args.IsValid = true; }
                else { args.IsValid = false; }
            }
        }

        protected void ValidateCourseInstID(object source, ServerValidateEventArgs args)
        {
            if (ddlTables.SelectedValue == "Courses")
            {
                ValidateID(source, args);
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}