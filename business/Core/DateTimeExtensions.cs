using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Core
{
    public static class DateTimeExtensions
    {
        public static bool IsLate(this DateTime d)
        {
            return (d.Date < DateTime.Today.Date);
        }

        public static bool IsToday(this DateTime d)
        {
            return (d.Date == DateTime.Today.Date);
        }

        public static bool IsYesterday(this DateTime d)
        {
            return (d.Date == DateTime.Today.AddDays(-1).Date);
        }

        public static bool IsTomorrow(this DateTime d)
        {
            return (d.Date == DateTime.Today.AddDays(1).Date);
        }

        public static bool IsThisWeek(this DateTime d)
        {
            var startDate = DateTime.Today;

            while (startDate.DayOfWeek != DayOfWeek.Sunday)
            {
                startDate = startDate.AddDays(-1);
            }

            var endDate = startDate.AddDays(6);

            return (d.Date >= startDate.Date & d.Date <= endDate.Date);
        }

        public static bool IsThisMonth(this DateTime d)
        {
            var startDate = DateTime.Today;

            startDate = Convert.ToDateTime(string.Format("{0}/1/{1}", startDate.Month, startDate.Year));

            var endDate = startDate.AddMonths(1).AddDays(-1);

            return (d.Date >= startDate.Date & d.Date <= endDate.Date);
        }

        public static bool IsNextMonth(this DateTime d)
        {
            var startDate = DateTime.Today;

            startDate = Convert.ToDateTime(string.Format("{0}/1/{1}", startDate.Month, startDate.Year)).AddMonths(1);

            var endDate = startDate.AddMonths(1).AddDays(-1);

            return (d.Date >= startDate.Date & d.Date <= endDate.Date);
        }

        public static DateTime ToStartOfWeek(this DateTime d)
        {
            var startDate = d;

            while (startDate.DayOfWeek != DayOfWeek.Sunday)
            {
                startDate = startDate.AddDays(-1);
            }

            return startDate;
        }

        public static DateTime ToStartOfMonth(this DateTime d)
        {
            var startDate = d;

            if (startDate.Day != 1)
            {
                startDate = startDate.AddDays(-startDate.Day).AddDays(1);
            }

            return startDate;
        }

        public static DateTime ToStartOfYear(this DateTime d)
        {
            var startDate = DateTime.Parse("1/1/" + d.Year);

            return startDate;
        }

        public static DateTime ToEndOfYear(this DateTime d)
        {
            return d.ToStartOfYear().AddYears(1).AddDays(-1);
        }

        public static DateTime ToStartOfNextWeek(this DateTime d)
        {
            return d.ToStartOfWeek().AddDays(7);
        }

        public static DateTime ToStartOfPreviousMonth(this DateTime d)
        {
            return d.ToStartOfMonth().AddMonths(-1);
        }

        public static DateTime ToStartOfPreviousWeek(this DateTime d)
        {
            return d.ToStartOfWeek().AddDays(-7);
        }

        public static DateTime ToStartOfPreviousYear(this DateTime d)
        {
            return d.ToStartOfYear().AddYears(-1);
        }

        public static DateTime ToEndOfPreviousYear(this DateTime d)
        {
            return d.ToEndOfYear().AddYears(-1);
        }

        public static DateTime ToEndOfWeek(this DateTime d)
        {
            return d.ToStartOfWeek().AddDays(6);
        }

        public static DateTime ToEndOfMonth(this DateTime d)
        {
            return d.ToStartOfMonth().AddMonths(1).AddDays(-1);
        }

        public static DateTime ToEndOfNextWeek(this DateTime d)
        {
            return d.ToStartOfNextWeek().AddDays(6);
        }

        public static DateTime ToEndOfPreviousWeek(this DateTime d)
        {
            return d.ToStartOfNextWeek().AddDays(-6);
        }

        public static DateTime ToEndOfPreviousMonth(this DateTime d)
        {
            return d.ToStartOfPreviousMonth().ToEndOfMonth();
        }

        public static DateTime RoundMinutes(this DateTime d)
        {
            var date = d;

            date.AddSeconds(-date.Second);
            date.AddMilliseconds(-date.Millisecond);

            var remainder = date.Minute % 15;

            date = date.AddMinutes(remainder * -1);

            if (remainder > 7)
            {
                date = date.AddMinutes(15);
            }

            return date;
        }
    }
}
