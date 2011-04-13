using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Project : ISource
    {
        public SourceType SourceType
        {
            get { return Business.SourceType.Project; }
        }

        public int SourceId
        {
            get { return this.ProjectId; }
        }
    }
}
