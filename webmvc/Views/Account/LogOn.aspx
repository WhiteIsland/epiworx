<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Log On
</asp:Content>
<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Log<span>On</h2>
    <p class="instructions">
        Please enter your username and password.
        <%: this.Html.ActionLink("Register", "Register") %>
        if you don't have an account.
    </p>
    <% using (this.Html.BeginForm())
       { %>
    <%: this.Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.")%>
    <fieldset>
        <p class="span3">
            <%: Html.LabelFor(m => m.UserName) %>
            <%: Html.TextBoxFor(m => m.UserName, new { @class = "big small" })%>
            <%: Html.ValidationMessageFor(m => m.UserName) %>
        </p>
        <div class="clear">
        </div>
        <p class="span3">
            <%: Html.LabelFor(m => m.Password) %>
            <%: Html.PasswordFor(m => m.Password, new { @class = "big small" })%>
            <%: Html.ValidationMessageFor(m => m.Password) %>
        </p>
        <div class="clear">
        </div>
        <p class="span3 checkbox">
            <%: Html.CheckBoxFor(m => m.RememberMe) %>
            <%: Html.LabelFor(m => m.RememberMe) %>
        </p>
        <div class="clear">
        </div>
    </fieldset>
    <div class="commands">
        <ul>
            <li>
                <input type="submit" value="Log On" /></li>
            <li>
                <%: this.Html.ActionLink("I forgot my password", "ForgotPassword") %></li>
        </ul>
    </div>
    <% } %>
</asp:Content>
