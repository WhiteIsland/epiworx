using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epiworx.WebMvc.Helpers
{
    public static class HttpRequestBaseExtensions
    {
        public static bool CanAccept(this HttpRequestBase request, string[] types, bool exact)
        {
            return Array.Exists(
                request.AcceptTypes,
                a => (a == "*/*" && exact == false) || Array.Exists(
                    types,
                    t => t.Equals(a, StringComparison.OrdinalIgnoreCase)
                )
            );
        }
    }
}