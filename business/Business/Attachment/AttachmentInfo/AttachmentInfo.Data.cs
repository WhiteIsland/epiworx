using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class AttachmentInfo
    {
        private void Fetch(Data.Attachment data)
        {
            this.LoadProperty(AttachmentIdProperty, data.AttachmentId);
            this.LoadProperty(SourceTypeProperty, data.SourceType);
            this.LoadProperty(SourceIdProperty, data.SourceId);
            this.LoadProperty(NameProperty, data.Name);
            this.LoadProperty(FileTypeProperty, data.FileType);
            this.LoadProperty(FileDataProperty, data.FileData);
            this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
            this.LoadProperty(ModifiedByNameProperty, data.ModifiedByUser.Name);
            this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            this.LoadProperty(CreatedByProperty, data.CreatedBy);
            this.LoadProperty(CreatedByNameProperty, data.CreatedByUser.Name);
            this.LoadProperty(CreatedDateProperty, data.CreatedDate);
        }
    }
}
