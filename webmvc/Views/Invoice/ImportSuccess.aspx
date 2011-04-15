<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.InvoiceImportModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Import Invoices Success
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Imported <span>Invoices</span></h2>
    <% this.Html.RenderPartial("InvoiceListUserControl", new InvoiceListModel { Invoices = this.Model.Invoices }); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
    <div class="part">
        <h4>
            Things To Do</h4>
        <ul>
            <li><a href="<%: this.Url.Action("Export") %>?<%= this.Request.QueryString %>">Export
                Invoices</a></li>
            <li>
                <%: this.Html.ActionLink("Import Invoices", "Import", "Invoice")%></li>
        </ul>
    </div>
</asp:Content>
