using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class TaskInfoList
    {
        private void DataPortal_Fetch(TaskCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                this.RaiseListChangedEvents = false;
                this.IsReadOnly = false;

                IQueryable<Data.Task> query = ctx.ObjectContext.Tasks
                    .Include("Category")
                    .Include("Status")
                    .Include("Project")
                    .Include("AssignedToUser");

                if (criteria.TaskId != null)
                {
                    query = query.Where(row => row.TaskId == criteria.TaskId);
                }

                if (criteria.ProjectId != null)
                {
                    query = query.Where(row => row.ProjectId == criteria.ProjectId);
                }

                if (criteria.CategoryId != null)
                {
                    query = query.Where(row => row.CategoryId == criteria.CategoryId);
                }

                if (criteria.StatusId != null)
                {
                    query = query.Where(row => row.StatusId == criteria.StatusId);
                }

                if (criteria.Description != null)
                {
                    query = query.Where(row => row.Description == criteria.Description);
                }

                if (criteria.AssignedTo != null)
                {
                    query = query.Where(row => row.AssignedTo == criteria.AssignedTo);
                }

                if (criteria.AssignedDate.DateFrom.Date != DateTime.MinValue.Date)
                {
                    query = query.Where(row => row.AssignedDate >= criteria.AssignedDate.DateFrom);
                }

                if (criteria.AssignedDate.DateTo.Date != DateTime.MaxValue.Date)
                {
                    query = query.Where(row => row.AssignedDate <= criteria.AssignedDate.DateTo);
                }

                if (criteria.StartDate.DateFrom.Date != DateTime.MinValue.Date)
                {
                    query = query.Where(row => row.StartDate >= criteria.StartDate.DateFrom);
                }

                if (criteria.StartDate.DateTo.Date != DateTime.MaxValue.Date)
                {
                    query = query.Where(row => row.StartDate <= criteria.StartDate.DateTo);
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

                if (criteria.Duration != null)
                {
                    query = query.Where(row => row.Duration == criteria.Duration);
                }

                if (criteria.EstimatedDuration != null)
                {
                    query = query.Where(row => row.EstimatedDuration == criteria.EstimatedDuration);
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

                if (criteria.Text != null)
                {
                    query = query.Where(row => SqlFunctions.StringConvert((double)row.TaskId).Contains(criteria.Text)
                        || row.Description.Contains(criteria.Text)
                        || row.Project.Name.Contains(criteria.Text));
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

                var data = query.AsEnumerable().Select(TaskInfo.FetchTaskInfo);

                this.AddRange(data);

                this.IsReadOnly = true;
                this.RaiseListChangedEvents = true;
            }
        }
    }
}