<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Epiworx.Business.IInvoice>>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div class="part">
    <h4>
        Invoices</h4>
    <%
        if (Model.Count() != 0)
        {
    %>
    <ul class="name-value">
        <%
            foreach (var invoice in Model)
            {
        %>
        <li>
            <%: this.Html.ActionLink(invoice.Amount.ToString("N2"), "Edit", "Invoice", new { id = invoice.InvoiceId}, null)%>
            <span>
                <%:invoice.Number%></span></li>
        <%
                }%>
    </ul>
    <%
        }
        else
        {
    %>
    <p class="no-records">
        No invoices have been recorded.</p>
    <%
        }
    %>
    <div class="total">
        Total <span>
            <%: this.Model.Sum(row => row.Amount).ToString("N2")%></span>
    </div>
</div>
