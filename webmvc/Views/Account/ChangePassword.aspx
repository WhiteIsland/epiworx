<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.ChangePasswordModel>" %>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Change Password
</asp:Content>
<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Change Password</h2>
    <p class="instructions">
        Use the form below to change your password.
    </p>
    <% using (this.Html.BeginForm())
       { %>
    <%: this.Html.ValidationSummary(true, "Password change was unsuccessful. Please correct the errors and try again.") %>
    <p>
        <fieldset>
            <p class="span3">
                <%: Html.LabelFor(m => m.NewPassword) %>
                <%: Html.PasswordFor(m => m.NewPassword, new { @class = "big small" })%>
                <%: Html.ValidationMessageFor(m => m.NewPassword) %>
            </p>
            <div class="clear">
            </div>
            <p class="span3">
                <%: Html.LabelFor(m => m.ConfirmPassword) %>
                <%: Html.PasswordFor(m => m.ConfirmPassword, new { @class = "big small" })%>
                <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
            </p>
            <div class="clear">
            </div>
        </fieldset>
        <div class="commands">
            <ul>
                <li>
                    <input type="submit" value="Change Password" /></li>
                <li>
                    <%: this.Html.ActionLink("Cancel", "LogOn") %></li>
            </ul>
        </div>
        <% } %>
</asp:Content>
