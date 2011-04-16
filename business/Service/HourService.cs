using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Service
{
    [Serializable]
    public class HourService
    {
        public static Hour HourFetch(int hourId)
        {
            return Hour.FetchHour(
                new HourCriteria
                    {
                        HourId = hourId
                    });
        }

        public static HourInfoList HourFetchInfoList()
        {
            return HourService.HourFetchInfoList(
                new HourCriteria());
        }

        public static HourInfoList HourFetchInfoList(DateTime startDate, DateTime endDate)
        {
            return HourService.HourFetchInfoList(
                new HourCriteria
                {
                    Date = new DateRangeCriteria(startDate, endDate)
                });
        }

        public static HourInfoList HourFetchInfoList(ITask task)
        {
            return HourService.HourFetchInfoList(
                new HourCriteria
                    {
                        TaskId = new[] { task.TaskId }
                    });
        }

        public static HourInfoList HourFetchInfoList(ITask[] task)
        {
            return HourService.HourFetchInfoList(
                new HourCriteria
                    {
                        TaskId = task.Select(row => row.TaskId).ToArray()
                    });
        }

        public static HourInfoList HourFetchInfoList(HourCriteria criteria)
        {
            return HourInfoList.FetchHourInfoList(criteria);
        }

        public static Hour HourSave(Hour hour)
        {
            if (!hour.IsValid)
            {
                return hour;
            }

            Hour result;

            if (hour.IsNew)
            {
                result = HourService.HourInsert(hour);
            }
            else
            {
                result = HourService.HourUpdate(hour);
            }

            return result;
        }

        public static Hour HourArchive(int hourId)
        {
            var hour = HourService.HourFetch(hourId);

            if (hour.IsArchived)
            {
                return hour;
            }

            hour.IsArchived = true;

            hour = HourService.HourSave(hour);

            return hour;
        }

        public static Hour[] HourArchive(int[] hourIds)
        {
            return hourIds
                .Select(HourService.HourArchive)
                .ToArray();
        }

        public static Hour HourUnarchive(int hourId)
        {
            var hour = HourService.HourFetch(hourId);

            if (!hour.IsArchived)
            {
                return hour;
            }

            hour.IsArchived = false;

            hour = HourService.HourSave(hour);

            return hour;
        }

        public static Hour[] HourUnarchive(int[] hourIds)
        {
            return hourIds
               .Select(HourService.HourUnarchive)
               .ToArray();
        }

        public static Hour HourSave(Hour hour, Task task)
        {
            if (!hour.IsValid)
            {
                return hour;
            }

            Hour result;

            if (hour.IsNew)
            {
                result = HourService.HourInsert(hour);
            }
            else
            {
                result = HourService.HourUpdate(hour);
            }

            return result;
        }

        public static Hour HourInsert(Hour hour)
        {
            hour = hour.Save();

            FeedService.FeedAdd("Created", hour);

            return hour;
        }

        public static Hour HourUpdate(Hour hour)
        {
            hour = hour.Save();

            FeedService.FeedAdd("Updated", hour);

            return hour;
        }

        public static Hour HourNew()
        {
            return Hour.NewHour();
        }

        public static bool HourDelete(Hour hour)
        {
            Hour.DeleteHour(
                new HourCriteria
                    {
                        HourId = hour.HourId
                    });

            FeedService.FeedAdd("Deleted", hour);

            return true;
        }

        public static bool HourDelete(int hourId)
        {
            return HourService.HourDelete(
                HourService.HourFetch(hourId));
        }
    }
}