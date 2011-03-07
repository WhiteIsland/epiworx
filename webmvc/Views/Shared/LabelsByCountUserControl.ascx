<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.LabelByCountListModel>" %>
<div class="part">
    <h4>
        Labels</h4>
    <ul class="labels">
        <%
            foreach (var labelByCount in this.Model.Labels)
            {
        %>
            <li<% if (this.Model.Label == labelByCount.Name) {%> class="selected"<%}%>><a href="<%= this.Url.Action("Index", this.Model.Action, new { label = labelByCount.Name }) %>" title="<%= labelByCount.Quantity %> item(s)"><%= labelByCount.Name%></a></li>
        <%
            }
        %>
    </ul>
    <div class="clear"></div>
</div>
