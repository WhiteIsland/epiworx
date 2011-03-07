using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class TaskLabelByCountInfoList
    {
        private void DataPortal_Fetch()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                this.RaiseListChangedEvents = false;
                this.IsReadOnly = false;

                var data = ctx.ObjectContext.TaskLabels
                    .Include("CreatedByUser")
                    .GroupBy(row => row.Name)
                    .AsEnumerable()
                    .Select(group => TaskLabelByCountInfo.FetchTaskLabelByCount(group.Key, group.Count()));

                this.AddRange(data);

                this.IsReadOnly = true;
                this.RaiseListChangedEvents = true;
            }
        }
    }
}
