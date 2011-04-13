using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data
{
    public partial class Hour
    {
        public string TaskName
        {
            get { return this.Task == null ? string.Empty : this.Task.Description; }
        }
    }
}
