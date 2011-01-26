using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IHour
    {
        int HourId { get; }
        int ProjectId { get; }
        string ProjectName { get; }
        int TaskId { get; }
        string TaskName { get; }
        IUser User { get; }
        int UserId { get; }
        string UserName { get; }
        DateTime Date { get; }
        decimal Duration { get; }
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
