<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NTiers.WebForm.Home" %>
<%@ Register Src="~/ControlsView.ascx" TagPrefix="Controls" TagName="View" %>
<%@ Register Src="~/ControlsInsert.ascx" TagPrefix="Controls" TagName="Insert" %>
<%@ Register Src="~/ControlsDelete.ascx" TagPrefix="Controls" TagName="Delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>NTiers Application</title>
    <link href="Styles/Home.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="ControlsWrapper">
            <label id="lblTables">Table: </label>
            <asp:DropDownList ID="ddlTables" ClientIDMode="Static" runat="server">
                <asp:ListItem Value="None" Text="None" Selected="True" />
            </asp:DropDownList>
            <br />
            <div class="ViewContolsDiv">
                <Controls:View runat="server"></Controls:View>
            </div>
            <div>
                <Controls:Insert runat="server"></Controls:Insert>
            </div>
            <div>
                <Controls:Delete runat="server"></Controls:Delete>
            </div>
        </div>
    </form>
</body>
</html>
