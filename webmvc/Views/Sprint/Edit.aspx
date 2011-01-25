<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.SprintFormModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Edit Sprint
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (this.Html.BeginForm("Edit", "Sprint", new { id = this.Model.SprintId }, FormMethod.Post, new { id = "edit-form" }))
        {
    %>
     <h2>
        Edit<span>Sprint</span></h2>
    <% this.Html.RenderPartial("SprintForm"); %>
    <% this.Html.RenderPartial("SprintFormCommands"); %>
    <% 
        } 
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
