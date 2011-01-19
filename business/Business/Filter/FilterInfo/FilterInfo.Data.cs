using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class FilterInfo
    {
        private void Fetch(Data.Filter data)
        {
            this.LoadProperty(FilterIdProperty, data.FilterId);
            this.LoadProperty(NameProperty, data.Name);
            this.LoadProperty(TargetProperty, data.Target);
            this.LoadProperty(QueryProperty, data.Query);
            this.LoadProperty(IsActiveProperty, data.IsActive);
            this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
            this.LoadProperty(ModifiedByNameProperty, data.ModifiedByUser.Name);
            this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            this.LoadProperty(CreatedByProperty, data.CreatedBy);
            this.LoadProperty(CreatedByNameProperty, data.CreatedByUser.Name);
            this.LoadProperty(CreatedDateProperty, data.CreatedDate);
        }
    }
}
