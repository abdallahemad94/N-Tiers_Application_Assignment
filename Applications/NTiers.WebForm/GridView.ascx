<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GridView.ascx.cs" Inherits="NTiers.WebForm.GridView" %>
<asp:UpdatePanel ID="UpdatePanel" runat="server">
    <ContentTemplate>
        <asp:GridView ID="Grid" ClientIDMode="Static" runat="server"></asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>