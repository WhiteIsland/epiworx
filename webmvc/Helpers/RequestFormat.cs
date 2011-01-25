using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epiworx.WebMvc.Helpers
{
    public static class RequestFormat
    {
        public static Predicate<ControllerContext> Html = (c) =>
            c.HttpContext.Request.CanAccept(new[] { "text/html" }, false);
        public static Predicate<ControllerContext> HtmlAsync = (c) =>
            c.HttpContext.Request.CanAccept(new[] { "text/html" }, false) && c.HttpContext.Request.IsAjaxRequest();
        public static Predicate<ControllerContext> Json = (c) =>
            c.HttpContext.Request.CanAccept(new[] { "application/json" }, true);
        public static Predicate<ControllerContext> Xml = (c) =>
            c.HttpContext.Request.CanAccept(new[] { "application/xml" }, true);
    }
}