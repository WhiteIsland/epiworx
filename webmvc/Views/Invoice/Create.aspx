<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.InvoiceFormModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Add Invoice
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (this.Html.BeginForm("Create", "Invoice", new { taskId = Model.TaskId }, FormMethod.Post, new { id = "edit-form" }))
        {
    %>
    <h2>
        Add<span>Invoice</span></h2>
    <% this.Html.RenderPartial("InvoiceForm"); %>
    <% this.Html.RenderPartial("InvoiceFormCommands"); %>
    <% 
        } 
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
