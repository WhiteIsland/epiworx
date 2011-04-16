<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Epiworx.Business.IUser>>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%
    if (this.Model.Count() == 0)
    {
%>
<p class="no-records">
    No records were found.</p>
<%
        return;
    }
%>
<table class="list user">
    <thead>
        <tr>
            <th style="width: 400px;">
                Name
            </th>
            <th>
                Email
            </th>
        </tr>
    </thead>
    <tbody>
        <% foreach (var user in this.Model)
           {
        %>
        <tr>
            <td>
                <div class="user">
                    <img src="<%: this.Url.Gravatar(user.Email, 64) %>" />
                    <%: this.Html.ActionLink(user.Name, "Edit", "User", new { id = user.UserId }, null) %>
                    <br />
                    <%: user.FirstName %>&nbsp;
                    <%: user.LastName %>
                </div>
            </td>
            <td>
                <%: user.Email %>
            </td>
        </tr>
        <%
           }
        %>
    </tbody>
</table>
