using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class TaskInfoList
    {
        internal static TaskInfoList FetchTaskInfoList(TaskCriteria criteria)
        {
            return Csla.DataPortal.Fetch<TaskInfoList>(criteria);
        }
    }
}
