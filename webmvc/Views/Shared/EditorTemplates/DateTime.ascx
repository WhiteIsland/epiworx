﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.DateTime?>" %>
<%: this.Html.TextBox(string.Empty, (this.Model.HasValue ? this.Model.Value.ToShortDateString() : string.Empty), new { @class = "date" }) %>