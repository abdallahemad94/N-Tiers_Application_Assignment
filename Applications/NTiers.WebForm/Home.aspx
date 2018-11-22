<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NTiers.WebForm.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>NTiers Application</title>
    <link href="Styles/Home.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-3.3.1.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Name="jquery" />
            </Scripts>
        </asp:ScriptManager>
        <script src="Scripts/Home.js" type="text/javascript"></script>
        <div id="ControlsWrapper">
            <label id="lblTables">Table: </label>
            <asp:DropDownList ID="ddlTables" ClientIDMode="Static" runat="server">
                <asp:ListItem Value="None" Text="None" Selected="True" />
            </asp:DropDownList>
            <br />

            <div id="ViewWrapper">
                <fieldset class="ViewControls FieldInfo">
                    <legend class="ViewControls FieldInfo">View</legend>
                    <label id="lblFilterBy" class="ViewControls">Filter By: </label>
                    <asp:DropDownList ID="ddlFilter" CssClass="ViewControls" ClientIDMode="Static" runat="server">
                        <asp:ListItem Value="None" Text="None" Selected="True" />
                        <asp:ListItem Value="Student" Text="Student" />
                        <asp:ListItem Value="Course" Text="Course" />
                        <asp:ListItem Value="Instructor" Text="Instructor" />
                    </asp:DropDownList>
                    <br /><br />
                    <label id="lblFilterID" class="ViewControls FilterOptions">Filter ID</label>
                    <asp:TextBox ID="txtFilterID" CssClass="ViewControls FilterOptions" ClientIDMode="Static" runat="server" />
                    <asp:CustomValidator ID="ValidateFilterID" CssClass="ValidationControls" ClientIDMode="Static" runat="server"
                        ControlToValidate="txtFilterID" ClientValidationFunction="ValidateFilterID"
                        ErrorMessage="Please enter a valid number!" ForeColor="Red" ValidateEmptyText="True" 
                        ValidationGroup="FilterData" />
                    <br /><br />
                    <asp:Button ID="btnView" CssClass="ViewControls" ClientIDMode="Static" runat="server" 
                        Text="View Data" OnClick="btnView_Click" ValidationGroup="FilterData" />
                </fieldset>
            </div>

            <div id="InsertWrapper">
                <fieldset class="InsertControls FieldInfo">
                    <legend class="InsertControls FieldInfo">Insert</legend>
                    <label id="lblInsertID" class="InsertControls">insert id</label>
                    <asp:TextBox ID="txtInsertID" CssClass="InsertControls" ClientIDMode="Static" runat="server" />
                    <asp:CustomValidator ID="ValidateInsertID" CssClass="ValidationControls" ClientIDMode="Static" runat="server"
                        ControlToValidate="txtInsertID" ClientValidationFunction="ValidateID"
                        ErrorMessage="Please enter a valid number!" ForeColor="Red" ValidateEmptyText="true"
                        ValidationGroup="InsertData" />
                    <br /><br />
                    <label id="lblInsertName" class="InsertControls">Insert Name</label>
                    <asp:TextBox ID="txtInsertName" CssClass="InsertControls" ClientIDMode="Static" runat="server" />
                    <asp:CustomValidator ID="ValidateInsertName" CssClass="ValidationControls" ClientIDMode="Static"
                        runat="server" ControlToValidate="txtInsertName" ClientValidationFunction="ValidateName"
                        ErrorMessage="Please enter a name!" ForeColor="Red" ValidateEmptyText="true"
                        ValidationGroup="InsertData" />
                    <br /><br />
                    <label id="lblCourseDesc" class="InsertControls">Course Description: </label>
                    <asp:TextBox ID="txtCourseDesc" CssClass="InsertControls" ClientIDMode="Static" runat="server" />
                    <br /><br />
                    <label id="lblCourseInst" class="InsertControls">Coures Instructor: </label>
                    <asp:TextBox ID="txtCourseInst" CssClass="InsertControls" ClientIDMode="Static" runat="server" />
                    <asp:CustomValidator ID="ValidateCourseInst" CssClass="ValidationControls" ClientIDMode="Static"
                        runat="server" ControlToValidate="txtCourseInst" ClientValidationFunction="ValidateID"
                        ErrorMessage="Please enter a valid number!" ForeColor="Red" ValidationGroup="InsertData"
                        ValidateEmptyText="true"/>
                    <br /><br />
                    <asp:Button ID="btnInsert" CssClass="InsertControls" ClientIDMode="Static" runat="server" 
                        Text="Insert Data" OnClick="btnInsert_Click" ValidationGroup="InsertData"/>
                </fieldset>
            </div>

            <div id="DeleteWrapper">
                <fieldset class="DeleteControls FieldInfo">
                    <legend class="DeleteControls FieldInfo">Delete</legend>
                    <label id="lblDeleteID" class="DeleteControls">Delete ID</label>
                    <asp:TextBox ID="txtDeleteID" CssClass="DeleteControls" ClientIDMode ="static" runat="server" />
                    <asp:CustomValidator ID="ValidateDeleteID" CssClass="ValidationControls" ClientIDMode="Static"
                        runat="server" ControlToValidate="txtDeleteID" ClientValidationFunction="ValidateID"
                        ErrorMessage="Please enter a valid number!" ForeColor="Red" ValidationGroup="DeleteData"
                        ValidateEmptyText="true" />
                    <br /><br />
                    <asp:Button ID="btnDelete" CssClass="DeleteControls" ClientIDMode="Static" runat="server"
                        Text="Delete Item" OnClick="btnDelete_Click"  ValidationGroup="DeleteData"/>
                </fieldset>
            </div>
        </div>
        
        <div id="DataWrapper">
            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnView" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnInsert" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:DataGrid ID="dataGrid" ClientIDMode="Static" runat="server">
                        <AlternatingItemStyle BackColor="#66CCFF" />
                        <HeaderStyle BackColor="#6699FF" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:DataGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
