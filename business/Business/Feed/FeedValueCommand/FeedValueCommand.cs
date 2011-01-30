using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class FeedValueCommand : Csla.CommandBase<FeedValueCommand>
    {
        private int? FeedId { get; set; }
        private string ColumnName { get; set; }
        private object Value { get; set; }

        public static object FetchValue(int feedId, string columnName)
        {
            FeedValueCommand result = null;
            result = Csla.DataPortal.Execute(new FeedValueCommand(feedId, columnName));
            return result.Value;
        }

        private FeedValueCommand(int feedId, string columnName)
        {
            this.FeedId = feedId;
            this.ColumnName = columnName;
        }

        protected override void DataPortal_Execute()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Feed> query = ctx.ObjectContext.Feeds;

                if (this.FeedId != null)
                {
                    query = query.Where(row => row.FeedId == this.FeedId);
                }

                var data = query.Single();

                switch (this.ColumnName)
                {
                    case "Name":
                        this.Value = string.Format("{0}", data.Type);
                        break;
                    case "Type":
                        this.Value = data.Type;
                        break;
                    case "Data":
                        this.Value = data.Data;
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
