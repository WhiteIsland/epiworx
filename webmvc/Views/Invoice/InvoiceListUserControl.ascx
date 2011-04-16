<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.InvoiceListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%
    if (this.Model.Invoices.Count() == 0)
    {
%>
<p class="no-records">
    No records were found.</p>
<%
        return;
    }
%>
<table class="list invoice">
    <thead>
        <tr>
            <th class="flag">
                <div class="flag status" title="Status">
                </div>
            </th>
            <th style="width: 100px;">
                No.
            </th>
            <th style="width: 100px;">
                Prepared
            </th>
            <th style="width: 200px;">
                Project
            </th>
            <th style="width: 100px;">
                Task
            </th>
            <th>
                Description
            </th>
            <th style="width: 100px; text-align: right;">
                Amount
            </th>
        </tr>
    </thead>
    <tbody>
        <% foreach (var invoice in this.Model.Invoices)
           {
        %>
        <tr>
            <td class="flag">
                <% if (invoice.IsArchived)
                   {%>
                <div class="flag archived" title="Archived">
                </div>
                <%}
                   else
                   {%>
                <div class="flag not-archived" title="Not archived">
                </div>
                <%}%>
            </td>
            <td>
                <%:this.Html.ActionLink(
                    invoice.Number, "Edit", "Invoice", new {id = invoice.InvoiceId, title = this.Html.ToTitle(invoice.Description), returnUrl = this.Server.UrlEncode(this.Request.Url.ToString())}, null)%>
            </td>
            <td>
                <%: invoice.PreparedDate.ToShortDateString() %>
            </td>
            <td>
                <%: invoice.ProjectName %>
            </td>
            <td>
                <%: Html.ActionLink(invoice.TaskId.ToString(), "Edit", "Task", new { id = invoice.TaskId }, null) %>
            </td>
            <td>
                <p title="<%: invoice.Description %>">
                    <%: invoice.Description %></p>
            </td>
            <td style="text-align: right;">
                <%: invoice.Amount.ToString("N2") %>
            </td>
        </tr>
        <%
           }
        %>
    </tbody>
    <tfoot>
        <tr>
            <td colspan="6">
                Total
            </td>
            <td style="text-align: right;">
                <%: this.Model.Invoices.Sum(row => row.Amount).ToString("N2") %>
            </td>
        </tr>
    </tfoot>
</table>
