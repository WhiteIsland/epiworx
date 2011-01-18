<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.TaskByCategoryListModel>" %>
<div class="part">
    <h4>
        Tasks by Categories</h4>
    <ul class="name-value">
        <%
            foreach (var category in this.Model.Categories.OrderBy(row => row.Ordinal))
            {
        %>
        <li><div class="box" style="color: <%= category.ForeColor %>; background-color: <%= category.BackColor %>;">
                    </div><em>
            <%: string.Format(
                "{0} at {1:N0} points", 
                this.Model.Tasks.Count(row => row.CategoryId == category.CategoryId),
                this.Model.Tasks.Where(row => row.CategoryId == category.CategoryId).Sum(row => row.EstimatedDuration))%></em>
            <span>
                <%: category.Name%></span></li>
        <%
            }%>
    </ul>
</div>
