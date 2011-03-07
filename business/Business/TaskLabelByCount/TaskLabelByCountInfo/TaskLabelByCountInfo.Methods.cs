using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class TaskLabelByCountInfo
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        internal static TaskLabelByCountInfo FetchTaskLabelByCount(string name, int quantity)
        {
            var result = new TaskLabelByCountInfo();
            result.Fetch(name, quantity);
            return result;
        }
    }
}
