<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.HourFormModel>" %>

<%@ Import Namespace="Epiworx.Business" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Edit Hour
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (this.Html.BeginForm("Edit", "Hour", new { id = this.Model.HourId }, FormMethod.Post, new { id = "edit-form" }))
        {
    %>
    <h2>
        Edit<span>Hour</span></h2>
    <% this.Html.RenderPartial("HourForm"); %>
    <% this.Html.RenderPartial("HourFormCommands"); %>
    <% 
        } 
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
    <div class="part">
        <h4>
            Things To Do</h4>
        <ul>
            <li>
                <%: this.Html.ActionLink("Convert to Task", "Create", "Task", new { hourId = this.Model.HourId }, null)%></li>
        </ul>
    </div>
    <div class="clear">
    </div>
</asp:Content>
