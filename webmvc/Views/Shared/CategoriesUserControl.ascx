<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Epiworx.Business.ICategory>>" %>
<div class="part">
    <h3>
        Categories</h3>
    <ul>
        <%           
            foreach (var category in this.Model)
            {
        %>
        <li>
            <%= this.Html.ActionLink(category.Name, "Edit", "Category", new { id = category.CategoryId, title = category.Description}, null)%>
        </li>
        <% } %>
    </ul>
    <%: this.Html.ActionLink("Add a category", "Create", "Category") %>
</div>
