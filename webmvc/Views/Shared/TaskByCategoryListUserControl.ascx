<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.TaskByCategoryListModel>" %>
<div class="part">
    <h4>
        Tasks by Categories</h4>
    <ul class="name-value">
        <%
            foreach (var category in this.Model.Categories.OrderBy(row => row.Ordinal))
            {
        %>
        <li><em>
            <%: this.Model.Tasks.Count(row => row.CategoryId == category.CategoryId)%></em>
            <span>
                <%: category.Name%></span></li>
        <%
            }%>
    </ul>
</div>
