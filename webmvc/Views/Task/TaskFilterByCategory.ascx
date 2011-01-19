<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.TaskIndexModel>" %>
<div class="filter-value filter-value-multiple">
    and is <strong title="<%: this.Model.CategoryName %>">
        <%: this.Model.CategoryDisplayName %>
    </strong>
    <div class="filter-value-multiple-container">
        <ul>
            <% 
                foreach (var category in this.Model.Categories)
                {
            %>
            <li>
                <label>
                    <input type="checkbox" id="CategoryId" name="CategoryId" <%if (this.Model.CategoryId.Contains(category.CategoryId)) { %>
                        checked="checked" <%} %> value="<%= category.CategoryId.ToString() %>" />
                    <%: category.Name %></label>
            </li>
            <%
                }
            %>
        </ul>
        <div class="commands">
            <ul>
                <li>
                    <input type="submit" value="Apply" /></li>
                <li><a href="javascript:void(0);">Close</a></li></ul>
        </div>
    </div>
</div>
