using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface ISource
    {
        SourceType SourceType { get; }
        int SourceId { get; }
    }
}
