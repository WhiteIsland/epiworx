<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.HomeSettingsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Settings
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Settings</h2>
    <p>
        The user can modify their profile settings here</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
    <% Html.RenderPartial("CategoriesUserControl", this.Model.Categories); %>
    <% Html.RenderPartial("StatusesUserControl", this.Model.Statuses); %>
</asp:Content>
