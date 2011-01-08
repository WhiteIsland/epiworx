<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.HourFormModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%: this.Html.ValidationSummary(true, "Whoops! Looks like some errors were encountered, please correct and try again.") %>
<fieldset>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.Date) %>
        <%: this.Html.EditorFor(m => m.Date)%>
        <%: this.Html.ValidationMessageFor(m => m.Date)%>
    </p>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.Duration) %>
        <%: this.Html.EditorFor(m => m.Duration)%>
        <%: this.Html.ValidationMessageFor(m => m.Duration)%>
    </p>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.UserId) %>
        <%: this.Html.UserDropDownListFor(m => m.UserId, this.Model.Users, this.Model.UserId)%>
        <%: this.Html.ValidationMessageFor(m => m.UserId)%>
    </p>
    <div class="clear">
    </div>
    <p class="span3">
        <%: this.Html.LabelFor(m => m.Notes) %>
        <%: this.Html.TextAreaFor(m => m.Notes)%>
        <%: this.Html.ValidationMessageFor(m => m.Notes)%>
    </p>
    <div class="clear">
    </div>
    <p class="span3 checkbox">
        <%: this.Html.CheckBoxFor(m => m.IsArchived)%>
        <%: this.Html.LabelFor(m => m.IsArchived)%>
        <%: this.Html.ValidationMessageFor(m => m.IsArchived)%>
    </p>
</fieldset>
<%
    if (this.Model.IsNew && this.Model.TaskId == 0)
    {
%>
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
    <p class="span3">
        <%: this.Html.LabelFor(m => m.Description) %>
        <%: this.Html.TextAreaFor(m => m.Description)%>
        <%: this.Html.ValidationMessageFor(m => m.Description)%>
    </p>
    <div class="clear">
    </div>
</fieldset>
<%
    }
%>