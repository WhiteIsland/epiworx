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

        public static HourInfoList HourFetchInfoList(ITask task)
        {
            return HourService.HourFetchInfoList(
                new HourCriteria
                    {
                        TaskId = task.TaskId
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
            return hour.Save();
        }

        public static Hour HourUpdate(Hour hour)
        {
            return hour.Save();
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

            return true;
        }

        public static bool HourDelete(int hourId)
        {
            return HourService.HourDelete(
                HourService.HourFetch(hourId));
        }
    }
}