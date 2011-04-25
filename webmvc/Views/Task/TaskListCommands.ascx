<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.TaskListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div class="list-commands">
    <button value="Archive">
        Archive</button>
    <button value="Unarchive">
        Unarchive</button>
    <button value="Update Status">
        Change Status</button>
    <%: Html.StatusDropDownList(this.Model.Statuses)%>
    <button value="Update Assignment">
        Change Assignment</button>
    <%: Html.AssignedToDropDownList(this.Model.AssignedToUsers)%>
    <%: Html.Hidden("Action") %>
</div>
<script type="text/javascript">
    $(".list-commands button").click(function () {
        $(".list-commands #Action").val($(this).val());
    });
</script>
