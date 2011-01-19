<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.FilterFormModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Edit Filter
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (this.Html.BeginForm("Edit", "Filter", new { id = this.Model.FilterId }, FormMethod.Post, new { id = "edit-form" }))
        {
    %>
     <h2>
        Edit<span>Filter</span></h2>
    <% this.Html.RenderPartial("FilterForm"); %>
    <% this.Html.RenderPartial("FilterFormCommands"); %>
    <% 
        } 
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
