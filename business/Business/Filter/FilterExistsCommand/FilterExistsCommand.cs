using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class FilterExistsCommand : Csla.CommandBase<FilterExistsCommand>
    {
        public int? FilterId { get; set; }
        private bool Success { get; set; }

        public static bool Exists(int categoryId)
        {
            FilterExistsCommand result = null;
            result = Csla.DataPortal.Execute(new FilterExistsCommand(categoryId));
            return result.Success;
        }

        private FilterExistsCommand(int categoryId)
        {
            this.FilterId = categoryId;
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

                var data = query.Select(row => row);

                this.Success = data.Count() > 0;
            }
        }
    }
}
