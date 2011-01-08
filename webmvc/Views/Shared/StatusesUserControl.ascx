<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Epiworx.Business.IStatus>>" %>
<div class="part">
    <h3>
        Statuses</h3>
    <ul>
        <%           
            foreach (var status in this.Model)
            {
        %>
        <li>
            <%= this.Html.ActionLink(status.Name, "Edit", "Status", new { id = status.StatusId, title = status.Description}, null)%>
        </li>
        <% } %>
    </ul>
    <%: this.Html.ActionLink("Add a status", "Create", "Status") %>
</div>
