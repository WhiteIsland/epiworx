using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class TaskLabels
    {
        public override string ToString()
        {
            var result = new System.Text.StringBuilder();

            foreach (var taskLabel in this)
            {
                if (result.Length != 0)
                {
                    result.Append(" ");
                }

                result.Append(taskLabel.Name);
            }

            return result.ToString();
        }

        public TaskLabel this[string name]
        {
            get { return this.FirstOrDefault(child => child.Name.Equals(name)); }
        }

        public TaskLabel Add(string name)
        {
            var child = TaskLabel.NewTaskLabel(name);
            this.Add(child);
            return child;
        }

        public void Remove(string name)
        {
            foreach (var child in this.Where(child => child.Name.Equals(name)))
            {
                this.Remove(child);
                break;
            }
        }

        public bool Contains(string name)
        {
            return this.Any(child => child.Name.Equals(name));
        }

        internal static TaskLabels NewTaskLabels()
        {
            return Csla.DataPortal.CreateChild<TaskLabels>();
        }

        internal TaskLabels FetchTaskLabels(Task task)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                this.RaiseListChangedEvents = false;

                var query = ctx.ObjectContext.Labels
                     .Include("CreatedByUser")
                     .Where(row => row.SourceId == task.SourceId
                         && row.SourceType == (int)task.SourceType);

                var data = query.AsEnumerable().Select(TaskLabel.FetchTaskLabel);

                this.AddRange(data);

                this.RaiseListChangedEvents = true;
            }

            return this;
        }

        internal static TaskLabels FetchTaskLabels(Data.Label[] data)
        {
            var childList = new TaskLabels();
            childList.Fetch(data);
            return childList;
        }
    }
}
