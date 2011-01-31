using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface ISprint
    {
        int SprintId { get; }
        string Name { get; }
        IProject Project { get; }
        int ProjectId { get; }
        string ProjectName { get; }
        bool IsCompleted { get; }
        DateTime CompletedDate { get; }
        DateTime EstimatedCompletedDate { get; }
        bool IsActive { get; }
        bool IsArchived { get; }
        int ModifiedBy { get; }
        string ModifiedByName { get; }
        DateTime ModifiedDate { get; }
        int CreatedBy { get; }
        string CreatedByName { get; }
        DateTime CreatedDate { get; }
    }
}
