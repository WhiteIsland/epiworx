<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.TaskIndexModel>" %>
<div class="filter-value filter-value-multiple">
    and is <strong title="<%: this.Model.StatusName %>">
        <%: this.Model.StatusDisplayName%>
    </strong>
    <div class="filter-value-multiple-container">
        <ul>
            <% 
                foreach (var status in this.Model.Statuses)
                {
            %>
            <li>
                <label>
                    <input type="checkbox" id="StatusId" name="StatusId" <%if (this.Model.StatusId.Contains(status.StatusId)) { %>
                        checked="checked" <%} %> value="<%= status.StatusId.ToString() %>" />
                    <%: status.Name %></label>
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
