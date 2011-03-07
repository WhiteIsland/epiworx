<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.TaskIndexModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%@ Import Namespace="Epiworx.WebMvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Tasks
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Stories</h2>
    <%this.Html.RenderPartial("TaskFilter", this.Model);%>
    <%this.Html.RenderPartial("TaskListUserControl", this.Model);%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
    <div class="part">
        <h4>
            Things To Do</h4>
        <ul class="list">
            <li class="first">
                <%: this.Html.ActionLink("Add a New Story", "Create", "Task", new { returnUrl = this.Server.UrlEncode(this.Request.Url.ToString())}, null) %></li>
            <li>
                <%: this.Html.ActionLink("Add a New Project", "Create", "Project")%></li>
            <li>
                <a href="<%: this.Url.Action("Export") %>?<%= this.Request.QueryString %>">Export Stories</a></li>
            <li class="last">
                <%: this.Html.ActionLink("Import Stories", "Import", "Task")%></li>
        </ul>
    </div>
    <% this.Html.RenderPartial("FiltersUserControl", new FilterListModel { Target = "Task", Filters = this.Model.Filters });%>
    <% this.Html.RenderPartial("TaskByCategoryListUserControl", new TaskByCategoryListModel { Tasks = this.Model.Tasks, Categories = this.Model.Categories }); %>
    <% this.Html.RenderPartial("TaskByStatusListUserControl", new TaskByStatusListModel { Tasks = this.Model.Tasks, Statuses = this.Model.Statuses }); %>
    <% this.Html.RenderPartial("LabelsByCountUserControl", this.Model.LabelByCountListModel); %>
    <% this.Html.RenderPartial("ProjectsUserControl", this.Model.Projects); %>
</asp:Content>
