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
            return TaskInfo.FetchTaskInfo(data, 0, 0, 0, 0);
        }

        internal static TaskInfo FetchTaskInfo(
            Data.Task data,
            decimal? duration,
            int? numberOfNotes,
            int? numberOfAttachments,
            int? numberOfInvoices)
        {
            var result = new TaskInfo();
            result.Fetch(data, duration, numberOfNotes, numberOfAttachments, numberOfInvoices);
            return result;
        }
    }
}
