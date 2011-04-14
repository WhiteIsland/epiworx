<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.ProjectListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<table class="list">
    <thead>
        <tr>
            <th class="flag">
                <div class="flag archived" title="Archived">
                </div>
            </th>
            <th style="width: 400px;">
                Name
            </th>
            <th>
                Status
            </th>
        </tr>
    </thead>
    <tbody>
        <% foreach (var project in this.Model.Projects.OrderBy(row => row.Name))
           {
        %>
        <tr>
            <td class="flag">
                <% if (project.IsArchived)
                   {%>
                <div class="flag archived" title="Archived">
                </div>
                <%}
                   else
                   {%>
                <div class="flag not-archived" title="Not archived">
                </div>
                <%}%>
            </td>
            <td>
                <%:this.Html.ActionLink(
                project.Name, "Edit", "Project",
                    new
                    {
                        id = project.ProjectId,
                        title = this.Html.ToTitle(project.Name)
                    }, null)%>
                <% if (!string.IsNullOrEmpty(project.Description))
                   {
                %>
                <p title="<%: project.Description %>">
                    <%: project.Description %></p>
                <%
                   }
                %>
            </td>
            <td class="note">
                <%
               if (Model.Notes.Count() != 0)
               {
                   var notes = Model.Notes
                       .Where(note => note.SourceId == project.ProjectId)
                       .OrderByDescending(note => note.CreatedDate);

                   if (notes.Count() != 0)
                   {
                       var note = notes.First(); 
                %>
                <p title="<%: note.Body %>">
                    <%: note.Body %></p>
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
