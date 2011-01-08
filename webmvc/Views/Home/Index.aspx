<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.HomeIndexModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="part">
        <h2>
            My<span>Tasks</span></h2>
        <% this.Html.RenderPartial("TaskListUserControl", this.Model.Tasks);%>
    </div>
    <div class="part">
        <h2>
            My<span>Hours</span></h2>
        <% this.Html.RenderPartial("HourListUserControl", this.Model.Hours); %>
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
                <%: this.Html.ActionLink("Add a New Task", "Create", "Task")%></li>
            <li class="last">
                <%: this.Html.ActionLink("Add a New Project", "Create", "Project")%></li>
        </ul>
    </div>
</asp:Content>
