using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epiworx.WebMvc.Helpers
{
    public static class RequestExtension
    {
        public static Predicate<ControllerContext> Html = (c) =>
            String.IsNullOrEmpty(c.RouteData.Values["format"] as string);
        public static Predicate<ControllerContext> Json = (c) =>
            "json".Equals(c.RouteData.Values["format"] as string, StringComparison.OrdinalIgnoreCase);
        public static Predicate<ControllerContext> Xml = (c) =>
            "xml".Equals(c.RouteData.Values["format"] as string, StringComparison.OrdinalIgnoreCase);
    }
}