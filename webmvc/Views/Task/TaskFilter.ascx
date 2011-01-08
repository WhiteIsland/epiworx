<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.TaskIndexModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div id="filter">
    <h5>
        Filter</h5>
    Show all tasks 
    for <span><strong></strong>
        <%: this.Html.ProjectDropDownListFor(m => m.ProjectId, this.Model.Projects, this.Model.ProjectId, "any project", "0")%></span>
    assigned to <span><strong></strong>
        <%: this.Html.AssignedToDropDownListFor(m => m.AssignedTo, this.Model.AssignedToUsers, this.Model.AssignedTo, "any user", "0")%></span>
    and <span><strong></strong>
        <%: this.Html.StatusDropDownListFor(m => m.StatusId, this.Model.Statuses, this.Model.StatusId, "any status", "0")%></span>
    and <span><strong></strong>
        <%: this.Html.CategoryDropDownListFor(m => m.CategoryId, this.Model.Categories, this.Model.CategoryId, "any category", "0")%></span>
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
            $("#AssignedTo").change(onAssignedToChanged);
            $("#CategoryId").change(onFilterValueChanged);
            $("#StatusId").change(onFilterValueChanged);
            $("#ProjectId").change(onFilterValueChanged);
            $("#IsArchived").change(onFilterValueChanged);
        });

        function onAssignedToChanged()  {
            onFilterValueChanged();
        }

        function onFilterValueChanged() {
            var navigateUrl = "<%= this.Url.Action("Index", "Task") %>";
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

            var categoryId = $("#CategoryId option:selected");
            if (parseInt(categoryId.val()) != 0)
            {
                query = query + "\&";
                query = query + "categoryId=" + categoryId.val();
            }

            var statusId = $("#StatusId option:selected");
            if (parseInt(statusId.val()) != 0)
            {
                query = query + "\&";
                query = query + "statusId=" + statusId.val();
            }

            var assignedTo = $("#AssignedTo option:selected");
            if (parseInt(assignedTo.val()) != 0)
            {
                query = query + "\&";
                query = query + "assignedTo=" + assignedTo.val();
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
