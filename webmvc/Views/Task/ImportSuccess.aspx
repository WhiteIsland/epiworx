<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.TaskImportModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Import Stories Success
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Imported <span>Stories</span></h2>
    <% this.Html.RenderPartial("TaskListUserControl", new TaskListModel { Tasks = this.Model.Tasks }); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
    <div class="part">
        <h4>
            Things To Do</h4>
        <ul>
            <li class="first last">
                <%: this.Html.ActionLink("Import Stories", "Import", "Task")%></li>
        </ul>
    </div>
</asp:Content>
