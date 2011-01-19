<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.TaskIndexModel>" %>
<div class="filter-value filter-value-multiple">
    assigned to <strong title="<%: this.Model.AssignedToName %>">
        <%: this.Model.AssignedToDisplayName %>
    </strong>
    <div class="filter-value-multiple-container">
        <ul>
            <% 
                foreach (var user in this.Model.AssignedToUsers)
                {
            %>
            <li>
                <label>
                    <input type="checkbox" id="AssignedTo" name="AssignedTo" <%if (this.Model.AssignedTo.Contains(user.UserId)) { %>
                        checked="checked" <%} %> value="<%= user.UserId.ToString() %>" />
                    <%: user.Name %></label>
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
