using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Epiworx.WcfRestService
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service
    {
        [WebGet(UriTemplate = "Projects")]
        public List<ProjectData> GetProjects()
        {
            var ctx = new Data.ApplicationEntities(ConfigurationManager.ConnectionStrings["ApplicationConnection"].ToString());
            var result = new List<ProjectData>();

            var projects = ctx.Projects
                .Include("ModifiedByUser")
                .Include("CreatedByUser")
                .Where(project => project.IsActive)
                .AsQueryable();

            var notes = ctx.Notes
                .Include("ModifiedByUser")
                .Include("CreatedByUser")
                .Where(note => note.SourceType == 2
                               && projects.Select(project => project.ProjectId).Contains(note.SourceId));

            var tasks = ctx.Tasks
                .Include("Category")
                .Include("Status")
                .Where(task => projects.Select(project => project.ProjectId).Contains(task.ProjectId));

            foreach (var project in projects)
            {
                var projectData = new ProjectData(project);

                foreach (var note in notes.Where(note => note.SourceId == project.ProjectId))
                {
                    projectData.Notes.Add(new NoteData(note));
                }

                foreach (var task in tasks.Where(task => task.ProjectId == project.ProjectId))
                {
                    projectData.Tasks.Add(new TaskData(task));
                }

                result.Add(projectData);
            }

            ctx.Dispose();

            return result;
        }
    }
}
