using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Core
{
    public static class DateTimeExtensions
    {
        public static bool IsLate(this DateTime dateTime)
        {
            return (dateTime.Date < DateTime.Today.Date);
        }

        public static bool IsToday(this DateTime dateTime)
        {
            return (dateTime.Date == DateTime.Today.Date);
        }

        public static bool IsYesterday(this DateTime dateTime)
        {
            return (dateTime.Date == DateTime.Today.AddDays(-1).Date);
        }

        public static bool IsTomorrow(this DateTime dateTime)
        {
            return (dateTime.Date == DateTime.Today.AddDays(1).Date);
        }

        public static bool IsThisWeek(this DateTime dateTime)
        {
            var startDate = DateTime.Today;

            while (startDate.DayOfWeek != DayOfWeek.Sunday)
            {
                startDate = startDate.AddDays(-1);
            }

            var endDate = startDate.AddDays(6);

            return (dateTime.Date >= startDate.Date & dateTime.Date <= endDate.Date);
        }

        public static bool IsThisMonth(this DateTime dateTime)
        {
            var startDate = DateTime.Today;

            startDate = Convert.ToDateTime(string.Format("{0}/1/{1}", startDate.Month, startDate.Year));

            var endDate = startDate.AddMonths(1).AddDays(-1);

            return (dateTime.Date >= startDate.Date & dateTime.Date <= endDate.Date);
        }

        public static bool IsNextMonth(this DateTime dateTime)
        {
            var startDate = DateTime.Today;

            startDate = Convert.ToDateTime(string.Format("{0}/1/{1}", startDate.Month, startDate.Year)).AddMonths(1);

            var endDate = startDate.AddMonths(1).AddDays(-1);

            return (dateTime.Date >= startDate.Date & dateTime.Date <= endDate.Date);
        }

        public static DateTime ToStartOfWeek(this DateTime dateTime)
        {
            var startDate = dateTime;

            while (startDate.DayOfWeek != DayOfWeek.Sunday)
            {
                startDate = startDate.AddDays(-1);
            }

            return startDate;
        }

        public static DateTime ToStartOfMonth(this DateTime dateTime)
        {
            var startDate = dateTime;

            if (startDate.Day != 1)
            {
                startDate = startDate.AddDays(-startDate.Day).AddDays(1);
            }

            return startDate;
        }

        public static DateTime ToStartOfYear(this DateTime dateTime)
        {
            var startDate = DateTime.Parse("1/1/" + dateTime.Year);

            return startDate;
        }

        public static DateTime ToEndOfYear(this DateTime dateTime)
        {
            return dateTime.ToStartOfYear().AddYears(1).AddDays(-1);
        }

        public static DateTime ToStartOfNextWeek(this DateTime dateTime)
        {
            return dateTime.ToStartOfWeek().AddDays(7);
        }

        public static DateTime ToStartOfPreviousMonth(this DateTime dateTime)
        {
            return dateTime.ToStartOfMonth().AddMonths(-1);
        }

        public static DateTime ToStartOfPreviousWeek(this DateTime dateTime)
        {
            return dateTime.ToStartOfWeek().AddDays(-7);
        }

        public static DateTime ToStartOfPreviousYear(this DateTime dateTime)
        {
            return dateTime.ToStartOfYear().AddYears(-1);
        }

        public static DateTime ToEndOfPreviousYear(this DateTime dateTime)
        {
            return dateTime.ToEndOfYear().AddYears(-1);
        }

        public static DateTime ToEndOfWeek(this DateTime dateTime)
        {
            return dateTime.ToStartOfWeek().AddDays(6);
        }

        public static DateTime ToEndOfMonth(this DateTime dateTime)
        {
            return dateTime.ToStartOfMonth().AddMonths(1).AddDays(-1);
        }

        public static DateTime ToEndOfNextWeek(this DateTime dateTime)
        {
            return dateTime.ToStartOfNextWeek().AddDays(6);
        }

        public static DateTime ToEndOfPreviousWeek(this DateTime dateTime)
        {
            return dateTime.ToStartOfNextWeek().AddDays(-6);
        }

        public static DateTime ToEndOfPreviousMonth(this DateTime dateTime)
        {
            return dateTime.ToStartOfPreviousMonth().ToEndOfMonth();
        }

        public static DateTime RoundMinutes(this DateTime dateTime)
        {
            dateTime.AddSeconds(-dateTime.Second);
            dateTime.AddMilliseconds(-dateTime.Millisecond);

            var remainder = dateTime.Minute % 15;

            dateTime = dateTime.AddMinutes(remainder * -1);

            if (remainder > 7)
            {
                dateTime = dateTime.AddMinutes(15);
            }

            return dateTime;
        }

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
