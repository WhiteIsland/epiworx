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

    using (this.Html.BeginForm())
    {
%>
<%this.Html.RenderPartial("TaskListCommands", Model);%>
<table class="list task">
    <thead>
        <tr>
            <th style="width: 60px;">
                No.
            </th>
            <th class="flag">
                <div class="flag status" title="Status">
                </div>
            </th>
            <th class="flag">
                <div class="flag category" title="Category">
                </div>
            </th>
            <th class="flag">
                <img src="<%=Url.Content("~/Content/FlagAttachment.png") %>" title="Attachments" />
            </th>
            <th class="flag">
                <img src="<%=Url.Content("~/Content/FlagNote.png") %>" title="Notes" />
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
        <tr<% if (task.Status.IsStarted) {%> class="started"<%}%>>
            <td style="white-space: nowrap;">
                <input type="checkbox" id="TaskId" name="TaskId" value="<%: task.TaskId.ToString() %>" />
                <%:this.Html.ActionLink(
                    task.TaskId.ToString(), "Edit", "Task", new {id = task.TaskId, title = this.Html.ToTitle(task.Description), returnUrl = this.Server.UrlEncode(this.Request.Url.ToString())}, null)%>
            </td>
            <td class="flag">
                <% if (task.IsArchived)
                   {%>
                <div class="flag archived" title="Archived">
                </div>
                <%}
                   else
                   {%>
                <div class="flag <%: task.StatusName.ToLower().Replace(" ", "-")%>" title="<%: task.StatusName %>">
                </div>
                <%}%>
            </td>
            <td class="flag">
                <div class="flag <%: task.CategoryName.ToLower().Replace(" ", "-")%>" title="<%: task.CategoryName %>">
                </div>
            </td>
            <td class="flag">
                <%if (task.NumberOfNotes != 0)
                  {%><img src="<%=Url.Content("~/Content/FlagNote.png") %>" title="Has notes" class="flag" />
                <%}%>
            </td>
            <td class="flag">
                <%if (task.NumberOfAttachments != 0)
                  {%><img src="<%=Url.Content("~/Content/FlagAttachment.png") %>" title="Has attachments"
                      class="flag" />
                <%}%>
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
            <td colspan="<% if (!this.Model.HideUserColumn) {%>8<%} else {%>7<%}%>">
                Total
            </td>
            <td style="text-align: right;">
                <%: this.Model.Tasks.Sum(row => row.Duration).ToString("N2") %>
            </td>
            <td style="text-align: right;">
                <%: this.Model.Tasks.Sum(row => row.EstimatedDuration).ToString("N0") %>
            </td>
        </tr>
    </tfoot>
</table>
<% 
    } 
%>
