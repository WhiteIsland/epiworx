<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.HourListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div class="part">
    <h4>
        Hours by User</h4>
    <ul class="name-value">
        <%
            foreach (var userId in this.Model.Hours.OrderBy(row => row.UserName).Select(row => row.UserId).Distinct())
            {
        %>
        <li>
            <img src="<%: this.Url.Gravatar(this.Model.Hours.Where(row => row.UserId == userId).Take(1).Single().User.Email, 16) %>" /><em>
                <%: string.Format(
                "{0} hours",
                this.Model.Hours.Where(row => row.UserId == userId).Sum(row => row.Duration))%></em>
            <span>
                <%: this.Model.Hours.Where(row => row.UserId == userId).Take(1).Single().UserName %></span></li>
        <%
            }
        %>
    </ul>
    <div class="total">
        Total Hours<span>
            <%: string.Format("{0}", this.Model.Hours.Sum(row => row.Duration))%></span>
    </div>
</div>
