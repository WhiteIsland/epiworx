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
    public partial class AttachmentInfoList
    {
        private void DataPortal_Fetch(AttachmentCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                this.RaiseListChangedEvents = false;
                this.IsReadOnly = false;

                IQueryable<Data.Attachment> query = ctx.ObjectContext.Attachments;

                if (criteria.AttachmentId != null)
                {
                    query = query.Where(row => row.AttachmentId == criteria.AttachmentId);
                }

                if (criteria.SourceType != null)
                {
                    query = query.Where(row => row.SourceType == (int)criteria.SourceType);
                }

                if (criteria.SourceId != null)
                {
                    query = query.Where(row => row.SourceId == criteria.SourceId);
                }

                if (criteria.Name != null)
                {
                    query = query.Where(row => row.Name == criteria.Name);
                }

                if (criteria.FileType != null)
                {
                    query = query.Where(row => row.FileType == criteria.FileType);
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

                var data = query.AsEnumerable().Select(AttachmentInfo.FetchAttachmentInfo);

                this.AddRange(data);

                this.IsReadOnly = true;
                this.RaiseListChangedEvents = true;
            }
        }
    }
}
