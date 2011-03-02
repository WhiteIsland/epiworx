<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="Epiworx.Security" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div id="profile">
    <% if (this.Request.IsAuthenticated)
       {
           var user = (BusinessIdentity)Csla.ApplicationContext.User.Identity;

    %>
    <img src="<%: this.Url.Gravatar(user.Email) %>" />
    <span><%: user.FirstName %>&nbsp;<%: user.LastName %></span>
    <%
       }
       else
       {
    %>
    <img src="<%: this.Url.Content("~/Content/Profile.png") %>" alt="No Profile" />
    <%
       }
    %>
</div> 