using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface ILabel
    {
        int SourceId { get; }
        SourceType SourceType { get; }
        string Name { get; }
        int CreatedBy { get; }
        string CreatedByName { get; }
        DateTime CreatedDate { get; }
    }
}
