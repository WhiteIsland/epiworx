using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class TaskValueCommand : Csla.CommandBase<TaskValueCommand>
    {
        private int? TaskId { get; set; }
        private string ColumnName { get; set; }
        private object Value { get; set; }

        public static object FetchValue(int taskId, string columnName)
        {
            TaskValueCommand result = null;
            result = Csla.DataPortal.Execute(new TaskValueCommand(taskId, columnName));
            return result.Value;
        }

        private TaskValueCommand(int taskId, string columnName)
        {
            this.TaskId = taskId;
            this.ColumnName = columnName;
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

                var data = query.Single();

                switch (this.ColumnName)
                {
                    case "Name":
                        this.Value = string.Format("{0}", data.Description);
                        break;
                    case "ProjectId":
                        this.Value = data.ProjectId;
                        break;
                    case "CategoryId":
                        this.Value = data.CategoryId;
                        break;
                    case "StatusId":
                        this.Value = data.StatusId;
                        break;
                    case "Description":
                        this.Value = data.Description;
                        break;
                    case "AssignedTo":
                        this.Value = data.AssignedTo;
                        break;
                    case "AssignedDate":
                        this.Value = data.AssignedDate;
                        break;
                    case "StartDate":
                        this.Value = data.StartDate;
                        break;
                    case "CompletedDate":
                        this.Value = data.CompletedDate;
                        break;
                    case "EstimatedCompletedDate":
                        this.Value = data.EstimatedCompletedDate;
                        break;
                    case "Duration":
                        this.Value = data.Duration;
                        break;
                    case "EstimatedDuration":
                        this.Value = data.EstimatedDuration;
                        break;
                    case "IsArchived":
                        this.Value = data.IsArchived;
                        break;
                    case "Notes":
                        this.Value = data.Notes;
                        break;
                    case "ModifiedBy":
                        this.Value = data.ModifiedBy;
                        break;
                    case "ModifiedDate":
                        this.Value = data.ModifiedDate;
                        break;
                    case "CreatedBy":
                        this.Value = data.CreatedBy;
                        break;
                    case "CreatedDate":
                        this.Value = data.CreatedDate;
                        break;
                    default:
                        throw new ArgumentException("No such column name.");
                }
            }
        }
    }
}
