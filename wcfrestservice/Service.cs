using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Epiworx.Data;

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
            var ctx = new ApplicationEntities(ConfigurationManager.ConnectionStrings["ApplicationConnection"].ToString());
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

                result.Add(projectData);
            }

            ctx.Dispose();

            return result;
        }

        [WebGet(UriTemplate = "Tasks")]
        public List<TaskData> GetTasks()
        {
            var ctx = new ApplicationEntities(ConfigurationManager.ConnectionStrings["ApplicationConnection"].ToString());
            var result = new List<TaskData>();

            var tasks = ctx.Tasks
                .Include("Category")
                .Include("Project")
                .Include("Project.ModifiedByUser")
                .Include("Project.CreatedByUser")
                .Include("Status")
                .Include("AssignedToUser")
                .Include("ModifiedByUser")
                .Include("CreatedByUser");

            foreach (var task in tasks)
            {
                result.Add(new TaskData(task));
            }

            ctx.Dispose();

            return result;
        }

        [WebGet(UriTemplate = "Hours")]
        public List<HourData> GetHours()
        {
            var ctx = new ApplicationEntities(ConfigurationManager.ConnectionStrings["ApplicationConnection"].ToString());
            var result = new List<HourData>();

            var hours = ctx.Hours
                .Include("User")
                .Include("Task")
                .Include("Task.Category")
                .Include("Task.Project")
                .Include("Task.Project.ModifiedByUser")
                .Include("Task.Project.CreatedByUser")
                .Include("Task.Status")
                .Include("Task.AssignedToUser")
                .Include("Task.ModifiedByUser")
                .Include("Task.CreatedByUser")
                .Include("ModifiedByUser")
                .Include("CreatedByUser");

            foreach (var hour in hours)
            {
                result.Add(new HourData(hour));
            }

            ctx.Dispose();

            return result;
        }
    }
}
