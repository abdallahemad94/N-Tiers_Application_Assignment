<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlsInsert.ascx.cs" Inherits="NTiers.WebForm.ControlsInsert" %>

<fieldset>
    <legend>Insert</legend>
    <label id="lblID" class="InsertControls">insert id</label>
    <asp:TextBox ID="txtID" CssClass="InsertControls" ClientIDMode="Static" runat="server" />
    <br />
    <label id="lblName" class="InsertControls">Insert Name</label>
    <asp:TextBox ID="txtName" CssClass="InsertControls" ClientIDMode="Static" runat="server" />
    <br />
    <label id="lblCourseDesc" class="InsertControls">Course Description: </label>
    <asp:TextBox ID="txtCourseDesc" CssClass="InsertControls" ClientIDMode="Static" runat="server" />
    <br />
    <label id="lblCourseInst" class="InsertControls">Coures Instructor: </label>
    <asp:TextBox ID="txtCourseInst" CssClass="InsertControls" ClientIDMode="Static" runat="server" />
    <br />
    <asp:Button ID="btnInsert" CssClass="InsertControls" ClientIDMode="Static" runat="server" Text="Insert Data" />
</fieldset>