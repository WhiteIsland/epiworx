<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.InvoiceIndexModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%@ Import Namespace="Epiworx.WebMvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Invoices
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Invoices</h2>
    <%this.Html.RenderPartial("InvoiceFilter", this.Model);%>
    <%this.Html.RenderPartial("InvoiceListUserControl", this.Model);%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
    <div class="part">
        <h4>
            Things To Do</h4>
        <ul class="list">
            <li>
                <div class="flag export">
                </div>
                <a href="<%: this.Url.Action("Export") %>?<%= this.Request.QueryString %>">Export Invoices</a></li>
            <li>
                <div class="flag import">
                </div>
                <%: this.Html.ActionLink("Import Invoices", "Import", "Invoice")%></li>
        </ul>
    </div>
    <% this.Html.RenderPartial("FiltersUserControl", new FilterListModel { Target = "Invoice", Filters = this.Model.Filters });%>
</asp:Content>
