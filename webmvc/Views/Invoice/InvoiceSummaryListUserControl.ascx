<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.InvoiceIndexModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div class="part">
    <h4>
        Invoices</h4>
    <ul class="name-value">
        <%
            foreach (var number in Model.Invoices.Select(row => row.Number).Distinct())
            {
        %>
        <li>
            <div class="flag invoice">
            </div>
            <em>
                <%: string.Format("{0:N2}", this.Model.Invoices.Where(row => row.Number == number).Sum(row => row.Amount))%></em>
            <span>
                <%= number %></span></li>
        <%
            }
        %>
    </ul>
    <div class="total">
        Total<span>
            <%: string.Format("{0:N2}", this.Model.Invoices.Sum(row => row.Amount))%></span>
    </div>
</div>
