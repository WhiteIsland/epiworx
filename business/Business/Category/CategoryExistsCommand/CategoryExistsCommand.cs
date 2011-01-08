using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class CategoryExistsCommand : Csla.CommandBase<CategoryExistsCommand>
    {
        public int? CategoryId { get; set; }
        private bool Success { get; set; }

        public static bool Exists(int categoryId)
        {
            CategoryExistsCommand result = null;
            result = Csla.DataPortal.Execute(new CategoryExistsCommand(categoryId));
            return result.Success;
        }

        private CategoryExistsCommand(int categoryId)
        {
            this.CategoryId = categoryId;
        }

        protected override void DataPortal_Execute()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Category> query = ctx.ObjectContext.Categories;

                if (this.CategoryId != null)
                {
                    query = query.Where(row => row.CategoryId == this.CategoryId);
                }

                var data = query.Select(row => row);

                this.Success = data.Count() > 0;
            }
        }
    }
}
