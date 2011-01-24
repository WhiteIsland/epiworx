using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface ITask
    {
        int TaskId { get; }
        IProject Project { get; }
        int ProjectId { get; }
        string ProjectName { get; }
        ISprint Sprint { get; }
        int SprintId { get; }
        string SprintName { get; }
        ICategory Category { get; }
        int CategoryId { get; }
        string CategoryName { get; }
        IStatus Status { get; }
        int StatusId { get; }
        string StatusName { get; }
        string Description { get; }
        int AssignedTo { get; }
        string AssignedToName { get; }
        DateTime AssignedDate { get; }
        DateTime StartDate { get; }
        DateTime CompletedDate { get; }
        DateTime EstimatedCompletedDate { get; }
        decimal Duration { get; }
        decimal EstimatedDuration { get; }
        string Labels { get; }
        bool IsArchived { get; }
        string Notes { get; }
        int ModifiedBy { get; }
        string ModifiedByName { get; }
        DateTime ModifiedDate { get; }
        int CreatedBy { get; }
        string CreatedByName { get; }
        DateTime CreatedDate { get; }
    }
}
