<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.HomeIndexModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <ul>
            <li>
                <%: this.Html.ActionLink("Me", "Index", "Home") %></li>
            <li>
                <%: this.Html.ActionLink("Team", "Index", "Home", new { dashboard = "Team" }, null)%></li>
        </ul>
        Dashboard</h2>
    <div class="part">
        <h3>
            <%: Model.Dashboard %><span>Open Stories</span></h3>
        <% this.Html.RenderPartial("TaskListUserControl", new TaskListModel { Tasks = this.Model.Tasks.Where(row => row.CompletedDate.Date == DateTime.MaxValue.Date), HideUserColumn = true });%>
    </div>
    <div class="part">
        <h3>
            <%: Model.Dashboard %><span>Completed Stories</span></h3>
        <% this.Html.RenderPartial("TaskListUserControl", new TaskListModel { Tasks = this.Model.Tasks.Where(row => row.CompletedDate.Date != DateTime.MaxValue.Date), HideUserColumn = true });%>
    </div>
    <div class="part">
        <h3>
            <%: Model.Dashboard %><span>Hours for This Week</span></h3>
        <% this.Html.RenderPartial("HourListUserControl", new HourListModel { Hours = this.Model.Hours, HideUserColumn = true }); %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
    <div class="part">
        <h4>
            Things To Do</h4>
        <ul class="list">
            <li>
                <div class="flag hour">
                </div>
                <%: this.Html.ActionLink("Add a New Hour", "Create", "Hour") %></li>
            <li>
                <div class="flag story">
                </div>
                <%: this.Html.ActionLink("Add a New Story", "Create", "Task")%></li>
            <li>
                <div class="flag project">
                </div>
                <%: this.Html.ActionLink("Add a New Project", "Create", "Project")%></li>
        </ul>
    </div>
    <% this.Html.RenderPartial("FeedsUserControl", new FeedListModel() { Feeds = this.Model.Feeds });%>
    <% this.Html.RenderPartial("HourByDateListUserControl", new HourByDateListModel() { Hours = this.Model.Hours, StartDate = this.Model.StartDate, EndDate = this.Model.EndDate });%>
</asp:Content>
