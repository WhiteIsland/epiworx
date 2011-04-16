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
<%
    using (this.Html.BeginForm())
    {
%>
<div class="list-commands">
    <button value="Archive">
        Archive</button>
    <button value="Unarchive">
        Unarchive</button>
    <%:Html.Hidden("Action")%>
</div>
<table class="list">
    <thead>
        <tr>
            <th style="width: 100px;">
                Date
            </th>
            <th class="flag">
                <div class="flag archived" title="Archived">
                </div>
            </th>
            <th style="width: 200px;">
                User
            </th>
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
        <%
        foreach (var hour in this.Model.Hours)
        {
        %>
        <tr>
            <td style="white-space: nowrap;">
                <input type="checkbox" id="HourId" name="HourId" value="<%: hour.HourId.ToString() %>" />
                <%:this.Html.ActionLink(hour.Date.ToString("MM.dd.yyyy"), "Edit", "Hour",
                                                   new {id = hour.HourId}, null)%>
            </td>
            <td class="flag">
                <%
            if (hour.IsArchived)
            {%>
                <div class="flag archived" title="Archived">
                </div>
                <%
            }
            else
            {%>
                <div class="flag not-archived" title="Not archived">
                </div>
                <%
            }%>
            </td>
             <td>
                <%:hour.UserName%>
            </td>
            <td>
                <%:hour.ProjectName%>
            </td>
            <td>
                <%
            if (hour.TaskId != 0)
            {
                %>
                <%:hour.TaskId.ToString()%>
                <%
            }
            else
            {
                %>
                &nbsp;
                <%
            }
                %>
            </td>
            <td>
                <p>
                    <%:hour.Notes%></p>
            </td>
            <td style="text-align: right;">
                <%:hour.Duration%>
            </td>
        </tr>
        <%
        }
        %>
    </tbody>
</table>
<%
    }
%>