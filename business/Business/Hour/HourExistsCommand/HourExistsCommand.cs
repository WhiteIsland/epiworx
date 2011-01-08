using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class HourExistsCommand : Csla.CommandBase<HourExistsCommand>
    {
        public int? HourId { get; set; }
        private bool Success { get; set; }

        public static bool Exists(int hourId)
        {
            HourExistsCommand result = null;
            result = Csla.DataPortal.Execute(new HourExistsCommand(hourId));
            return result.Success;
        }

        private HourExistsCommand(int hourId)
        {
            this.HourId = hourId;
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

                var data = query.Select(row => row);

                this.Success = data.Count() > 0;
            }
        }
    }
}
