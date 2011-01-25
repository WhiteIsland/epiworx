using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class SprintExistsCommand : Csla.CommandBase<SprintExistsCommand>
    {
        public int? SprintId { get; set; }
        private bool Success { get; set; }

        public static bool Exists(int sprintId)
        {
            SprintExistsCommand result = null;
            result = Csla.DataPortal.Execute(new SprintExistsCommand(sprintId));
            return result.Success;
        }

        private SprintExistsCommand(int sprintId)
        {
            this.SprintId = sprintId;
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

                var data = query.Select(row => row);

                this.Success = data.Count() > 0;
            }
        }
    }
}
