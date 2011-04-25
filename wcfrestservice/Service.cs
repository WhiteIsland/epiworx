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
                .OrderBy(project => project.Name)
                .AsQueryable();

            var notes = ctx.Notes
                .Include("ModifiedByUser")
                .Include("CreatedByUser")
                .Where(note => note.SourceType == 2
                               && projects.Select(project => project.ProjectId).Contains(note.SourceId))
                .OrderByDescending(note => note.CreatedDate);

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

        [WebGet(UriTemplate = "Categories")]
        public List<CategoryData> GetCategories()
        {
            var ctx = new ApplicationEntities(ConfigurationManager.ConnectionStrings["ApplicationConnection"].ToString());
            var result = new List<CategoryData>();

            var categories = ctx.Categories
                .Where(category => category.IsActive)
                .OrderBy(category => category.Name)
                .AsQueryable();

            foreach (var category in categories)
            {
                var categoryData = new CategoryData(category);

                result.Add(categoryData);
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

        [WebGet(UriTemplate = "Tasks/{user}")]
        public List<TaskData> GetTasksForUser(string user)
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
                .Include("CreatedByUser")
                .Where(row => row.AssignedToUser.Name == user);

            foreach (var task in tasks)
            {
                result.Add(new TaskData(task));
            }

            ctx.Dispose();

            return result;
        }

        [WebGet(UriTemplate = "Statuses")]
        public List<StatusData> GetStatuses()
        {
            var ctx = new ApplicationEntities(ConfigurationManager.ConnectionStrings["ApplicationConnection"].ToString());
            var result = new List<StatusData>();

            var statuses = ctx.Statuses
                .Where(status => status.IsActive)
                .OrderBy(status => status.Name)
                .AsQueryable();

            foreach (var status in statuses)
            {
                var statusData = new StatusData(status);

                result.Add(statusData);
            }

            ctx.Dispose();

            return result;
        }

        [WebGet(UriTemplate = "Users")]
        public List<UserData> GetUsers()
        {
            var ctx = new ApplicationEntities(ConfigurationManager.ConnectionStrings["ApplicationConnection"].ToString());
            var result = new List<UserData>();

            var users = ctx.Users
                .Where(user => user.IsActive)
                .OrderBy(user => user.Name)
                .AsQueryable();

            foreach (var user in users)
            {
                var userData = new UserData(user);

                result.Add(userData);
            }

            ctx.Dispose();

            return result;
        }

        [WebGet(UriTemplate = "Hours?start={start}&end={end}")]
        public List<HourData> GetHours(DateTime start, DateTime end)
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
                .Include("CreatedByUser")
                .Where(row => row.Date >= start && row.Date <= end);

            foreach (var hour in hours)
            {
                result.Add(new HourData(hour));
            }

            ctx.Dispose();

            return result;
        }

        [WebGet(UriTemplate = "Hours/{user}?start={start}&end={end}")]
        public List<HourData> GetHoursForUser(string user, DateTime start, DateTime end)
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
                .Include("CreatedByUser")
                .Where(row => row.User.Name == user)
                .Where(row => row.Date >= start && row.Date <= end);

            foreach (var hour in hours)
            {
                result.Add(new HourData(hour));
            }

            ctx.Dispose();

            return result;
        }

        [WebGet(UriTemplate = "Invoices?start={start}&end={end}")]
        public List<InvoiceData> GetInvoices(DateTime start, DateTime end)
        {
            var ctx = new ApplicationEntities(ConfigurationManager.ConnectionStrings["ApplicationConnection"].ToString());
            var result = new List<InvoiceData>();

            var invoices = ctx.Invoices
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
                .Include("CreatedByUser")
                .Where(row => row.PreparedDate >= start && row.PreparedDate <= end);

            foreach (var invoice in invoices)
            {
                result.Add(new InvoiceData(invoice));
            }

            ctx.Dispose();

            return result;
        }
    }
}
