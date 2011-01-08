using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class TaskInfo
    {
        public override string ToString()
        {
            return string.Format("{0}", this.TaskId);
        }

        internal static TaskInfo FetchTaskInfo(Data.Task data)
        {
            var result = new TaskInfo();
            result.Fetch(data);
            return result;
        }
    }
}
