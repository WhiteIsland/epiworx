using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class SprintInfoList
    {
        private void DataPortal_Fetch(SprintCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                this.RaiseListChangedEvents = false;
                this.IsReadOnly = false;

                IQueryable<Data.Sprint> query = ctx.ObjectContext.Sprints;

                if (criteria.SprintId != null)
                {
                    query = query.Where(row => row.SprintId == criteria.SprintId);
                }

                if (criteria.Name != null)
                {
                    query = query.Where(row => row.Name == criteria.Name);
                }

                if (criteria.ProjectId != null)
                {
                    query = query.Where(row => row.ProjectId == criteria.ProjectId);
                }

                if (criteria.IsCompleted != null)
                {
                    query = query.Where(row => row.IsCompleted == criteria.IsCompleted);
                }

                if (criteria.CompletedDate.DateFrom.Date != DateTime.MinValue.Date)
                {
                    query = query.Where(row => row.CompletedDate >= criteria.CompletedDate.DateFrom);
                }

                if (criteria.CompletedDate.DateTo.Date != DateTime.MaxValue.Date)
                {
                    query = query.Where(row => row.CompletedDate <= criteria.CompletedDate.DateTo);
                }

                if (criteria.EstimatedCompletedDate.DateFrom.Date != DateTime.MinValue.Date)
                {
                    query = query.Where(row => row.EstimatedCompletedDate >= criteria.EstimatedCompletedDate.DateFrom);
                }

                if (criteria.EstimatedCompletedDate.DateTo.Date != DateTime.MaxValue.Date)
                {
                    query = query.Where(row => row.EstimatedCompletedDate <= criteria.EstimatedCompletedDate.DateTo);
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

                var data = query.AsEnumerable().Select(SprintInfo.FetchSprintInfo);

                this.AddRange(data);

                this.IsReadOnly = true;
                this.RaiseListChangedEvents = true;
            }
        }
    }
}
