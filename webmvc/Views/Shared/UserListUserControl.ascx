<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Epiworx.Business.IUser>>" %>
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
<table class="list">
    <thead>
        <tr>
            <th style="width: 200px;">
                Name
            </th>
            <th style="width: 200px;">
                Full Name
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
                <%: this.Html.ActionLink(user.Name, "Edit", "User", new { id = user.UserId }, null) %>
            </td>
            <td>
                <%: user.FirstName %>&nbsp;
                <%: user.LastName %>
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
