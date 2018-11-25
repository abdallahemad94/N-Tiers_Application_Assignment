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

        protected void dataGrid_Update()//DataTable dataTable)
        {
            dataGrid.DataSource = ViewState["dt"] as DataTable;//dataTable;
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
            dataGrid.SelectedIndex = -1;
            dataGrid.EditIndex = -1;
            ViewState["dt"] = dataTable;
            dataGrid_Update();//dataTable);
        }

        protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedTable = ddlTables.SelectedValue;
            dataGrid.SelectedIndex = -1;
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
            string SelectedTable = ddlTables.SelectedValue;
            string id = dataGrid.Rows[e.RowIndex].Cells[2].Text;
            DeleteAccess deleteData = new DeleteAccess(SelectedTable);
            deleteData.DeleteItem(id);
            GetData(SelectedTable);
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

        protected void dataGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dataGrid.EditIndex = e.NewEditIndex;
            this.dataGrid_Update();
        }

        protected void dataGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dataGrid.EditIndex = -1;
            this.dataGrid_Update();
        }

        protected void dataGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Page.IsValid)
            {
                string SelectedTable = ddlTables.SelectedValue;
                string id = e.NewValues[0].ToString(); ;
                string name = e.NewValues[1].ToString();
                UpdateAccess updateData = new UpdateAccess(SelectedTable);
                switch (SelectedTable)
                {
                    case "Courses":
                        string courseDesc = e.NewValues[2].ToString();
                        string courseInst = e.NewValues[3].ToString();
                        updateData.UpdateItem(id, name, courseDesc, courseInst);
                        break;
                    case "Enrollments":
                        string stdID = e.NewValues[2].ToString();
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
    }
}