using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Service
{
    [Serializable]
    public class ProjectService
    {
        public static Project ProjectFetch(int projectId)
        {
            return Project.FetchProject(
                new ProjectCriteria
                    {
                        ProjectId = projectId
                    });
        }

        public static ProjectInfoList ProjectFetchInfoList()
        {
            return ProjectService.ProjectFetchInfoList(
                new ProjectCriteria());
        }

        internal static ProjectInfoList ProjectFetchInfoList(ProjectCriteria criteria)
        {
            return ProjectInfoList.FetchProjectInfoList(criteria);
        }

        public static Project ProjectSave(Project project)
        {
            if (!project.IsValid)
            {
                return project;
            }

            Project result;

            if (project.IsNew)
            {
                result = ProjectService.ProjectInsert(project);
            }
            else
            {
                result = ProjectService.ProjectUpdate(project);
            }

            return result;
        }

        public static Project ProjectInsert(Project project)
        {
            return project.Save();
        }

        public static Project ProjectUpdate(Project project)
        {
            return project.Save();
        }

        public static Project ProjectNew()
        {
            return Project.NewProject();
        }

        public static bool ProjectDelete(Project project)
        {
            Project.DeleteProject(
                new ProjectCriteria
                    {
                        ProjectId = project.ProjectId
                    });

            return true;
        }

        public static bool ProjectDelete(int projectId)
        {
            return ProjectService.ProjectDelete(
                ProjectService.ProjectFetch(projectId));
        }
    }
}