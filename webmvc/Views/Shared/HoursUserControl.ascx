<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Epiworx.Business.IHour>>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div class="part">
    <h4>
        Hours</h4>
    <%
        if (this.Model.Count() != 0)
        {
            var dates = this.Model.Select(row => row.Date).OrderBy(row => row.Date).Distinct().ToList();

            for (var index = 0; index < dates.Count(); index++)
            {
                var date = dates[index];
    %>
    <h5<%= this.Html.FirstLastCssClass(index, dates.Count) %>>
        <%: date.ToString("MM.dd.yyyy") %></h5>
    <ul class="name-value">
        <%
                foreach (var hour in this.Model.Where(row => row.Date == date))
                {
        %>
        <li>
            <%: this.Html.ActionLink(hour.Duration.ToString("N2"), "Edit", "Hour", new { id = hour.HourId }, null)%>
            <span>
                <%:hour.UserName%></span></li>
        <%
                }
            }%>
    </ul>
    <%
        }
        else
        {
    %>
    <p class="no-records">
        No hours have been recorded.</p>
    <%
        }
    %>
    <div class="total">
        Total
        <span><%: this.Model.Sum(row => row.Duration).ToString("N2")%></span>
    </div>
</div>
