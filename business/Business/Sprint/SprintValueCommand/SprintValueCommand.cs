using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class SprintValueCommand : Csla.CommandBase<SprintValueCommand>
    {
        private int? SprintId { get; set; }
        private string ColumnName { get; set; }
        private object Value { get; set; }

        public static object FetchValue(int sprintId, string columnName)
        {
            SprintValueCommand result = null;
            result = Csla.DataPortal.Execute(new SprintValueCommand(sprintId, columnName));
            return result.Value;
        }

        private SprintValueCommand(int sprintId, string columnName)
        {
            this.SprintId = sprintId;
            this.ColumnName = columnName;
        }

        protected override void DataPortal_Execute()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Sprint> query = ctx.ObjectContext.Sprints;

                if (this.SprintId != null)
                {
                    query = query.Where(row => row.SprintId == this.SprintId);
                }

                var data = query.Single();

                switch (this.ColumnName)
                {
                    case "Name":
                        this.Value = string.Format("{0}", data.Name);
                        break;
                    case "IsCompleted":
                        this.Value = data.IsCompleted;
                        break;
                    case "CompletedDate":
                        this.Value = data.CompletedDate;
                        break;
                    case "EstimatedCompletedDate":
                        this.Value = data.EstimatedCompletedDate;
                        break;
                    case "IsActive":
                        this.Value = data.IsActive;
                        break;
                    case "IsArchived":
                        this.Value = data.IsArchived;
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
