using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class StatusValueCommand : Csla.CommandBase<StatusValueCommand>
    {
        private int? StatusId { get; set; }
        private string ColumnName { get; set; }
        private object Value { get; set; }

        public static object FetchValue(int statusId, string columnName)
        {
            StatusValueCommand result = null;
            result = Csla.DataPortal.Execute(new StatusValueCommand(statusId, columnName));
            return result.Value;
        }

        private StatusValueCommand(int statusId, string columnName)
        {
            this.StatusId = statusId;
            this.ColumnName = columnName;
        }

        protected override void DataPortal_Execute()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Status> query = ctx.ObjectContext.Statuses;

                if (this.StatusId != null)
                {
                    query = query.Where(row => row.StatusId == this.StatusId);
                }

                var data = query.Single();

                switch (this.ColumnName)
                {
                    case "Name":
                        this.Value = string.Format("{0}", data.Name);
                        break;
                    case "Description":
                        this.Value = data.Description;
                        break;
                    case "Ordinal":
                        this.Value = data.Ordinal;
                        break;
                    case "ForeColor":
                        this.Value = data.ForeColor;
                        break;
                    case "BackColor":
                        this.Value = data.BackColor;
                        break;
                    case "IsStarted":
                        this.Value = data.IsStarted;
                        break;
                    case "IsCompleted":
                        this.Value = data.IsCompleted;
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
