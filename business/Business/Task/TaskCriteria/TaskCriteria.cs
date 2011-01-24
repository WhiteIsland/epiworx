using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class TaskCriteria : Csla.CriteriaBase<TaskCriteria>
    {
        public TaskCriteria()
        {
            this.TaskId = null;
            this.ProjectId = null;
            this.SprintId = null;
            this.CategoryId = null;
            this.StatusId = null;
            this.Description = null;
            this.AssignedTo = null;
            this.AssignedDate = new DateRangeCriteria();
            this.StartDate = new DateRangeCriteria();
            this.CompletedDate = new DateRangeCriteria();
            this.EstimatedCompletedDate = new DateRangeCriteria();
            this.Duration = null;
            this.EstimatedDuration = null;
            this.Label = null;
            this.IsArchived = null;
            this.Notes = null;
            this.ModifiedBy = null;
            this.ModifiedDate = new DateRangeCriteria();
            this.CreatedBy = null;
            this.CreatedDate = new DateRangeCriteria();
            this.Text = null;
            this.MaximumRecords = null;
            this.SortBy = "EstimatedCompletedDate";
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
