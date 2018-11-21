<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlsView.ascx.cs" Inherits="NTiers.WebForm.ControlsView" %>

<fieldset>
    <legend>View</legend>
    <label id="lblFilterBy" class="ViewControls">Filter By: </label>
    <asp:DropDownList ID="ddlFilter" CssClass="ViewControls" ClientIDMode="Static" runat="server">
        <asp:ListItem Value="None" Text="None" Selected="True" />
        <asp:ListItem Value="Student" Text="Student" />
        <asp:ListItem Value="Course" Text="Course" />
        <asp:ListItem Value="Instructor" Text="Instructor" />
    </asp:DropDownList>
    <br />
    <label id="lblFilterID" class="ViewControls">Filter ID</label>
    <asp:TextBox ID="txtFilterID" CssClass="ViewControls" ClientIDMode="Static" runat="server" />
    <br />
    <asp:Button ID="btnView" CssClass="ViewControls" ClientIDMode="Static" runat="server" Text="View Data" />
</fieldset>