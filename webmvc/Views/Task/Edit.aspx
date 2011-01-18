<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.TaskFormModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Edit Story
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (this.Html.BeginForm("Edit", "Task", new { id = this.Model.TaskId }, FormMethod.Post, new { id = "edit-form" }))
        {
    %>
    <h2>
        Edit<span>Story</span></h2>
    <% this.Html.RenderPartial("TaskForm"); %>
    <% this.Html.RenderPartial("TaskFormCommands"); %>
    <% 
        } 
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
    <div class="part">
        <h4>
            Things To Do</h4>
        <ul>
            <li class="last">
                <%: this.Html.ActionLink("Add a New Hour", "Create", "Hour", new { projectId = this.Model.ProjectId, taskId = this.Model.TaskId }, null)%></li>
        </ul>
    </div>
    <div class="clear">
    </div>
    <% this.Html.RenderPartial("HoursUserControl", this.Model.Hours); %>
</asp:Content>
