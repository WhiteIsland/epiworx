using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class StatusInfo
    {
        private void Fetch(Data.Status data)
        {
            this.LoadProperty(StatusIdProperty, data.StatusId);
            this.LoadProperty(NameProperty, data.Name);
            this.LoadProperty(DescriptionProperty, data.Description);
            this.LoadProperty(OrdinalProperty, data.Ordinal);
            this.LoadProperty(ForeColorProperty, data.ForeColor);
            this.LoadProperty(BackColorProperty, data.BackColor);
            this.LoadProperty(IsStartedProperty, data.IsStarted);
            this.LoadProperty(IsCompletedProperty, data.IsCompleted);
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
