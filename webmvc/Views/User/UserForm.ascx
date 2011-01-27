<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.UserFormModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%: this.Html.Message(this.Model.Message) %>
<%: this.Html.ValidationSummary(true, "Whoops! Looks like some errors were encountered, please correct and try again.") %>
<fieldset>
    <p class="span3">
        <%: this.Html.LabelFor(m => m.Name) %>
        <%: this.Html.TextBox("Name", this.Model.Name, new { @class = "big" })%>
        <%: this.Html.ValidationMessageFor(m => m.Name)%>
        <span class="tip">This is your login name, this name must be unique, e.g. johndoe.</span>
    </p>
    <div class="clear">
    </div>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.FirstName) %>
        <%: this.Html.TextBoxFor(m => m.FirstName)%>
        <%: this.Html.ValidationMessageFor(m => m.FirstName)%>
    </p>
    <p class="span1">
        <%: this.Html.LabelFor(m => m.LastName) %>
        <%: this.Html.TextBoxFor(m => m.LastName)%>
        <%: this.Html.ValidationMessageFor(m => m.LastName)%>
    </p>
    <div class="clear">
    </div>
    <p class="span3 checkbox">
        <%: this.Html.LabelFor(m => m.Email) %>
        <%: this.Html.TextBoxFor(m => m.Email) %>
        <%: this.Html.ValidationMessageFor(m => m.Email) %>
    </p>
    <div class="clear">
    </div>
    <p class="span3">
        <%: this.Html.LabelFor(m => m.Role) %>
        <%: this.Html.RoleDropDownListFor(m => m.Role, this.Model.Roles, this.Model.Role)%>
        <%: this.Html.ValidationMessageFor(m => m.Role)%>
    </p>
    <div class="clear">
    </div>
    <p class="span3 checkbox">
        <%: this.Html.CheckBoxFor(m => m.IsActive)%>
        <%: this.Html.LabelFor(m => m.IsActive)%>
    </p>
    <div class="clear">
    </div>
    <p class="span3 checkbox">
        <%: this.Html.CheckBoxFor(m => m.IsArchived)%>
        <%: this.Html.LabelFor(m => m.IsArchived)%>
    </p>
    <div class="separator"></div>
    <div class="clear">
    </div>
    <p class="span3">
        <%: this.Html.LabelFor(m => m.Password) %>
        <%: this.Html.PasswordFor(m => m.Password)%>
        <%: this.Html.ValidationMessageFor(m => m.Password)%>
    </p>
    <div class="clear">
    </div>
    <p class="span3">
        <%: this.Html.LabelFor(m => m.PasswordConfirmation) %>
        <%: this.Html.PasswordFor(m => m.PasswordConfirmation)%>
        <%: this.Html.ValidationMessageFor(m => m.PasswordConfirmation)%>
    </p>
    <div class="clear">
    </div>
</fieldset>
