<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.TaskFindModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Find Story
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (this.Html.BeginForm("Index", "Task", FormMethod.Get))
        {
    %>
    <h2>
        Find<span>Story</span></h2>
    <fieldset>
        <p class="span1">
            <%: this.Html.LabelFor(m => m.ProjectId) %>
            <%: this.Html.ProjectDropDownListFor(m => m.ProjectId, this.Model.Projects, this.Model.ProjectId)%>
        </p>
        <p class="span1">
            <%: this.Html.LabelFor(m => m.StatusId) %>
            <%: this.Html.StatusDropDownListFor(m => m.StatusId, this.Model.Statuses, this.Model.StatusId)%>
        </p>
        <p class="span1">
            <%: this.Html.LabelFor(m => m.CategoryId) %>
            <%: this.Html.CategoryDropDownListFor(m => m.CategoryId, this.Model.Categories, this.Model.CategoryId)%>
        </p>
        <div class="clear">
        </div>
        <p class="span1">
            <%: this.Html.LabelFor(m => m.AssignedTo) %>
            <%: this.Html.UserDropDownListFor(m => m.AssignedTo, this.Model.Users, this.Model.AssignedTo)%>
        </p>
        <div class="clear">
        </div>
        <p class="span2">
            <label for="CompletedDateFrom">
                Select a completed date range:</label>
            <%: this.Html.TextBox("CompletedDateFrom", string.Empty, new { @class = "date"}) %>
            <span>&nbsp;to&nbsp;</span>
            <%: this.Html.TextBox("CompletedDateTo", string.Empty, new { @class = "date"}) %>
        </p>
        <div class="clear">
        </div>
        <p class="span2">
            <label for="ModifiedDateFrom">
                Select a modified date range:</label>
            <%: this.Html.TextBox("ModifiedDateFrom", string.Empty, new { @class = "date"}) %>
            <span>&nbsp;to&nbsp;</span>
            <%: this.Html.TextBox("ModifiedDateTo", string.Empty, new { @class = "date" })%>
        </p>
        <div class="clear">
        </div>
        <p class="span2">
            <label for="CreatedDateFrom">
                Select a created date range:</label>
            <%: this.Html.TextBox("CreatedDateFrom", string.Empty, new { @class = "date" })%>
            <span>&nbsp;to&nbsp;</span>
            <%: this.Html.TextBox("CreatedDateTo", string.Empty, new { @class = "date" })%>
        </p>
        <div class="clear">
        </div>
    </fieldset>
    <div class="commands">
        <ul>
            <li>
                <input type="submit" value="Find" /></li>
        </ul>
    </div>
    <% 
        } 
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
