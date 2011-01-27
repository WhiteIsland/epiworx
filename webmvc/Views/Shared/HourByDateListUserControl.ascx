<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.HourByDateListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div class="part">
    <h4>
        Hours by Day</h4>
    <ul class="name-value">
        <%
            while (this.Model.StartDate <= this.Model.EndDate)
            {
        %>
        <li>
            <div class="box">
            </div>
            <em>
                <%: string.Format("{0} hours", this.Model.Hours.Where(row => row.Date == this.Model.StartDate).Sum(row => row.Duration))%></em>
            <span>
                <%: this.Model.StartDate.ToString("ddd d")%></span></li>
        <%
this.Model.StartDate = this.Model.StartDate.AddDays(1);
            }
        %>
    </ul>
    <div class="total">
        Total Hours<span>
            <%: string.Format("{0}", this.Model.Hours.Sum(row => row.Duration))%></span>
    </div>
</div>
