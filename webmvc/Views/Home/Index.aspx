<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.HomeIndexModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="part">
        <h2>
            My<span>Open Stories</span></h2>
        <% this.Html.RenderPartial("TaskListUserControl", new TaskListModel { Tasks = this.Model.Tasks.Where(row => row.CompletedDate.Date == DateTime.MaxValue.Date), HideUserColumn = true });%>
    </div>
    <div class="part">
        <h2>
            My<span>Completed Stories</span></h2>
        <% this.Html.RenderPartial("TaskListUserControl", new TaskListModel { Tasks = this.Model.Tasks.Where(row => row.CompletedDate.Date != DateTime.MaxValue.Date), HideUserColumn = true });%>
    </div>
    <div class="part">
        <h2>
            My<span>Hours for This Week</span></h2>
        <% this.Html.RenderPartial("HourListUserControl", new HourListModel { Hours = this.Model.Hours, HideUserColumn = true }); %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
    <div class="part">
        <h4>
            Things To Do</h4>
        <ul>
            <li class="first">
                <%: this.Html.ActionLink("Add a New Hour", "Create", "Hour") %></li>
            <li>
                <%: this.Html.ActionLink("Add a New Story", "Create", "Task")%></li>
            <li class="last">
                <%: this.Html.ActionLink("Add a New Project", "Create", "Project")%></li>
        </ul>
    </div>
</asp:Content>
