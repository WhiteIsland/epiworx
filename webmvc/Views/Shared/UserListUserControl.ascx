<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.UserListModel>" %>
<%@ Import Namespace="Epiworx.Core" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<table class="list user">
    <thead>
        <tr>
            <th style="width: 400px;">
                Name
            </th>
            <th>
                Email
            </th>
            <th>
                Status
            </th>
        </tr>
    </thead>
    <tbody>
        <% foreach (var user in this.Model.Users.OrderBy(row => row.Name))
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
            <td class="note">
                <%
               if (Model.Notes.Count() != 0)
               {
                   var notes = Model.Notes
                       .Where(note => note.SourceId == user.UserId)
                       .OrderByDescending(note => note.CreatedDate);

                   if (notes.Count() != 0)
                   {
                       var note = notes.First();
                %>
                <p title="<%: note.Body %>">
                    <%: note.Body %></p>
                   <%= note.CreatedDate.ToLabel() %>
                <img src="<%: this.Url.Gravatar(note.CreatedByEmail, 64) %>" alt="<%: note.CreatedByName %>" />
                <strong>
                    <%: note.CreatedByName %></strong><em><%: note.CreatedDate.ToRelativeDate() %></em>
                 <%
                   }
               }
                %>
            </td>
        </tr>
        <%
           }
        %>
    </tbody>
</table>
