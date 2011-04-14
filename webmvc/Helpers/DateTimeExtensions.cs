using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epiworx.WebMvc.Helpers
{
    public static class DateTimeExtensions
    {
        public static string ToRelativeDate(this DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;

            // span is less than or equal to 60 seconds, measure in seconds.
            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                return timeSpan.Seconds + " seconds ago";
            }

            // span is less than or equal to 60 minutes, measure in minutes.
            if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                return timeSpan.Minutes > 1
                    ? "about " + timeSpan.Minutes + " minutes ago"
                    : "about a minute ago";
            }

            // span is less than or equal to 24 hours, measure in hours.
            if (timeSpan <= TimeSpan.FromHours(24))
            {
                return timeSpan.Hours > 1
                    ? "about " + timeSpan.Hours + " hours ago"
                    : "about an hour ago";
            }

            // span is less than or equal to 30 days (1 month), measure in days.
            if (timeSpan <= TimeSpan.FromDays(30))
            {
                return timeSpan.Days > 1
                    ? "about " + timeSpan.Days + " days ago"
                    : "about a day ago";
            }

            // span is less than or equal to 365 days (1 year), measure in months.
            if (timeSpan <= TimeSpan.FromDays(365))
            {
                return timeSpan.Days > 30
                    ? "about " + timeSpan.Days / 30 + " months ago"
                    : "about a month ago";
            }

            // span is greater than 365 days (1 year), measure in years.
            return timeSpan.Days > 365
                ? "about " + timeSpan.Days / 365 + " years ago"
                : "about a year ago";
        }
    }
}