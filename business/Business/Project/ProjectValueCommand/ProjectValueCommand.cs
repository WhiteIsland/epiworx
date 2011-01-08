using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class ProjectValueCommand : Csla.CommandBase<ProjectValueCommand>
    {
        private int? ProjectId { get; set; }
        private string ColumnName { get; set; }
        private object Value { get; set; }

        public static object FetchValue(int projectId, string columnName)
        {
            ProjectValueCommand result = null;
            result = Csla.DataPortal.Execute(new ProjectValueCommand(projectId, columnName));
            return result.Value;
        }

        private ProjectValueCommand(int projectId, string columnName)
        {
            this.ProjectId = projectId;
            this.ColumnName = columnName;
        }

        protected override void DataPortal_Execute()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Project> query = ctx.ObjectContext.Projects;

                if (this.ProjectId != null)
                {
                    query = query.Where(row => row.ProjectId == this.ProjectId);
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
                    case "IsActive":
                        this.Value = data.IsActive;
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
