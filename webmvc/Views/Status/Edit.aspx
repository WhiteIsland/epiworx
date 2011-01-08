<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.StatusFormModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Edit Status
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <%
        using (this.Html.BeginForm("Edit", "Status", new { id = this.Model.StatusId }, FormMethod.Post, new { id = "edit-form" }))
        {
    %>
    <h2>
        Edit<span>Status</span></h2>
    <% this.Html.RenderPartial("StatusForm"); %>
    <% this.Html.RenderPartial("StatusFormCommands"); %>
    <% 
        } 
    %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
