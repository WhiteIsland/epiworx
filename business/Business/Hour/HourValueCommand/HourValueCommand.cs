using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class HourValueCommand : Csla.CommandBase<HourValueCommand>
    {
        private int? HourId { get; set; }
        private string ColumnName { get; set; }
        private object Value { get; set; }

        public static object FetchValue(int hourId, string columnName)
        {
            HourValueCommand result = null;
            result = Csla.DataPortal.Execute(new HourValueCommand(hourId, columnName));
            return result.Value;
        }

        private HourValueCommand(int hourId, string columnName)
        {
            this.HourId = hourId;
            this.ColumnName = columnName;
        }

        protected override void DataPortal_Execute()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Hour> query = ctx.ObjectContext.Hours;

                if (this.HourId != null)
                {
                    query = query.Where(row => row.HourId == this.HourId);
                }

                var data = query.Single();

                switch (this.ColumnName)
                {
                    case "Name":
                        this.Value = string.Format("{0:d} to {1}", data.Date, data.User.Name);
                        break;
                    case "TaskId":
                        this.Value = data.TaskId;
                        break;
                    case "UserId":
                        this.Value = data.UserId;
                        break;
                    case "Date":
                        this.Value = data.Date;
                        break;
                    case "Duration":
                        this.Value = data.Duration;
                        break;
                    case "Labels":
                        this.Value = data.Labels;
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
