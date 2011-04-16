<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.InvoiceIndexModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%
    using (this.Html.BeginForm("Index", "Invoice", FormMethod.Get))
    {
%>
<div id="filter">
    <ul class="actions">
        <li>
            <%: this.Html.ActionLink("Save as New Filter", "Create", "Filter", new { target = "Invoice", query = Server.UrlEncode(this.Request.QueryString.ToString()) }, null) %></li>
    </ul>
    <h5>
        Filter</h5>
    <div class="filter-criteria">
        <span>Show all invoices for</span>
        <% this.Html.RenderPartial("InvoiceFilterByProject"); %>
       <span class="filter-value filter-value-single">and&nbsp;created&nbsp;<strong></strong>
            <%: this.Html.DateRangeDropDownListFor(m => m.Date, "Date", this.Model.Date)%></span>
        <span class="filter-value filter-value-single">and&nbsp;<strong></strong>
            <%: this.Html.IsArchivedDropDownListFor(m => m.IsArchived, this.Model.IsArchived)%></span>
    </div>
    <div class="filter-sort">
        <span class="filter-value filter-value-single">Sort by&nbsp;<strong></strong>
            <%: this.Html.SortedColumnsDropDownListFor(m => m.SortBy, this.Model.SortableColumns, this.Model.SortBy)%></span>
        <span class="filter-value filter-value-single"><strong></strong>
            <%: this.Html.SortedColumnsOrderDropDownListFor(m => m.SortOrder, this.Model.SortOrder)%></span>
    </div>
    <div class="clear">
    </div>
</div>
<%
    } 
%>
<script type="text/javascript">
    $(document).ready(function () {
        $("#Date").change(function () {
            $("form").submit();
        });

        $("#IsArchived").change(function () {
            $("form").submit();
        });

        $("#SortBy").change(function () {
            $("form").submit();
        });

        $("#SortOrder").change(function () {
            $("form").submit();
        });
    });
</script>
