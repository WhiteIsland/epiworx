<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.ProjectListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<table class="list">
    <thead>
        <tr>
             <th class="flag">
                <div class="flag archived" title="Archived"></div>
            </th>
            <th>
                No.
            </th>
        </tr>
    </thead>
    <tbody>
        <% foreach (var project in this.Model.Projects.OrderBy(row => row.Name))
           {
        %>
        <tr>
            <td class="flag">
             <% if (project.IsArchived) {%> 
                <div class="flag archived" title="Archived"></div>
            <%} else {%>
                <div class="flag not-archived" title="Not archived"></div>
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
                <p>
                    <%: project.Description %></p>
                <%
               }
                %>
            </td>
        </tr>
        <%
           }
        %>
    </tbody>
</table>
