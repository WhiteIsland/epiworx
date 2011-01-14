<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.HourListModel>" %>
<%
    if (this.Model.Hours.Count() == 0)
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
            <th style="width: 100px;">
                Date
            </th>
            <% if (!this.Model.HideUserColumn)
               {
            %>
            <th style="width: 200px;">
                User
            </th>
            <%
                }
            %>
            <th style="width: 200px;">
                Project
            </th>
            <th style="width: 100px;">
                Task
            </th>
            <th>
                Notes
            </th>
            <th style="width: 100px; text-align: right;">
                Duration
            </th>
        </tr>
    </thead>
    <tbody>
        <% foreach (var hour in this.Model.Hours)
           {
        %>
        <tr>
            <td>
                <%: this.Html.ActionLink(hour.Date.ToString("MM.dd.yyyy"), "Edit", "Hour", new { id = hour.HourId }, null) %>
            </td>
            <% if (!this.Model.HideUserColumn)
               {
            %>
            <td>
                <%: hour.UserName %>
            </td>
            <%
                }
            %>
            <td>
                <%: hour.ProjectName %>
            </td>
            <td>
                <%: hour.TaskId %>
            </td>
            <td>
                <p>
                    <%: hour.Notes %></p>
            </td>
            <td style="text-align: right;">
                <%: hour.Duration %>
            </td>
        </tr>
        <%
            }
        %>
    </tbody>
</table>
