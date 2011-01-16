<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.HourIndexModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div id="filter">
    <h5>
        Filter</h5>
    Show all tasks 
    for <span><strong></strong>
        <%: this.Html.ProjectDropDownListFor(m => m.ProjectId, this.Model.Projects, this.Model.ProjectId, "any project", "0")%></span>
    recorded by <span><strong></strong>
        <%: this.Html.UserDropDownListFor(m => m.UserId, this.Model.Users, this.Model.UserId, "any user", "0")%></span>
    and <span><strong></strong>
        <%: this.Html.DateRangeDropDownListFor(m => m.Date, "Date", this.Model.Date)%></span>
    and <span><strong></strong>
        <%: this.Html.IsArchivedDropDownListFor(m => m.IsArchived, this.Model.IsArchived)%></span>
    <div class="separator">
    </div>
    Sort by <span><strong></strong>
        <%: this.Html.SortedColumnsDropDownListFor(m => m.SortBy, this.Model.SortableColumns, this.Model.SortBy)%></span>
    <span><strong></strong>
        <%: this.Html.SortedColumnsOrderDropDownListFor(m => m.SortOrder, this.Model.SortOrder)%></span>
</div>
<script type="text/javascript">
        $(document).ready(function () {
            $("#SortBy").change(onFilterValueChanged);
            $("#SortOrder").change(onFilterValueChanged);
            $("#UserId").change(onUserIdChanged);
            $("#Date").change(onDateChanged);
            $("#ProjectId").change(onFilterValueChanged);
            $("#IsArchived").change(onFilterValueChanged);
        });

        function onUserIdChanged()  {
            onFilterValueChanged();
        }

        function onDateChanged()  {
            onFilterValueChanged();
        }

        function onFilterValueChanged() {
            var navigateUrl = "<%= this.Url.Action("Index", "Hour") %>";
            var query = "";

            var sortBy = $("#SortBy option:selected");
            query = query + "sortBy=" + sortBy.val();
 
            var sortOrder = $("#SortOrder option:selected");
            query = query + "&sortOrder=" + sortOrder.val();
 
            var projectId = $("#ProjectId option:selected");
            if (parseInt(projectId.val()) != 0)
            {
                query = query + "\&";
                query = query + "projectId=" + projectId.val();
            }

            var userId = $("#UserId option:selected");
            if (parseInt(userId.val()) != 0)
            {
                query = query + "\&";
                query = query + "userId=" + userId.val();
            }

            var date = $("#Date option:selected");
            if (date.val() != 0)
            {
                query = query + "\&";
                query = query + "date=" + date.val();
            }

            var isArchived = $("#IsArchived option:selected");
            query = query + "\&";
            query = query + "isArchived=" + isArchived.val();
 
            if (query != "")
            {
                navigateUrl = navigateUrl + "?" + query;
            }

            location.href = navigateUrl;
        }
</script>
