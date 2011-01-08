<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.ModelBase>" %>
<%
    if (this.Request.IsAuthenticated)
    {
%>
<div id="navigation">
        <% Html.RenderPartial("FindUserControl"); %>
    <ul>
        <li<% if (this.Model.SelectedTab == "Home") {%> class="selected"<%}%>><%: this.Html.ActionLink("Home", "Index", "Home")%></li>
        <li<% if (this.Model.SelectedTab == "Task") {%> class="selected"<%}%>><%: this.Html.ActionLink("Tasks", "Index", "Task")%></li>
        <li<% if (this.Model.SelectedTab == "Project") {%> class="selected"<%}%>><%: this.Html.ActionLink("Projects", "Index", "Project")%></li>
        <li<% if (this.Model.SelectedTab == "Hour") {%> class="selected"<%}%>><%: this.Html.ActionLink("Hours", "Index", "Hour")%></li>
        <li<% if (this.Model.SelectedTab == "User") {%> class="selected"<%}%>><%: this.Html.ActionLink("Users", "Index", "User")%></li>
    </ul>
</div>
<%
    }
%>
