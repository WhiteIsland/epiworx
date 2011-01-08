using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class StatusExistsCommand : Csla.CommandBase<StatusExistsCommand>
    {
        public int? StatusId { get; set; }
        private bool Success { get; set; }

        public static bool Exists(int statusId)
        {
            StatusExistsCommand result = null;
            result = Csla.DataPortal.Execute(new StatusExistsCommand(statusId));
            return result.Success;
        }

        private StatusExistsCommand(int statusId)
        {
            this.StatusId = statusId;
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

                var data = query.Select(row => row);

                this.Success = data.Count() > 0;
            }
        }
    }
}
