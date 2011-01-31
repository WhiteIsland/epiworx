<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.FeedIndexModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%
    using (this.Html.BeginForm("Index", "Feed", FormMethod.Get))
    {
%>
<div id="filter">
    <h5>
        Filter</h5>
    <div class="filter-criteria">
        <span>Show all hours for</span> <span class="filter-value filter-value-single"><strong>
        </strong>
            <%: this.Html.UserDropDownListFor(m => m.UserId, this.Model.Users, this.Model.UserId ?? 0, "any user", "0")%></span>
        <span class="filter-value filter-value-single">and&nbsp;<strong></strong>
            <%: this.Html.DateRangeDropDownListFor(m => m.Date, "Date", this.Model.Date)%></span>
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

        $("#UserId").change(function () {
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
