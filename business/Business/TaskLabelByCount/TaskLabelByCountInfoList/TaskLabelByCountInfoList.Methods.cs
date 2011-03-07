using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class TaskLabelByCountInfoList
    {
        internal static TaskLabelByCountInfoList FetchTaskLabelByCountInfoList()
        {
            return Csla.DataPortal.Fetch<TaskLabelByCountInfoList>();
        }
    }
}
