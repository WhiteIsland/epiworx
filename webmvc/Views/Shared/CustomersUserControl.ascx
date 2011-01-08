<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Epiworx.Business.ICustomer>>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div class="part">
    <h3>
        Customers</h3>
    <ul>
        <%           
            foreach (var customer in this.Model)
            {
        %>
        <li>
            <%: this.Html.ActionLink(customer.Name, "Edit", "Customer", new { id = customer.CustomerId, title = this.Html.ToTitle(customer.Name.ToLower()) }, null)%>
        </li>
        <% } %>
    </ul>
    <%: this.Html.ActionLink("Add a customer", "Create", "Customer") %>
</div>
