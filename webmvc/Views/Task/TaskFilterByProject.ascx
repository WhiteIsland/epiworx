<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.TaskIndexModel>" %>
<div class="filter-value filter-value-multiple">
    <strong title="<%: this.Model.ProjectName %>">
        <%: this.Model.ProjectDisplayName %>
    </strong>
    <div class="filter-value-multiple-container">
        <ul>
            <% 
                foreach (var project in this.Model.Projects)
                {
            %>
            <li>
                <label>
                    <input type="checkbox" id="ProjectId" name="ProjectId" <%if (this.Model.ProjectId.Contains(project.ProjectId)) { %>
                        checked="checked" <%} %> value="<%= project.ProjectId.ToString() %>" />
                    <%: project.Name %></label>
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
