using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class FeedExistsCommand : Csla.CommandBase<FeedExistsCommand>
    {
        public int? FeedId { get; set; }
        private bool Success { get; set; }

        public static bool Exists(int feedId)
        {
            FeedExistsCommand result = null;
            result = Csla.DataPortal.Execute(new FeedExistsCommand(feedId));
            return result.Success;
        }

        private FeedExistsCommand(int feedId)
        {
            this.FeedId = feedId;
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

                var data = query.Select(row => row);

                this.Success = data.Count() > 0;
            }
        }
    }
}
