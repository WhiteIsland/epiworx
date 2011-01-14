<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.HourIndexModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>

<%@ Import Namespace="Epiworx.WebMvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Hours
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <span>Hours</span></h2>
    <% this.Html.RenderPartial("HourFilter", this.Model);%>
    <% this.Html.RenderPartial("HourListUserControl", new HourListModel { Hours = this.Model.Hours });%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
    <div class="part">
        <h4>
            Things To Do</h4>
        <ul>
            <li class="first last">
                <%: this.Html.ActionLink("Add a New Hour", "Create", "Hour")%></li>
        </ul>
    </div>
</asp:Content>
