using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class SprintInfo
    {
        private void Fetch(Data.Sprint data)
        {
            if (data == null)
            {
                return;
            }

            this.LoadProperty(SprintIdProperty, data.SprintId);
            this.LoadProperty(NameProperty, data.Name);
            this.LoadProperty(ProjectProperty, ProjectInfo.FetchProjectInfo(data.Project));
            this.LoadProperty(ProjectIdProperty, data.ProjectId);
            this.LoadProperty(ProjectNameProperty, data.Project.Name);
            this.LoadProperty(IsCompletedProperty, data.IsCompleted);
            this.LoadProperty(CompletedDateProperty, data.CompletedDate);
            this.LoadProperty(EstimatedCompletedDateProperty, data.EstimatedCompletedDate);
            this.LoadProperty(IsActiveProperty, data.IsActive);
            this.LoadProperty(IsArchivedProperty, data.IsArchived);
            this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
            this.LoadProperty(ModifiedByNameProperty, data.ModifiedByUser.Name);
            this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            this.LoadProperty(CreatedByProperty, data.CreatedBy);
            this.LoadProperty(CreatedByNameProperty, data.CreatedByUser.Name);
            this.LoadProperty(CreatedDateProperty, data.CreatedDate);
        }
    }
}
