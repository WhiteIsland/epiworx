<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.FilterFormModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Add Filter
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (this.Html.BeginForm("Create", "Filter", null, FormMethod.Post, new { id = "edit-form" }))
        {
    %>
    <h2>
        Add<span>Filter</span></h2>
    <% this.Html.RenderPartial("FilterForm"); %>
    <% this.Html.RenderPartial("FilterFormCommands"); %>
    <% 
        } 
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
