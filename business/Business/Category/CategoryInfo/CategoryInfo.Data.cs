using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class CategoryInfo
    {
        private void Fetch(Data.Category data)
        {
            this.LoadProperty(CategoryIdProperty, data.CategoryId);
            this.LoadProperty(NameProperty, data.Name);
            this.LoadProperty(DescriptionProperty, data.Description);
            this.LoadProperty(OrdinalProperty, data.Ordinal);
            this.LoadProperty(ForeColorProperty, data.ForeColor);
            this.LoadProperty(BackColorProperty, data.BackColor);
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
