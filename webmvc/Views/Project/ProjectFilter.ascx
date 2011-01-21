<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.ProjectIndexModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%
    using (this.Html.BeginForm("Index", "Project", FormMethod.Get))
    {
%>
<div id="filter">
    <h5>
        Filter</h5>
    <div class="filter-criteria">
        <span>Show all hours for</span> <span class="filter-value filter-value-single">and&nbsp;<strong></strong>
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
