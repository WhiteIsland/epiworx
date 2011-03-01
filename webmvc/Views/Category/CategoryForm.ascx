<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.NoteFormModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%: this.Html.Message(this.Model.Message) %>
<%: this.Html.ValidationSummary(true, "Whoops! Looks like some errors were encountered, please correct and try again.") %>
<fieldset>
    <p class="span3">
        <%: this.Html.LabelFor(m => m.Body) %>
        <%: this.Html.TextAreaFor(m => m.Body)%>
        <%: this.Html.ValidationMessageFor(m => m.Body)%>
    </p>
    <div class="clear">
    </div>
</fieldset>
