<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.InvoiceFormModel>" %>
<%@ Import Namespace="Epiworx.Business" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Edit Invoice
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (this.Html.BeginForm("Edit", "Invoice", new { id = this.Model.InvoiceId }, FormMethod.Post, new { id = "edit-form" }))
        {
    %>
    <h2>
        Edit<span>Invoice</span></h2>
    <% this.Html.RenderPartial("InvoiceForm"); %>
    <% this.Html.RenderPartial("InvoiceFormCommands"); %>
    <% 
        } 
    %>
    <% this.Html.RenderPartial("NotesUserControl", this.Model.NoteListModel); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
