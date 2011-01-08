using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class TaskInfo
    {
        private void Fetch(Data.Task data)
        {
            this.LoadProperty(TaskIdProperty, data.TaskId);
            this.LoadProperty(ProjectIdProperty, data.ProjectId);
            this.LoadProperty(ProjectNameProperty, data.Project.Name);
            this.LoadProperty(CategoryIdProperty, data.CategoryId);
            this.LoadProperty(CategoryNameProperty, data.Category.Name);
            this.LoadProperty(StatusProperty, StatusInfo.FetchStatusInfo(data.Status));
            this.LoadProperty(StatusIdProperty, data.StatusId);
            this.LoadProperty(StatusNameProperty, data.Status.Name);
            this.LoadProperty(DescriptionProperty, data.Description);
            this.LoadProperty(AssignedToProperty, data.AssignedTo);
            this.LoadProperty(AssignedToNameProperty, data.AssignedToUser == null ? "No one" : data.AssignedToUser.Name);
            this.LoadProperty(AssignedDateProperty, data.AssignedDate);
            this.LoadProperty(StartDateProperty, data.StartDate);
            this.LoadProperty(CompletedDateProperty, data.CompletedDate);
            this.LoadProperty(EstimatedCompletedDateProperty, data.EstimatedCompletedDate);
            this.LoadProperty(DurationProperty, data.Duration);
            this.LoadProperty(EstimatedDurationProperty, data.EstimatedDuration);
            this.LoadProperty(LabelsProperty, data.Labels);
            this.LoadProperty(IsArchivedProperty, data.IsArchived);
            this.LoadProperty(NotesProperty, data.Notes);
            this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
            this.LoadProperty(ModifiedByNameProperty, data.ModifiedByUser.Name);
            this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            this.LoadProperty(CreatedByProperty, data.CreatedBy);
            this.LoadProperty(CreatedByNameProperty, data.CreatedByUser.Name);
            this.LoadProperty(CreatedDateProperty, data.CreatedDate);
        }
    }
}
