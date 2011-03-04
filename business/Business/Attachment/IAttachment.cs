using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IAttachment
    {
        int AttachmentId { get; }
        SourceType SourceType { get; }
        int SourceId { get; }
        string Name { get; }
        string FileType { get; }
        byte[] FileData { get; }
        int ModifiedBy { get; }
        string ModifiedByName { get; }
        DateTime ModifiedDate { get; }
        int CreatedBy { get; }
        string CreatedByName { get; }
        DateTime CreatedDate { get; }
    }
}
