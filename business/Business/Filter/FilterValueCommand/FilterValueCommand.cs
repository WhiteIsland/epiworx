using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class FilterValueCommand : Csla.CommandBase<FilterValueCommand>
    {
        private int? FilterId { get; set; }
        private string ColumnName { get; set; }
        private object Value { get; set; }

        public static object FetchValue(int categoryId, string columnName)
        {
            FilterValueCommand result = null;
            result = Csla.DataPortal.Execute(new FilterValueCommand(categoryId, columnName));
            return result.Value;
        }

        private FilterValueCommand(int categoryId, string columnName)
        {
            this.FilterId = categoryId;
            this.ColumnName = columnName;
        }

        protected override void DataPortal_Execute()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Filter> query = ctx.ObjectContext.Filters;

                if (this.FilterId != null)
                {
                    query = query.Where(row => row.FilterId == this.FilterId);
                }

                var data = query.Single();

                switch (this.ColumnName)
                {
                    case "Name":
                        this.Value = string.Format("{0}", data.Name);
                        break;
                    case "Target":
                        this.Value = data.Target;
                        break;
                    case "Query":
                        this.Value = data.Query;
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
