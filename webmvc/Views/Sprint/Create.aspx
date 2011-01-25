<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.SprintFormModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Add Sprint
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (this.Html.BeginForm("Create", "Sprint", null, FormMethod.Post, new { id = "edit-form" }))
        {
    %>
    <h2>
        Add<span>Sprint</span></h2>
    <% this.Html.RenderPartial("SprintForm"); %>
    <% this.Html.RenderPartial("SprintFormCommands"); %>
    <% 
        } 
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
