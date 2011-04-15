<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.InvoiceFormModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%: this.Html.Message(this.Model.Message) %>
<%: this.Html.ValidationSummary(true, "Whoops! Looks like some errors were encountered, please correct and try again.") %>
<fieldset>
    <p class="span2">
        <%: this.Html.LabelFor(m => m.Number) %>
        <%: this.Html.TextBoxFor(m => m.Number)%>
    </p>
    <p class="span1">
        <label>
            Project:</label>
        <span>
            <%: Model.ProjectName %></span>
    </p>
    <div class="clear">
    </div>
    <p class="span2">
        <%: this.Html.LabelFor(m => m.Amount) %>
        <%: this.Html.TextBoxFor(m => m.Amount)%>
    </p>
    <p class="span1">
        <label>
            Task:</label>
        <%: Html.ActionLink(Model.TaskId.ToString(), "Edit", "Task", new { id = Model.TaskId }, null)%>
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
