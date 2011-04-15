using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public class Source : ISource
    {
        public SourceType SourceType { get; set; }
        public int SourceId { get; set; }
    }
}
