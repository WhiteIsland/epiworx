<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.StatusFormModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%: this.Html.Message(this.Model.Message) %>
<%: this.Html.ValidationSummary(true, "Whoops! Looks like some errors were encountered, please correct and try again.") %>
<fieldset>
    <p class="span3">
        <%: this.Html.LabelFor(m => m.Name) %>
        <%: this.Html.TextBox("Name", this.Model.Name, new { @class = "big" })%>
        <%: this.Html.ValidationMessageFor(m => m.Name)%>
        <span class="tip">This is the name of the status, this name must be unique, e.g. Open.</span>
    </p>
    <div class="clear">
    </div>
    <p class="span3">
        <%: this.Html.LabelFor(m => m.Description) %>
        <%: this.Html.TextBoxFor(m => m.Description)%>
        <%: this.Html.ValidationMessageFor(m => m.Description)%>
        <span class="tip">This is a detailed description of the status and it's purpose.</span>
    </p>
    <div class="clear">
    </div>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.Ordinal) %>
        <%: this.Html.EditorFor(m => m.Ordinal) %>
        <%: this.Html.ValidationMessageFor(m => m.Ordinal)%>
        <span class="tip">Determines the order in which the status displays.</span>
    </p>
    <div class="clear">
    </div>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.BackColor) %>
        <%: this.Html.TextBoxFor(m => m.BackColor)%>
        <%: this.Html.ValidationMessageFor(m => m.BackColor)%>
    </p>
    <p class="span2">
        <%: this.Html.LabelFor(m => m.ForeColor) %>
        <%: this.Html.TextBoxFor(m => m.ForeColor)%>
        <%: this.Html.ValidationMessageFor(m => m.ForeColor)%>
    </p>
    <div class="clear">
    </div>
    <p class="span3 checkbox">
        <%: this.Html.CheckBoxFor(m => m.IsStarted)%>
        <%: this.Html.LabelFor(m => m.IsStarted)%>
        <%: this.Html.ValidationMessageFor(m => m.IsStarted)%>
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
