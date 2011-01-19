<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.HourIndexModel>" %>
<div class="filter-value filter-value-multiple">
    assigned to <strong title="<%: this.Model.UserName %>">
        <%: this.Model.UserDisplayName %>
    </strong>
    <div class="filter-value-multiple-container">
        <ul>
            <% 
                foreach (var user in this.Model.Users)
                {
            %>
            <li>
                <label>
                    <input type="checkbox" id="UserId" name="UserId" <%if (this.Model.UserId.Contains(user.UserId)) { %>
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
