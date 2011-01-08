using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class TaskExistsCommand : Csla.CommandBase<TaskExistsCommand>
    {
        public int? TaskId { get; set; }
        private bool Success { get; set; }

        public static bool Exists(int taskId)
        {
            TaskExistsCommand result = null;
            result = Csla.DataPortal.Execute(new TaskExistsCommand(taskId));
            return result.Success;
        }

        private TaskExistsCommand(int taskId)
        {
            this.TaskId = taskId;
        }

        protected override void DataPortal_Execute()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Task> query = ctx.ObjectContext.Tasks;

                if (this.TaskId != null)
                {
                    query = query.Where(row => row.TaskId == this.TaskId);
                }

                var data = query.Select(row => row);

                this.Success = data.Count() > 0;
            }
        }
    }
}
