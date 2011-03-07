using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class TaskLabels
    {
        private void Fetch(Data.Label[] data)
        {
            this.RaiseListChangedEvents = false;

            foreach (var row in data)
            {
                this.Add(TaskLabel.FetchTaskLabel(row));
            }

            this.RaiseListChangedEvents = true;
        }
    }
}
