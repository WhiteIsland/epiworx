<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.UserFormModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Edit User
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (this.Html.BeginForm("Edit", "User", new { id = this.Model.UserId }, FormMethod.Post, new { id = "edit-form" }))
        {
    %>
    <h2>
        Edit<span>User</span></h2>
    <% this.Html.RenderPartial("UserForm"); %>
    <% this.Html.RenderPartial("UserFormCommands"); %>
    <% 
        } 
    %>
    <% this.Html.RenderPartial("NotesUserControl", this.Model.NoteListModel); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
