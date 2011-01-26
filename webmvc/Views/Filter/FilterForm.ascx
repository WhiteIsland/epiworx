<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.FilterFormModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%: this.Html.Message(this.Model.Message) %>
<%: this.Html.ValidationSummary(true, "Whoops! Looks like some errors were encountered, please correct and try again.") %>
<fieldset>
    <p class="span3">
        <%: this.Html.LabelFor(m => m.Name) %>
        <%: this.Html.TextBox("Name", this.Model.Name, new { @class = "big" })%>
        <%: this.Html.ValidationMessageFor(m => m.Name)%>
        <span class="tip">This is the name of the filter, e.g. Project 1 open items.</span>
    </p>
    <div class="clear">
    </div>
    <p class="span3 checkbox">
        <%: this.Html.CheckBoxFor(m => m.IsActive)%>
        <%: this.Html.LabelFor(m => m.IsActive)%>
        <%: this.Html.ValidationMessageFor(m => m.IsActive)%>
    </p>
    <%: this.Html.HiddenFor(m => m.Target) %>
    <%: this.Html.HiddenFor(m => m.Query) %>
</fieldset>
