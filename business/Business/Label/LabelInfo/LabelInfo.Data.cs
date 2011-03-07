using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class LabelInfo
    {
        private void Fetch(Data.Label data)
        {
            this.LoadProperty(SourceIdProperty, data.SourceId);
            this.LoadProperty(SourceTypeProperty, data.SourceType);
            this.LoadProperty(NameProperty, data.Name);
            this.LoadProperty(CreatedByProperty, data.CreatedBy);
            this.LoadProperty(CreatedByNameProperty, data.CreatedByUser.Name);
            this.LoadProperty(CreatedDateProperty, data.CreatedDate);
        }
    }
}
