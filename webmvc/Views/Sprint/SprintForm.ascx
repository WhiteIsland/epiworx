<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.SprintFormModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%: this.Html.Message(this.Model.Message) %>
<%: this.Html.ValidationSummary(true, "Whoops! Looks like some errors were encountered, please correct and try again.") %>
<fieldset>
    <p class="span3">
        <%: this.Html.LabelFor(m => m.Name) %>
        <%: this.Html.TextBox("Name", this.Model.Name, new { @class = "big" })%>
        <%: this.Html.ValidationMessageFor(m => m.Name)%>
        <span class="tip">This is the name of the sprint, this name must be unique per project,
            e.g. Current, Sprint #42.</span>
    </p>
    <div class="clear">
    </div>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.ProjectId) %>
        <%: this.Html.ProjectDropDownListFor(m => m.ProjectId, this.Model.Projects, this.Model.ProjectId)%>
        <%: this.Html.ValidationMessageFor(m => m.ProjectId)%>
    </p>

    <div class="clear">
    </div>
   <p class="span3 checkbox">
        <%: this.Html.CheckBoxFor(m => m.IsCompleted)%>
        <%: this.Html.LabelFor(m => m.IsCompleted)%>
        <%: this.Html.ValidationMessageFor(m => m.IsCompleted)%>
    </p>
    <div class="clear">
    </div>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.EstimatedCompletedDate) %>
        <%: this.Html.EditorFor(m => m.EstimatedCompletedDate)%>
        <%: this.Html.ValidationMessageFor(m => m.EstimatedCompletedDate)%>
    </p>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.CompletedDate) %>
        <%: this.Html.EditorFor(m => m.CompletedDate)%>
        <%: this.Html.ValidationMessageFor(m => m.CompletedDate)%>
    </p>
    <div class="clear">
    </div>
    <p class="span3 checkbox">
        <%: this.Html.CheckBoxFor(m => m.IsActive)%>
        <%: this.Html.LabelFor(m => m.IsActive)%>
        <%: this.Html.ValidationMessageFor(m => m.IsActive)%>
    </p>
    <div class="clear">
    </div>
    <p class="span3 checkbox">
        <%: this.Html.CheckBoxFor(m => m.IsArchived)%>
        <%: this.Html.LabelFor(m => m.IsArchived)%>
        <%: this.Html.ValidationMessageFor(m => m.IsArchived)%>
    </p>
</fieldset>
