<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.ProjectIndexModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%@ Import Namespace="Epiworx.WebMvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Projects
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Projects</h2>
    <%this.Html.RenderPartial("ProjectFilter", this.Model);%>
    <%
        if (this.Model.Projects.Count() == 0)
        {
    %>
    <p class="no-records">
        No records were found.</p>
    <%
        }
        else
        { 
    %>
    <%
            this.Html.RenderPartial("ProjectListUserControl", new ProjectListModel { Projects = Model.Projects, Notes = Model.Notes });%>
    <%
        }             
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
    <div class="part">
        <h4>
            Things To Do</h4>
        <ul class="list">
            <li>
                <div class="flag project">
                </div>
                <%: this.Html.ActionLink("Add a New Project", "Create", "Project") %></li>
        </ul>
    </div>
</asp:Content>
