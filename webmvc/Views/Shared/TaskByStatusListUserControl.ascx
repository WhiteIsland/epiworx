<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.TaskByStatusListModel>" %>
<div class="part">
    <h4>
        Tasks by Categories</h4>
    <ul class="name-value">
        <%
            foreach (var status in this.Model.Statuses.OrderBy(row => row.Ordinal))
            {
        %>
        <li>
            <em><%: this.Model.Tasks.Count(row => row.StatusId == status.StatusId) %></em>
            <span>
                <%: status.Name%></span></li>
        <%
            }%>
    </ul>
</div>
