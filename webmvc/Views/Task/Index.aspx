<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.TaskIndexModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Tasks
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <span>Tasks</span></h2>
     <%this.Html.RenderPartial("TaskFilter", this.Model);%>
     <%this.Html.RenderPartial("TaskListUserControl", this.Model.Tasks);%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
    <div class="part">
        <h4>
            Things To Do</h4>
        <ul>
            <li class="first">
                <%: this.Html.ActionLink("Add a Task", "Create", "Task") %></li>
            <li class="last">
                <%: this.Html.ActionLink("Add a Project", "Create", "Project") %></li>
        </ul>
    </div>
    <% this.Html.RenderPartial("ProjectsUserControl", this.Model.Projects); %>
</asp:Content>
