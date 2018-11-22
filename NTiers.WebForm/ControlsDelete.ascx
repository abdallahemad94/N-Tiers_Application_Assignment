<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlsDelete.ascx.cs" Inherits="NTiers.WebForm.ControlsDelete" %>

<fieldset>
    <legend>Delete</legend>
    <label id="lblDeleteID" class="DeleteControls">Delete ID</label>
    <asp:TextBox ID="txtDeleteID" CssClass="DeleteControls" ClientIDMode ="static" runat="server" />
    <br />
    <asp:Button ID="btnDelete" CssClass="DeleteControls" ClientIDMode="Static" runat="server" Text="Delete Item" />
</fieldset>