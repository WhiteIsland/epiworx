using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class FeedInfoList
    {
        private void DataPortal_Fetch(FeedCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                this.RaiseListChangedEvents = false;
                this.IsReadOnly = false;

                IQueryable<Data.Feed> query = ctx.ObjectContext.Feeds
                    .Include("CreatedByUser");

                if (criteria.FeedId != null)
                {
                    query = query.Where(row => row.FeedId == criteria.FeedId);
                }

                if (criteria.Type != null)
                {
                    query = query.Where(row => row.Type == criteria.Type);
                }

                if (criteria.Data != null)
                {
                    query = query.Where(row => row.Data == criteria.Data);
                }

                if (criteria.CreatedBy != null)
                {
                    query = query.Where(row => row.CreatedBy == criteria.CreatedBy);
                }

                if (criteria.CreatedDate.DateFrom.Date != DateTime.MinValue.Date)
                {
                    query = query.Where(row => row.CreatedDate >= criteria.CreatedDate.DateFrom);
                }

                if (criteria.CreatedDate.DateTo.Date != DateTime.MaxValue.Date)
                {
                    query = query.Where(row => row.CreatedDate <= criteria.CreatedDate.DateTo);
                }

                if (criteria.SortBy != null)
                {
                    query = query.OrderBy(string.Format(
                        "{0} {1}",
                        criteria.SortBy,
                        criteria.SortOrder == ListSortDirection.Ascending ? "ASC" : "DESC"));
                }

                if (criteria.MaximumRecords != null)
                {
                    query = query.Take(criteria.MaximumRecords.Value);
                }

                var data = query.AsEnumerable().Select(FeedInfo.FetchFeedInfo);

                this.AddRange(data);

                this.IsReadOnly = true;
                this.RaiseListChangedEvents = true;
            }
        }
    }
}
