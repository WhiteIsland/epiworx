<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.FilterListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div class="part">
    <h4>
        Filters</h4>
    <% 
        if (this.Model.Filters.Count() == 0)
        {
    %>
    <p class="no-records">No filters have been created.<br /><br />To <strong>Create</strong> a filter click the <strong>Save as New Filter</strong> link after you create and execute your filter.</p>
    <%
        }
        else
        {
    %>
    <ul>
        <%           
            foreach (var filter in this.Model.Filters)
            {
        %>
        <li>
            <%= this.Html.ActionLink("Edit", "Edit", "Filter", new { id = filter.FilterId, title = this.Html.ToTitle(filter.Name) }, new { @class = "action" })%>
            <a href="<%: filter.Target %>?<%: Server.UrlDecode(filter.Query) %>">
                <%: filter.Name %></a></li>
        <% 
            } 
        %>
    </ul>
    <%
        }
    %>
</div>
