using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class FilterInfoList
    {
        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                this.RaiseListChangedEvents = false;
                this.IsReadOnly = false;

                IQueryable<Data.Filter> query = ctx.ObjectContext.Filters;

                if (criteria.FilterId != null)
                {
                    query = query.Where(row => row.FilterId == criteria.FilterId);
                }

                if (criteria.Name != null)
                {
                    query = query.Where(row => row.Name == criteria.Name);
                }

                if (criteria.Target != null)
                {
                    query = query.Where(row => row.Target == criteria.Target);
                }

                if (criteria.Query != null)
                {
                    query = query.Where(row => row.Query == criteria.Query);
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

                var data = query.AsEnumerable().Select(FilterInfo.FetchFilterInfo);

                this.AddRange(data);

                this.IsReadOnly = true;
                this.RaiseListChangedEvents = true;
            }
        }
    }
}
