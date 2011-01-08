using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class ProjectExistsCommand : Csla.CommandBase<ProjectExistsCommand>
    {
        public int? ProjectId { get; set; }
        private bool Success { get; set; }

        public static bool Exists(int projectId)
        {
            ProjectExistsCommand result = null;
            result = Csla.DataPortal.Execute(new ProjectExistsCommand(projectId));
            return result.Success;
        }

        private ProjectExistsCommand(int projectId)
        {
            this.ProjectId = projectId;
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

                var data = query.Select(row => row);

                this.Success = data.Count() > 0;
            }
        }
    }
}
