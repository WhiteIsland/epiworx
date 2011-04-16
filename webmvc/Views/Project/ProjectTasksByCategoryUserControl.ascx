<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.ProjectTasksByCategoryListModel>" %>
<div class="part">
    <h4>
        Tasks by Categories</h4>
    <ul class="name-value">
        <%
            foreach (var category in this.Model.Categories.OrderBy(row => row.Ordinal))
            {
        %>
        <li>
            <div class="flag <%: category.Name.ToLower().Replace(" ", "-")%>" title="<%: category.Name %>">
            </div>
            <em><a href="<%: Url.Action("Index", "Task", new { projectId = Model.ProjectId, categoryId = category.CategoryId }) %>">
                <%: string.Format(
                "{0}", 
                this.Model.Tasks.Count(row => row.CategoryId == category.CategoryId))%></a></em>
            <span>
                <%: category.Name%></span></li>
        <%
            }%>
    </ul>
 </div>
