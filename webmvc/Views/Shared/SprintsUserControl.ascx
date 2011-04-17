<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Epiworx.Business.ISprint>>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div class="part">
    <h4>
        Sprints</h4>
    <% if (this.Model.Count() == 0)
       {%>
    <p class="no-records">
        No sprints have been recorded.</p>
    <% }
       else
       {%>
    <ul>
        <%
           foreach (var sprint in this.Model)
           {
        %>
        <li>
            <div class="flag sprint"></div>
            <%= this.Html.ActionLink("Edit", "Edit", "Sprint", new { id = sprint.SprintId, title = this.Html.ToTitle(sprint.Name) }, new { @class = "action" })%>
            <%= this.Html.ActionLink(sprint.Name, "Index", "Task", new {sprintId = sprint.SprintId}, null)%>
            <%= this.Html.CompletedBox(sprint.IsCompleted) %>
        </li>
        <%
           }
        %>
    </ul>
    <%
       }
    %>
</div>
