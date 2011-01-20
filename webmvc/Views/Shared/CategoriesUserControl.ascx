<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Epiworx.Business.ICategory>>" %>
<div class="part">
    <h4>
        Categories</h4>
    <ul>
        <%           
            foreach (var category in this.Model)
            {
        %>
        <li>
            <%= this.Html.ActionLink(category.Name, "Edit", "Category", new { id = category.CategoryId, title = category.Name}, null)%>
        </li>
        <% } %>
        <li>
            <%: this.Html.ActionLink("Add a New Category...", "Create", "Category")%></li>
    </ul>
</div>
