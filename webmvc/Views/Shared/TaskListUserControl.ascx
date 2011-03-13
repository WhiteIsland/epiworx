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
            <th style="width: 60px;">
                <div class="box" title="Status">
                </div>
                <div class="box" title="Category">
                </div>
                <div class="box last" title="Archived">
                </div>
            </th>
            <th>
                No.
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
                Actual
            </th>
            <th style="width: 50px; text-align: right;">
                Estimate
            </th>
        </tr>
    </thead>
    <tbody>
        <% foreach (var task in this.Model.Tasks)
           {
        %>
        <tr>
            <td>
                <div class="box" style="color: <%= task.Status.ForeColor %>; background-color: <%= task.Status.BackColor %>;"
                    title="<%: task.StatusName %>">
                </div>
                <div class="box" style="color: <%= task.Category.ForeColor %>; background-color: <%= task.Category.BackColor %>;"
                    title="<%: task.CategoryName %>">
                </div>
                <% if (task.IsArchived)
                   {
                %><div class="box last archived" title="archived" />
                <%
                   }
                   else
                   {
                %>
                <div class="box last not-archived" title="not archived" />
                <%
                   }
                %>
            </td>
            <td>
                <%:this.Html.ActionLink(
                    task.TaskId.ToString(), "Edit", "Task", new {id = task.TaskId, title = this.Html.ToTitle(task.Description), returnUrl = this.Server.UrlEncode(this.Request.Url.ToString())}, null)%>
            </td>
            <td>
                <%: task.ProjectName %>
            </td>
            <td>
                <% if (task.NumberOfNotes > 0)
                   {%>
                <div class="box note" title="has (<%= task.NumberOfNotes %>) notes">
                    N</div>
                <%}%>
                <% if (task.NumberOfAttachments > 0)
                   {%>
                <div class="box attachment" title="has (<%= task.NumberOfAttachments %>) attachments">
                    A</div>
                <%}%>
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
                <%: task.Duration.ToString("N2") %>
            </td>
            <td style="text-align: right;">
                <%: task.EstimatedDuration.ToString("N0") %>
            </td>
        </tr>
        <%
           }
        %>
    </tbody>
    <tfoot>
        <tr>
           <td colspan="<% if (!this.Model.HideUserColumn) {%>5<%} else {%>4<%}%>">Total</td>
           <td style="text-align: right;">
                <%: this.Model.Tasks.Sum(row => row.Duration).ToString("N2") %>
            </td>
            <td style="text-align: right;">
                <%: this.Model.Tasks.Sum(row => row.EstimatedDuration).ToString("N0") %>
            </td>
        </tr>
    </tfoot>
</table>
