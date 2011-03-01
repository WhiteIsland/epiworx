using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class NoteInfo
    {
        private void Fetch(Data.Note data)
        {
            this.LoadProperty(NoteIdProperty, data.NoteId);
            this.LoadProperty(SourceTypeProperty, data.SourceType);
            this.LoadProperty(SourceIdProperty, data.SourceId);
            this.LoadProperty(BodyProperty, data.Body);
            this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
            this.LoadProperty(ModifiedByNameProperty, data.ModifiedByUser.Name);
            this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            this.LoadProperty(CreatedByProperty, data.CreatedBy);
            this.LoadProperty(CreatedByNameProperty, data.CreatedByUser.Name);
            this.LoadProperty(CreatedDateProperty, data.CreatedDate);
        }
    }
}
