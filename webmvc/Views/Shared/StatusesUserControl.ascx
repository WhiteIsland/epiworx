<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Epiworx.Business.IStatus>>" %>
<div class="part">
    <h4>
        Statuses</h4>
    <ul>
        <%           
            foreach (var status in this.Model)
            {
        %>
        <li>
            <%= this.Html.ActionLink(status.Name, "Edit", "Status", new { id = status.StatusId, title = status.Description}, null)%>
        </li>
        <% } %>
        <li>
            <%: this.Html.ActionLink("Add a New Status...", "Create", "Status")%>
        </li>
    </ul>
</div>
