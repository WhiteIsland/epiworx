<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.ProjectTasksByStatusListModel>" %>
<div class="part">
    <h4>
        Tasks by Statuses</h4>
    <ul class="name-value">
        <%
            foreach (var status in this.Model.Statuses.OrderBy(row => row.Ordinal))
            {
        %>
        <li><div class="flag <%: status.Name.ToLower().Replace(" ", "-")%>" title="<%: status.Name %>"></div><em>
            <a href="<%: Url.Action("Index", "Task", new { projectId = Model.ProjectId, statusId = status.StatusId }) %>"><%: string.Format(
                "{0}",
                this.Model.Tasks.Count(row => row.StatusId == status.StatusId))%></a></em>
            <span>
                <%: status.Name%></span></li>
        <%
            }%>
    </ul>
   <div class="total">
     Total<span><a href="<%: Url.Action("Index", "Task", new { projectId = Model.ProjectId }, null) %>"><%: string.Format("{0:N0}", this.Model.Tasks.Count())%></a></span>
      </div>
</div>
