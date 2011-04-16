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
    public partial class InvoiceInfoList
    {
        private void DataPortal_Fetch(InvoiceCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                this.RaiseListChangedEvents = false;
                this.IsReadOnly = false;

                IQueryable<Data.Invoice> query = ctx.ObjectContext.Invoices
                    .Include("Task")
                    .Include("Task.Project")
                    .Include("CreatedByUser")
                    .Include("ModifiedByUser");

                if (criteria.InvoiceId != null)
                {
                    query = query.Where(row => row.InvoiceId == criteria.InvoiceId);
                }

                if (criteria.ProjectId != null)
                {
                    query = query.Where(row => criteria.ProjectId.Contains(row.Task.ProjectId));
                }

                if (criteria.Number != null)
                {
                    query = query.Where(row => row.Number == criteria.Number);
                }

                if (criteria.Description != null)
                {
                    query = query.Where(row => row.Description == criteria.Description);
                }

                if (criteria.TaskId != null)
                {
                    query = query.Where(row => row.TaskId == criteria.TaskId);
                }

                if (criteria.PreparedDate.DateFrom.Date != DateTime.MinValue.Date)
                {
                    query = query.Where(row => row.PreparedDate >= criteria.PreparedDate.DateFrom);
                }

                if (criteria.PreparedDate.DateTo.Date != DateTime.MaxValue.Date)
                {
                    query = query.Where(row => row.PreparedDate <= criteria.PreparedDate.DateTo);
                }

                if (criteria.Amount != null)
                {
                    query = query.Where(row => row.Amount == criteria.Amount);
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

                if (criteria.Text != null)
                {
                    query = query.Where(row => row.Description.Contains(criteria.Text)
                        || row.Number.Contains(criteria.Text)
                        || row.Task.Project.Name.Contains(criteria.Text));
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

                var data = query.AsEnumerable().Select(InvoiceInfo.FetchInvoiceInfo);

                this.AddRange(data);

                this.IsReadOnly = true;
                this.RaiseListChangedEvents = true;
            }
        }
    }
}
