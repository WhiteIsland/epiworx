using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Task : ISource
    {
        public SourceType SourceType
        {
            get { return Business.SourceType.Task; }
        }

        public int SourceId
        {
            get { return this.TaskId; }
        }
    }
}
