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
            ViewState["dt"] = dataTable;
            gridView_Update();
        }

        #region Tables drop down list events
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

        protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedTable = ddlTables.SelectedValue;

            gridView.SelectedIndex = -1;
            gridView.EditIndex = -1;

            if (SelectedTable != "None")
            {
                GetData(SelectedTable);
            }
            else
            {
                gridView.DataSource = null;
                gridView.DataBind();
            }
        }
        #endregion

        #region User Input Validation methods
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

        protected void ValidateID(object source, ServerValidateEventArgs args)
        {
            Regex pattern = new Regex(@"^\d+$");
            string text = args.Value;
            args.IsValid = (text != "") ? (pattern.IsMatch(text) ? true : false) : false;
        }

        protected void ValidateName(object source, ServerValidateEventArgs args)
        {
            if (ddlTables.SelectedValue == "Enrollments")
            {
                ValidateID(source, args);
            }
            else
            {
                args.IsValid = args.Value.Length > 0 ? true : false;
            }
        }
        #endregion

        #region gridView Events and methods
        protected void gridView_Update()
        {
            gridView.DataSource = ViewState["dt"] as DataTable;
            gridView.DataBind();
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string SelectedTable = ddlTables.SelectedValue;
            string id = gridView.Rows[e.RowIndex].Cells[2].Text;
            DeleteAccess deleteData = new DeleteAccess(SelectedTable);
            deleteData.DeleteItem(id);
            GetData(SelectedTable);
        }

        protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridView.EditIndex = e.NewEditIndex;
            this.gridView_Update();
        }

        protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridView.EditIndex = -1;
            this.gridView_Update();
        }

        protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Page.IsValid)
            {
                string id = e.NewValues[0].ToString(); ;
                string name = e.NewValues[1].ToString();
                string SelectedTable = ddlTables.SelectedValue;
                UpdateAccess updateData = new UpdateAccess(SelectedTable);
                switch (SelectedTable)
                {
                    case "Enrollments":
                        string stdID = e.NewValues[2].ToString();
                        updateData.UpdateItem(id, name, stdID);
                        break;
                    case "Courses":
                        string courseDesc = e.NewValues[2].ToString();
                        string courseInst = e.NewValues[3].ToString();
                        updateData.UpdateItem(id, name, courseDesc, courseInst);
                        break;
                    case "Students":
                    case "Instructors":
                        updateData.UpdateItem(id, name);
                        break;
                }
                gridView.SelectedIndex = -1;
                gridView.EditIndex = -1;
                GetData(SelectedTable);
            }
        }

        protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = ViewState["dt"] as DataTable;
            dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            ViewState["dt"] = dt;
            gridView_Update();
        }

        protected string GetSortDirection(string column)
        {
            string lastSortColumn = ViewState["SortExpression"] as string;
            string lastSortDirection = ViewState["SortDirection"] as string;

            if (lastSortColumn != null)
            {
                if (lastSortColumn == column)
                {
                    if (lastSortDirection == "ASC")
                    {
                        ViewState["SortExpression"] = column;
                        ViewState["SortDirection"] = "DESC";
                        return "DESC";
                    }
                }
            }

            ViewState["SortExpression"] = column;
            ViewState["SortDirection"] = "ASC";
            return "ASC";
        }
        #endregion

        #region Other Events
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
                string InputId = txtInsertID.Text;
                string InputName = txtInsertName.Text;
                InsertAccess insertData = new InsertAccess(SelectedTable);

                if (SelectedTable != "Courses")
                {
                    insertData.InsertItem(InputId, InputName);
                }
                else
                {
                    string courseDesc = txtInsertCourseDesc.Text;
                    string coursInst = txtInsertCourseInst.Text;

                    insertData.InsertItem(InputId, InputName, courseDesc, coursInst);
                }
                GetData(SelectedTable);
            }
        }
        #endregion

    }
}