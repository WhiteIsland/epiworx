<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Epiworx.Business.IProject>>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<ul class="list">
    <% foreach (var project in this.Model.OrderBy(row => row.Name))
       {
    %>
    <li>
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
    </li>
    <%
       }
    %>
</ul>
