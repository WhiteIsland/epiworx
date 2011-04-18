<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.InvoiceFormModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%: this.Html.Message(this.Model.Message) %>
<%: this.Html.ValidationSummary(true, "Whoops! Looks like some errors were encountered, please correct and try again.") %>
<fieldset>
    <p class="span2">
        <label>
            Project:</label>
        <span>
            <%: Model.ProjectName %></span>
    </p>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.TaskId) %>
        <%: this.Html.TextBoxFor(m => m.TaskId, new {@class = "number"})%>
        <%: this.Html.ValidationMessageFor(m => m.TaskId)%>
    </p>
    <div class="clear">
    </div>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.Number) %>
        <%: this.Html.TextBoxFor(m => m.Number)%>
    </p>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.PreparedDate) %>
        <%: this.Html.EditorFor(m => m.PreparedDate)%>
    </p>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.Amount) %>
        <%: this.Html.TextBoxFor(m => m.Amount)%>
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
    <p class="span3 checkbox">
        <%: this.Html.CheckBoxFor(m => m.IsArchived)%>
        <%: this.Html.LabelFor(m => m.IsArchived)%>
        <%: this.Html.ValidationMessageFor(m => m.IsArchived)%>
    </p>
</fieldset>
