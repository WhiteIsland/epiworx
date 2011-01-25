using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epiworx.WebMvc.Helpers
{
    public class RequestFormatResponder
    {
        protected class SupportedFormat
        {
            public Predicate<ControllerContext> Predicate { get; set; }
            public Func<ActionResult> Result { get; set; }
        }

        protected List<SupportedFormat> Supported { get; set; }

        public RequestFormatResponder()
        {
            Supported = new List<SupportedFormat>();
        }

        public Func<ActionResult> this[Predicate<ControllerContext> predicate]
        {
            set { Supported.Add(new SupportedFormat { Predicate = predicate, Result = value }); }
        }

        public ActionResult Respond(ControllerContext context)
        {
            var match = Supported.LastOrDefault(s => s.Predicate(context));

            if (match != null)
                return match.Result();

            return null;
        }

        public Func<ActionResult> Html { set { this[RequestFormat.Html] = value; } }
        public Func<ActionResult> HtmlAsync { set { this[RequestFormat.HtmlAsync] = value; } }
        public Func<ActionResult> Json { set { this[RequestFormat.Json] = value; } }
        public Func<ActionResult> Xml { set { this[RequestFormat.Xml] = value; } }
    }
}