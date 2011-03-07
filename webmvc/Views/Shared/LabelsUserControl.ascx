<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.LabelListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%@ Import Namespace="Epiworx.WebMvc.Models" %>
<div class="part">
    <h4>
        Labels</h4>
    <div class="labels">
        <ul>
            <% foreach (var label in this.Model.Labels)
               {
            %>
            <li><a href="<%= this.Url.Action("Index", this.Model.Action, new { label = label }) %>">
                <%= label%></a></li>
            <%
               } 
            %>
        </ul>
        <div class="clear"></div>
    </div>
</div>
