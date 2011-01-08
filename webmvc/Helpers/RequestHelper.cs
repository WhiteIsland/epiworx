using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Epiworx.Business;

namespace Epiworx.WebMvc.Helpers
{
    public class RequestHelper
    {
        public static void ClearCookie(string key)
        {
            if (HttpContext.Current.Request.Cookies[key] == null)
            {
                return;
            }

            HttpContext.Current.Request.Cookies[key].Value = null;
            HttpContext.Current.Request.Cookies[key].Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Remove(key);
        }

        public static void SetCookie(string key, object value)
        {
            RequestHelper.SetCookie(key, value, null);
        }

        public static void SetCookie(string key, object value, int expirationDays)
        {
            RequestHelper.SetCookie(key, value, DateTime.Now.AddDays(expirationDays));
        }

        public static void SetCookie(string key, object value, DateTime? expires)
        {
            var cookie = new HttpCookie(key);

            cookie.Value = value.ToString();

            if (expires.HasValue)
            {
                cookie.Expires = expires.Value;
            }

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static T GetCookie<T>(string key, T defaultValue)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                return (T)Convert.ChangeType(HttpContext.Current.Request.Cookies[key].Value, typeof(T), CultureInfo.InvariantCulture);
            }

            return (T)Convert.ChangeType(defaultValue, typeof(T), CultureInfo.InvariantCulture);
        }

        public static T GetParameter<T>(string key)
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[key]))
            {
                return default(T);
            }

            return (T)Convert.ChangeType(HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.QueryString[key]), typeof(T), CultureInfo.InvariantCulture);
        }

        public static string GetParameterAsString(string key)
        {
            return RequestHelper.GetParameterAsString(key, null);
        }

        public static string GetParameterAsString(string key, string nullValue)
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[key]))
            {
                return nullValue;
            }

            return HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.QueryString[key]);
        }

        public static bool? GetParameterAsBoolean(string key)
        {
            return RequestHelper.GetParameterAsBoolean(key, null);
        }

        public static bool? GetParameterAsBoolean(string key, bool? nullValue)
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[key]))
            {
                return nullValue;
            }

            return bool.Parse(HttpContext.Current.Request.QueryString[key]);
        }

        public static DateRangeCriteria GetParameterAsDateTime(string key)
        {
            return RequestHelper.GetParameterAsDateTime(key, DateTime.MinValue, DateTime.MaxValue);
        }

        public static DateRangeCriteria GetParameterAsDateTime(string key, DateTime dateFrom, DateTime dateTo)
        {
            var result = new DateRangeCriteria();

            if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[key]))
            {
                var values = HttpContext.Current.Request.QueryString[key].Split(',');

                if (values.Length > 0 && dateFrom != DateTime.MinValue)
                {
                    result.DateFrom = DateTime.Parse(values[0]);
                }

                if (values.Length > 1 && dateTo != DateTime.MaxValue)
                {
                    result.DateTo = DateTime.Parse(values[1]);
                }
            }

            return result;
        }

        public static int? GetParameterAsInteger(string key)
        {
            return RequestHelper.GetParameterAsInteger(key, null);
        }

        public static int? GetParameterAsInteger(string key, int? nullValue)
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[key]))
            {
                return nullValue;
            }

            return int.Parse(HttpContext.Current.Request.QueryString[key]);
        }

        public static DateRangeCriteria GetParameter(string key)
        {
            var result = new DateRangeCriteria();

            try
            {
                string[] values = HttpContext.Current.Request.QueryString[key].Split(',');

                result.DateFrom = DateTime.Parse(values[0]);
                result.DateTo = DateTime.Parse(values[1]);
            }
            catch
            {
            }

            return result;
        }

        public static DateRangeCriteria GetParameter(DateTime startDate, DateTime endDate)
        {
            var result = new DateRangeCriteria();

            result.DateFrom = startDate;
            result.DateTo = endDate;

            return result;
        }

        public static T GetParameter<T>(string key, T defaultValue)
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[key]))
            {
                return (T)Convert.ChangeType(defaultValue, typeof(T), CultureInfo.InvariantCulture);
            }

            return (T)Convert.ChangeType(HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.QueryString[key]), typeof(T), CultureInfo.InvariantCulture);
        }
    }
}
