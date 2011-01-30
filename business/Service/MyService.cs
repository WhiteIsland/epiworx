using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Security;

namespace Epiworx.Service
{
    [Serializable]
    public class MyService
    {
        public static FeedInfoList FeedFetchInfoList(int maximumRecords)
        {
            return FeedService.FeedFetchInfoList(
                new FeedCriteria
                {
                    CreatedBy = BusinessPrincipal.GetCurrentIdentity().UserId,
                    SortBy = "CreatedDate",
                    SortOrder = ListSortDirection.Ascending,
                    MaximumRecords = maximumRecords
                });
        }

        public static TaskInfoList TaskFetchInfoList()
        {
            return TaskService.TaskFetchInfoList(
                new TaskCriteria
                    {
                        AssignedTo = new[] { BusinessPrincipal.GetCurrentIdentity().UserId },
                        IsArchived = false
                    });
        }

        public static FilterInfoList FilterFetchInfoList()
        {
            return MyService.FilterFetchInfoList(null);
        }

        public static FilterInfoList FilterFetchInfoList(string target)
        {
            return FilterService.FilterFetchInfoList(
                new FilterCriteria
                {
                    Target = target,
                    CreatedBy = BusinessPrincipal.GetCurrentIdentity().UserId
                });
        }

        public static HourInfoList HourFetchInfoList(DateTime startDate, DateTime endDate)
        {
            return HourService.HourFetchInfoList(
                new HourCriteria
                {
                    UserId = new[] { BusinessPrincipal.GetCurrentIdentity().UserId },
                    Date = new DateRangeCriteria(startDate, endDate)
                });
        }
    }
}
