<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.UserIndexModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Users
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Users</h2>
    <% this.Html.RenderPartial("UserListUserControl", this.Model.Users);%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
    <div class="part">
        <h4>
            Things To Do</h4>
        <ul>
            <li class="first last">
                <%: this.Html.ActionLink("Add a New User", "Create", "User")%></li>
        </ul>
    </div>
</asp:Content>
