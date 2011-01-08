<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Int32?>" %>

<%: this.Html.TextBox(string.Empty, (this.Model.HasValue ? this.Model.Value.ToString() : 0.ToString()), new { @class = "number" }) %>