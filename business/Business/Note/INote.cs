using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface INote
    {
        int NoteId { get; }
        SourceType SourceType { get; }
        int SourceId { get; }
        string Body { get; }
        int ModifiedBy { get; }
        string ModifiedByName { get; }
        string ModifiedByEmail { get; }
        DateTime ModifiedDate { get; }
        int CreatedBy { get; }
        string CreatedByName { get; }
        string CreatedByEmail { get; }
        DateTime CreatedDate { get; }
    }
}
