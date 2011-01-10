<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.ForgotPasswordModel>" %>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Forgot Password
</asp:Content>
<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Forgot<span>Password</span></h2>
    <p class="instructions">
        Use the form below to reset your password.
    </p>
    <% using (this.Html.BeginForm())
       { %>
    <%: this.Html.ValidationSummary(true, "Password reset was unsuccessful. Please correct the errors and try again.")%>
    <fieldset>
        <p class="span3">
            <%: this.Html.LabelFor(m => m.Name)%>
            <%: this.Html.TextBoxFor(m => m.Name, new { @class = "big small" })%>
            <%: this.Html.ValidationMessageFor(m => m.Name)%>
        </p>
        <div class="clear">
        </div>
    </fieldset>
    <div class="commands">
        <ul>
            <li>
                <input type="submit" value="Reset Password" /></li>
            <li>
                <%: this.Html.ActionLink("Cancel", "LogOn") %></li>
        </ul>
    </div>
    <% } %>
</asp:Content>
