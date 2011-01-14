<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.TaskListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%
    if (this.Model.Tasks.Count() == 0)
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
            <th>
                No.
            </th>
            <th>
            </th>
            <th style="width: 200px;">
                Project
            </th>
            <th>
                Description
            </th>
            <% if (!this.Model.HideUserColumn)
               {
            %>
            <th style="width: 100px;">
                User
            </th>
            <%
                }
            %>
            <th style="width: 50px; text-align: right;">
                Points
            </th>
        </tr>
    </thead>
    <tbody>
        <% foreach (var task in this.Model.Tasks)
           {
        %>
        <tr>
            <td>
                <%:this.Html.ActionLink(
                    task.TaskId.ToString(), "Edit", "Task", new {id = task.TaskId, title = this.Html.ToTitle(task.Description)}, null)%>
            </td>
            <td>
                <div class="box" style="color: <%= task.Status.ForeColor %>; background-color: <%= task.Status.BackColor %>;">
                    <%: task.StatusName %></div>
            </td>
            <td>
                <%: task.ProjectName %>
            </td>
            <td>
                <p title="<%: task.Description %>">
                    <%: task.Description %></p>
            </td>
            <% if (!this.Model.HideUserColumn)
               {
            %>
            <td>
                <%: task.AssignedToName %>
            </td>
            <%
                }
            %>
            <td style="text-align: right;">
                <%: task.EstimatedDuration.ToString("N0") %>
            </td>
        </tr>
        <%
            }
        %>
    </tbody>
</table>
