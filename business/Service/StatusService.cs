using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Service
{
    [Serializable]
    public class StatusService
    {
        public static Status StatusFetch(int statusId)
        {
            return Status.FetchStatus(
                new StatusCriteria
                    {
                        StatusId = statusId
                    });
        }

        public static StatusInfoList StatusFetchInfoList()
        {
            return StatusService.StatusFetchInfoList(
                new StatusCriteria());
        }

        internal static StatusInfoList StatusFetchInfoList(StatusCriteria criteria)
        {
            return StatusInfoList.FetchStatusInfoList(criteria);
        }

        public static Status StatusSave(Status status)
        {
            if (!status.IsValid)
            {
                return status;
            }

            Status result;

            if (status.IsNew)
            {
                result = StatusService.StatusInsert(status);
            }
            else
            {
                result = StatusService.StatusUpdate(status);
            }

            return result;
        }

        public static Status StatusInsert(Status status)
        {
            status = status.Save();

            FeedService.FeedAdd("Created", status);

            return status;
        }

        public static Status StatusUpdate(Status status)
        {
            status = status.Save();

            FeedService.FeedAdd("Updated", status);

            return status;
        }

        public static Status StatusNew()
        {
            return Status.NewStatus();
        }

        public static bool StatusDelete(Status status)
        {
            Status.DeleteStatus(
                new StatusCriteria
                    {
                        StatusId = status.StatusId
                    });

            FeedService.FeedAdd("Deleted", status);

            return true;
        }

        public static bool StatusDelete(int statusId)
        {
            return StatusService.StatusDelete(
                StatusService.StatusFetch(statusId));
        }
    }
}