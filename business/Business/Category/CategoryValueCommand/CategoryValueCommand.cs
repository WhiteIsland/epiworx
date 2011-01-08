using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class CategoryValueCommand : Csla.CommandBase<CategoryValueCommand>
    {
        private int? CategoryId { get; set; }
        private string ColumnName { get; set; }
        private object Value { get; set; }

        public static object FetchValue(int categoryId, string columnName)
        {
            CategoryValueCommand result = null;
            result = Csla.DataPortal.Execute(new CategoryValueCommand(categoryId, columnName));
            return result.Value;
        }

        private CategoryValueCommand(int categoryId, string columnName)
        {
            this.CategoryId = categoryId;
            this.ColumnName = columnName;
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
