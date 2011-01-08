<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.ProjectIndexModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Projects
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <span>Projects</span></h2>
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
            this.Html.RenderPartial("ProjectListUserControl", this.Model.Projects);%>
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
                <%: this.Html.ActionLink("Add a New Project", "Create", "Project") %></li>
        </ul>
    </div>
</asp:Content>
