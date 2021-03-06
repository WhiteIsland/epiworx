using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class StatusInfoList
    {
        private void DataPortal_Fetch(StatusCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                this.RaiseListChangedEvents = false;
                this.IsReadOnly = false;

                IQueryable<Data.Status> query = ctx.ObjectContext.Statuses;

                if (criteria.StatusId != null)
                {
                    query = query.Where(row => row.StatusId == criteria.StatusId);
                }

                if (criteria.Name != null)
                {
                    query = query.Where(row => row.Name == criteria.Name);
                }

                if (criteria.Description != null)
                {
                    query = query.Where(row => row.Description == criteria.Description);
                }

                if (criteria.Ordinal != null)
                {
                    query = query.Where(row => row.Ordinal == criteria.Ordinal);
                }

                if (criteria.ForeColor != null)
                {
                    query = query.Where(row => row.ForeColor == criteria.ForeColor);
                }

                if (criteria.BackColor != null)
                {
                    query = query.Where(row => row.BackColor == criteria.BackColor);
                }

                if (criteria.IsStarted != null)
                {
                    query = query.Where(row => row.IsStarted == criteria.IsStarted);
                }

                if (criteria.IsCompleted != null)
                {
                    query = query.Where(row => row.IsCompleted == criteria.IsCompleted);
                }

                if (criteria.IsActive != null)
                {
                    query = query.Where(row => row.IsActive == criteria.IsActive);
                }

                if (criteria.IsArchived != null)
                {
                    query = query.Where(row => row.IsArchived == criteria.IsArchived);
                }

                if (criteria.ModifiedBy != null)
                {
                    query = query.Where(row => row.ModifiedBy == criteria.ModifiedBy);
                }

                if (criteria.ModifiedDate.DateFrom.Date != DateTime.MinValue.Date)
                {
                    query = query.Where(row => row.ModifiedDate >= criteria.ModifiedDate.DateFrom);
                }

                if (criteria.ModifiedDate.DateTo.Date != DateTime.MaxValue.Date)
                {
                    query = query.Where(row => row.ModifiedDate <= criteria.ModifiedDate.DateTo);
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

                var data = query.AsEnumerable().Select(StatusInfo.FetchStatusInfo);

                this.AddRange(data);

                this.IsReadOnly = true;
                this.RaiseListChangedEvents = true;
            }
        }
    }
}
