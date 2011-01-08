using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Security;

namespace Epiworx.Service
{
    [Serializable]
    public class MyService
    {
        public static TaskInfoList TaskFetchInfoList()
        {
            return TaskService.TaskFetchInfoList(
                new TaskCriteria
                    {
                        AssignedTo = BusinessPrincipal.GetCurrentIdentity().UserId,
                        IsArchived = false
                    });
        }

        public static HourInfoList HourFetchInfoList(DateTime startDate, DateTime endDate)
        {
            return HourService.HourFetchInfoList(
                new HourCriteria
                {
                    UserId = BusinessPrincipal.GetCurrentIdentity().UserId,
                    Date = new DateRangeCriteria(startDate, endDate)
                });
        }
    }
}
