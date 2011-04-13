<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.ProjectFormModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Edit Project
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (this.Html.BeginForm("Edit", "Project", new { id = this.Model.ProjectId }, FormMethod.Post, new { id = "edit-form" }))
        {
    %>
    <h2>
        Edit<span>Project</span></h2>
    <% this.Html.RenderPartial("ProjectForm"); %>
    <% this.Html.RenderPartial("ProjectFormCommands"); %>
    <% 
        } 
    %>
    <% this.Html.RenderPartial("NotesUserControl", this.Model.NoteListModel); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
    <div class="part">
        <h4>
            Things To Do</h4>
        <ul class="list">
            <li class="first last">
                <%: this.Html.ActionLink("Add a New Sprint", "Create", "Sprint", new { projectId = this.Model.ProjectId}, null)%></li>
        </ul>
    </div>
    <div class="clear">
    </div>
    <% this.Html.RenderPartial("SprintsUserControl", this.Model.Sprints); %>
</asp:Content>
