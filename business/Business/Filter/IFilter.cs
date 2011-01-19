using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IFilter
    {
        int FilterId { get; }
        string Name { get; }
        string Target { get; }
        string Query { get; }
        bool IsActive { get; }
        int ModifiedBy { get; }
        string ModifiedByName { get; }
        DateTime ModifiedDate { get; }
        int CreatedBy { get; }
        string CreatedByName { get; }
        DateTime CreatedDate { get; }
    }
}
