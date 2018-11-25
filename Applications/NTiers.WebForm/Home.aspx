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
            <asp:DropDownList ID="ddlTables" ClientIDMode="Static" runat="server" AutoPostBack="True" 
                OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
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
                        ValidationGroup="FilterData" OnServerValidate="ValidateFilter" />
                    <br /><br />
                    <asp:Button ID="btnFilter" CssClass="ViewControls" ClientIDMode="Static" runat="server" 
                        Text="Filter Data" OnClick="btnFilter_Click" ValidationGroup="FilterData" CausesValidation="true" />
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
                        ValidationGroup="InsertData" OnServerValidate="ValidateID"/>
                    <br /><br />
                    <label id="lblInsertName" class="InsertControls">Insert Name</label>
                    <asp:TextBox ID="txtInsertName" CssClass="InsertControls" ClientIDMode="Static" runat="server" />
                    <asp:CustomValidator ID="ValidateInsertName" CssClass="ValidationControls" ClientIDMode="Static"
                        runat="server" ControlToValidate="txtInsertName" ClientValidationFunction="ValidateName"
                        ErrorMessage="Please enter a name!" ForeColor="Red" ValidateEmptyText="true"
                        ValidationGroup="InsertData" OnServerValidate="ValidateName"/>
                    <br /><br />
                    <label id="lblInsertCourseDesc" class="InsertControls CourseInsert">Course Description: </label>
                    <asp:TextBox ID="txtInsertCourseDesc" CssClass="InsertControls CourseInsert" ClientIDMode="Static" runat="server" />
                    <br /><br />
                    <label id="lblInsertCourseInst" class="InsertControls CourseInsert">Coures Instructor: </label>
                    <asp:TextBox ID="txtInsertCourseInst" CssClass="InsertControls CourseInsert" ClientIDMode="Static" runat="server" />
                    <asp:CustomValidator ID="ValidateCourseInst" CssClass="ValidationControls" ClientIDMode="Static"
                        runat="server" ControlToValidate="txtInsertCourseInst" ClientValidationFunction="ValidateCourseInst"
                        ErrorMessage="Please enter a valid number!" ForeColor="Red" ValidationGroup="InsertData"
                        ValidateEmptyText="true" OnServerValidate="ValidateCourseInstID" />
                    <br /><br />
                    <asp:Button ID="btnInsert" CssClass="InsertControls" ClientIDMode="Static" runat="server" 
                        Text="Insert Data" OnClick="btnInsert_Click" ValidationGroup="InsertData"/>
                </fieldset>
            </div>

            <div class="UpdateWrapper">
                <fieldset class="UpdateControls">
                    <legend class="UpdateControls">Update</legend>
                    <label id="lblUpdateID" class="UpdateControls">id</label>
                    <asp:UpdatePanel runat="server" ID="pnlUpdate" ClientIDMode="Static" RenderMode="Inline">
                        <ContentTemplate>
                            <asp:Label runat="server" ID="lblID" CssClass="UpdateControls" Text="" ClientIDMode="Static"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br /><br />
                    <label id="lblUpdateName" class="UpdateControls">name</label>
                    <asp:TextBox ID="txtUpdateName" CssClass="UpdateControls" ClientIDMode="Static" runat="server"></asp:TextBox>
                    <br /><br />
                    <label id="lblUpdateCourseDesc" class="UpdateControls CourseUpdate">Course Description: </label>
                    <asp:TextBox ID="txtUpdateCourseDesc" CssClass="UpdateControls CourseUpdate" ClientIDMode="Static" runat="server"></asp:TextBox>
                    <br /><br />
                    <label id="lblUpdateCourseInst" class="UpdateControls CourseUpdate">Course Instructor: </label>
                    <asp:TextBox ID="txtUpdateCourseInst" CssClass="UpdateControls CourseUpdate" ClientIDMode="Static" runat="server"></asp:TextBox>
                    <br /><br />
                    <asp:Button ID="btnUpdate" CssClass="UpdateControls" ClientIDMode="Static" runat="server" Text="Update Item" 
                        OnClick="btnUpdate_Click"/>
                </fieldset>
            </div>
        </div>
        
        <div id="DataWrapper">
            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnFilter" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnInsert" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="ddlTables" EventName="SelectedIndexChanged"/>
                </Triggers>

                <ContentTemplate>
                    <asp:GridView ID="dataGrid" runat="server" CellPadding="3" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" 
                        CellSpacing="1" OnRowDeleting="btnDelete_RowDeleting" OnSelectedIndexChanging="dataGrid_SelectedIndexChanging">  
                        <AlternatingRowStyle BackColor="White" />  
                        <Columns>
                            <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" />
                            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
                        </Columns>

                        <EditRowStyle BackColor="#2461BF" />  
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />  
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />  
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />  
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />  
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />  
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />  
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />  
                    </asp:GridView> 
                    <br /><br />
                    <asp:Label ID="test" runat="server" Text="test" ></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
