﻿using System;
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
        [WebGet(UriTemplate = "Projects/?token={token}")]
        public List<ProjectData> GetProjects(string token)
        {
            if (ConfigurationManager.AppSettings["Token"] != token)
            {
                throw new SecurityException();
            }

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
    }
}