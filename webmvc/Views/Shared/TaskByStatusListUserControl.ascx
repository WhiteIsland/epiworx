<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.TaskByStatusListModel>" %>
<div class="part">
    <h4>
        Tasks by Statuses</h4>
    <ul class="name-value">
        <%
            foreach (var status in this.Model.Statuses.OrderBy(row => row.Ordinal))
            {
        %>
        <li><div class="box" style="color: <%= status.ForeColor %>; background-color: <%= status.BackColor %>;">
                    </div><em>
            <%: string.Format(
                "{0} at {1:N0} points",
                this.Model.Tasks.Count(row => row.StatusId == status.StatusId),
                this.Model.Tasks.Where(row => row.StatusId == status.StatusId).Sum(row => row.EstimatedDuration))%></em>
            <span>
                <%: status.Name%></span></li>
        <%
            }%>
    </ul>
   <div class="total">
        Total Points<span>
            <%: string.Format("{0:N0}", this.Model.Tasks.Sum(row => row.EstimatedDuration))%></span>
    </div>
</div>
