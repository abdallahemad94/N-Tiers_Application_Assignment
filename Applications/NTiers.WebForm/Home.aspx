<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NTiers.WebForm.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>NTiers Application</title>
    <link href="Styles/Home.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .InsertControls {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div id="ControlsWrapper">
            <label id="lblTables">Table: </label>
            <asp:DropDownList ID="ddlTables" ClientIDMode="Static" runat="server">
                <asp:ListItem Value="None" Text="None" Selected="True" />
            </asp:DropDownList>
            <br />

            <div id="ViewWrapper">
                <fieldset>
                    <legend>View</legend>
                    <label id="lblFilterBy" class="ViewControls">Filter By: </label>
                    <asp:DropDownList ID="ddlFilter" CssClass="ViewControls" ClientIDMode="Static" runat="server">
                        <asp:ListItem Value="None" Text="None" Selected="True" />
                        <asp:ListItem Value="Student" Text="Student" />
                        <asp:ListItem Value="Course" Text="Course" />
                        <asp:ListItem Value="Instructor" Text="Instructor" />
                    </asp:DropDownList>
                    <br /><br />
                    <label id="lblFilterID" class="ViewControls">Filter ID</label>
                    <asp:TextBox ID="txtFilterID" CssClass="ViewControls" ClientIDMode="Static" runat="server" />
                    <br /><br />
                    <asp:Button ID="btnView" CssClass="ViewControls" ClientIDMode="Static" runat="server" Text="View Data" OnClick="btnView_Click" />
                </fieldset>
            </div>

            <div id="InsertWrapper">
                <fieldset>
                    <legend>Insert</legend>
                    <label id="lblID" class="InsertControls">insert id</label>
                    <asp:TextBox ID="txtID" CssClass="InsertControls" ClientIDMode="Static" runat="server" />
                    <br /><br />
                    <label id="lblName" class="InsertControls">Insert Name</label>
                    <asp:TextBox ID="txtName" CssClass="InsertControls" ClientIDMode="Static" runat="server" />
                    <br /><br />
                    <label id="lblCourseDesc" class="InsertControls">Course Description: </label>
                    <asp:TextBox ID="txtCourseDesc" CssClass="InsertControls" ClientIDMode="Static" runat="server" />
                    <br /><br />
                    <label id="lblCourseInst" class="InsertControls">Coures Instructor: </label>
                    <asp:TextBox ID="txtCourseInst" CssClass="InsertControls" ClientIDMode="Static" runat="server" />
                    <br /><br />
                    <asp:Button ID="btnInsert" CssClass="InsertControls" ClientIDMode="Static" runat="server" Text="Insert Data" OnClick="btnInsert_Click" />
                </fieldset>
            </div>

            <div id="DeleteWrapper">
                <fieldset>
                    <legend>Delete</legend>
                    <label id="lblDeleteID" class="DeleteControls">Delete ID</label>
                    <asp:TextBox ID="txtDeleteID" CssClass="DeleteControls" ClientIDMode ="static" runat="server" />
                    <br /><br />
                    <asp:Button ID="btnDelete" CssClass="DeleteControls" ClientIDMode="Static" runat="server" Text="Delete Item" OnClick="btnDelete_Click" />
                </fieldset>
            </div>
        </div>

        <div id="DataWrapper">
            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                <ContentTemplate>
                    <asp:DataGrid ID="dataGrid" ClientIDMode="Static" runat="server"></asp:DataGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
