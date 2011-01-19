<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.FilterListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div class="part">
    <h4>
        Filters</h4>
    <ul>
        <%           
            foreach (var filter in this.Model.Filters)
            {
        %>
        <li><a href="<%: filter.Target %>?<%: Server.UrlDecode(filter.Query) %>"><%: filter.Name %></a>
 <%--           <%= this.Html.ActionLink("Edit", "Edit", "Category", new { id = filter.FilterId, title = this.Html.ToTitle(filter.Name) }, new { @class = "action" })%>
 --%>       </li>
        <% } %>
     </ul>
</div>
