<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.HourListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div class="part">
    <h4>
        Hours by User</h4>
    <ul class="name-value">
        <%
            foreach (var projectId in this.Model.Hours.OrderBy(row => row.ProjectName).Select(row => row.ProjectId).Distinct())
            {
        %>
        <li>
            <em>
                <%: string.Format(
                "{0} hours",
                this.Model.Hours.Where(row => row.ProjectId == projectId).Sum(row => row.Duration))%></em>
            <span>
                <%: this.Model.Hours.Where(row => row.ProjectId == projectId).Take(1).Single().ProjectName%></span></li>
        <%
            }
        %>
    </ul>
    <div class="total">
        Total Hours<span>
            <%: string.Format("{0}", this.Model.Hours.Sum(row => row.Duration))%></span>
    </div>
</div>
