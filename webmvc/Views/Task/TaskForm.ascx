<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.TaskFormModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%: this.Html.Message(this.Model.Message) %>
<%: this.Html.ValidationSummary(true, "Whoops! Looks like some errors were encountered, please correct and try again.") %>
<fieldset>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.ProjectId) %>
        <%: this.Html.ProjectDropDownListFor(m => m.ProjectId, this.Model.Projects, this.Model.ProjectId)%>
        <%: this.Html.ValidationMessageFor(m => m.ProjectId)%>
    </p>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.StatusId) %>
        <%: this.Html.StatusDropDownListFor(m => m.StatusId, this.Model.Statuses, this.Model.StatusId)%>
        <%: this.Html.ValidationMessageFor(m => m.StatusId)%>
    </p>
    <p class="span1 last">
        <%: this.Html.LabelFor(m => m.CategoryId) %>
        <%: this.Html.CategoryDropDownListFor(m => m.CategoryId, this.Model.Categories, this.Model.CategoryId)%>
        <%: this.Html.ValidationMessageFor(m => m.CategoryId)%>
    </p>
    <div class="clear">
    </div>
    <p class="span3">
        <%: this.Html.LabelFor(m => m.Description) %>
        <%: this.Html.TextAreaFor(m => m.Description)%>
        <%: this.Html.ValidationMessageFor(m => m.Description)%>
    </p>
    <div class="clear">
    </div>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.SprintId) %>
        <%: this.Html.SprintDropDownListFor(m => m.SprintId, this.Model.Sprints, this.Model.SprintId)%>
        <%: this.Html.ValidationMessageFor(m => m.SprintId)%>
    </p>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.AssignedTo) %>
        <%: this.Html.AssignedToDropDownListFor(m => m.AssignedTo, this.Model.Users, this.Model.AssignedTo)%>
        <%: this.Html.ValidationMessageFor(m => m.AssignedTo)%>
    </p>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.EstimatedDuration) %>
        <%: this.Html.EstimatedDurationDropDownListFor(m => m.EstimatedDuration, this.Model.EstimatedDuration)%>
        <%: this.Html.ValidationMessageFor(m => m.EstimatedDuration)%>
    </p>
    <div class="clear">
    </div>
    <p class="span3">
        <%: this.Html.LabelFor(m => m.Labels) %>
        <%: this.Html.TextBoxFor(m => m.Labels)%>
        <%: this.Html.ValidationMessageFor(m => m.Labels)%>
    </p>
    <div class="clear">
    </div>
    <!-- Switching to a running list notes instead of an individual box, so we'll just hide the notes box for now  -->
    <div style="display: none;">
        <p class="span3">
            <%: this.Html.LabelFor(m => m.Notes) %>
            <%: this.Html.TextAreaFor(m => m.Notes) %>
            <%: this.Html.ValidationMessageFor(m => m.Notes)%>
        </p>
        <div class="clear">
        </div>
    </div>
    <p class="span3 checkbox">
        <%: this.Html.CheckBoxFor(m => m.IsArchived)%>
        <%: this.Html.LabelFor(m => m.IsArchived)%>
        <%: this.Html.ValidationMessageFor(m => m.IsArchived)%>
    </p>
</fieldset>
<script type="text/javascript">
    $(document).ready(function () {
        $("#ProjectId").change(function () {
            var projectId = $(this)[0].value;
 
            var url = "<%: this.Url.Action("List", "Sprint") %>.json?projectId=" + projectId;

            $.getJSON(url, null, function (data) {
                $("#SprintId").empty();
                $("#SprintId").append("<option value=\"0\">Select a sprint...</option>");            
                $.each(data, function(index, optionData) {                
                    $("#SprintId").append("<option value=\"" + optionData.SprintId + "\">" + optionData.Name + "</option>");            
                });
            });
        });
    }); 
</script>
