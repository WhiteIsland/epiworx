<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.InvoiceFormModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Delete Invoice
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (this.Html.BeginForm("Delete", "Invoice", new { id = this.Model.InvoiceId }, FormMethod.Post))
        {
    %>
    <h2>
        Delete Invoice Confirmation</h2>
    <%: this.Html.ValidationSummary(true, "Whoops! Looks like some errors were encountered, please correct and try again.") %>
    <fieldset>
        <p>
            You are attempting to delete the invoice <strong>
                <%:this.Model.Number%></strong>. Click the <strong>Continue</strong> button to
            delete to continue.</p>
    </fieldset>
    <div class="commands">
        <ul>
            <li>
                <input type="submit" value="Continue" /></li>
            <li>
                <%=this.Html.ActionLink("Cancel", "Edit", new {id = this.Model.InvoiceId})%>
            </li>
        </ul>
    </div>
    <%
        }
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
