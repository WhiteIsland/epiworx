<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.ModelBase>" %>
<%@ Import Namespace="Epiworx.Business" %>
<%
    if (this.Request.IsAuthenticated)
    {
%>
<div id="navigation">
    <% Html.RenderPartial("FindUserControl"); %>
    <ul>
        <li<% if (this.Model.Tab == "Home") {%> class="selected" <%}%>><%: this.Html.ActionLink("Home", "Index", "Home")%></li>
        <li<% if (this.Model.Tab == "Project") {%> class="selected"<%}%>><%: this.Html.ActionLink("Projects", "Index", "Project", new { isArchived = 1}, null)%></li>
        <li<% if (this.Model.Tab == "Task") {%> class="selected"<%}%>><%: this.Html.ActionLink("Stories", "Index", "Task", new { isArchived = 1 }, null)%></li>
        <li<% if (this.Model.Tab == "Hour") {%> class="selected"<%}%>><%: this.Html.ActionLink("Hours", "Index", "Hour", new { isArchived = 1 }, null)%></li>
        <li<% if (this.Model.Tab == "Invoice") {%> class="selected"<%}%>><%: this.Html.ActionLink("Invoices", "Index", "Invoice")%></li>
        <li<% if (this.Model.Tab == "User") {%> class="selected"<%}%>><%: this.Html.ActionLink("Users", "Index", "User", new { isArchived = 1 }, null)%></li>
</ul>
</div>
<%
    }
%>
