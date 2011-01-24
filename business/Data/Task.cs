using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data
{
    public partial class Task
    {
        public string SprintName
        {
            get { return this.Sprint == null ? string.Empty : this.Sprint.Name; }
        }

        public string AssignedToName
        {
            get { return this.AssignedToUser == null ? string.Empty : this.AssignedToUser.Name; }
        }
    }
}
