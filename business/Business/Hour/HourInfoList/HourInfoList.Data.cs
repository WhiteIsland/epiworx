using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class HourInfoList
    {
        private void DataPortal_Fetch(HourCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                this.RaiseListChangedEvents = false;
                this.IsReadOnly = false;

                IQueryable<Data.Hour> query = ctx.ObjectContext.Hours
                    .Include("Project")
                    .Include("Task")
                    .Include("User");
                ;

                if (criteria.HourId != null)
                {
                    query = query.Where(row => row.HourId == criteria.HourId);
                }

                if (criteria.TaskId != null)
                {
                    query = query.Where(row => row.TaskId == criteria.TaskId);
                }

                if (criteria.ProjectId != null && criteria.ProjectId.Count() != 0)
                {
                    query = query.Where(row => criteria.ProjectId.Contains(row.ProjectId));
                }

                if (criteria.UserId != null && criteria.UserId.Count() != 0)
                {
                    query = query.Where(row => criteria.UserId.Contains(row.UserId));
                }

                if (criteria.Date.DateFrom.Date != DateTime.MinValue.Date)
                {
                    query = query.Where(row => row.Date >= criteria.Date.DateFrom);
                }

                if (criteria.Date.DateTo.Date != DateTime.MaxValue.Date)
                {
                    query = query.Where(row => row.Date <= criteria.Date.DateTo);
                }

                if (criteria.Duration != null)
                {
                    query = query.Where(row => row.Duration == criteria.Duration);
                }

                if (criteria.Labels != null)
                {
                    query = query.Where(row => row.Labels == criteria.Labels);
                }

                if (criteria.IsArchived != null)
                {
                    query = query.Where(row => row.IsArchived == criteria.IsArchived);
                }

                if (criteria.Notes != null)
                {
                    query = query.Where(row => row.Notes == criteria.Notes);
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

                var data = query.AsEnumerable().Select(HourInfo.FetchHourInfo);

                this.AddRange(data);

                this.IsReadOnly = true;
                this.RaiseListChangedEvents = true;
            }
        }
    }
}
