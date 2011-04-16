using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Epiworx.Business;
using Epiworx.Core;
using Epiworx.Service;

namespace Epiworx.WebMvc.Helpers
{
    public class DataHelper
    {
        public static string Clip(string text, int maxLength)
        {
            if (text.Length <= maxLength)
            {
                return text;
            }

            return text.Substring(0, maxLength) + "...";
        }

        public static string ToString(string value, int maximumLength)
        {
            if (value.Length > maximumLength)
            {
                return string.Format("{0}...", value.Substring(0, maximumLength));
            }

            return value;
        }

        public static string ToString(IEnumerable<ICategory> categories, int[] categoryIds, string defaultText)
        {
            var sb = new StringBuilder();

            foreach (var categoryId in categoryIds)
            {
                if (categoryId != 0)
                {
                    if (sb.Length != 0)
                    {
                        sb = sb.Append(" or ");
                    }

                    sb = sb.Append(categories.Where(row => row.CategoryId == categoryId).SingleOrDefault().Name);
                }
            }

            if (sb.Length == 0)
            {
                sb = sb.Append(defaultText);
            }

            return sb.ToString();
        }

        public static string ToString(IEnumerable<IProject> projects, int[] projectIds, string defaultText)
        {
            var sb = new StringBuilder();

            foreach (var projectId in projectIds)
            {
                if (projectId != 0)
                {
                    if (sb.Length != 0)
                    {
                        sb = sb.Append(" or ");
                    }

                    sb = sb.Append(projects.Where(row => row.ProjectId == projectId).SingleOrDefault().Name);
                }
            }

            if (sb.Length == 0)
            {
                sb = sb.Append(defaultText);
            }

            return sb.ToString();
        }

        public static string ToString(IEnumerable<IStatus> statuses, int[] statusIds, string defaultText)
        {
            var sb = new StringBuilder();

            foreach (var statusId in statusIds)
            {
                if (statusId != 0)
                {
                    if (sb.Length != 0)
                    {
                        sb = sb.Append(" or ");
                    }

                    sb = sb.Append(statuses.Where(row => row.StatusId == statusId).SingleOrDefault().Name);
                }
            }

            if (sb.Length == 0)
            {
                sb = sb.Append(defaultText);
            }

            return sb.ToString();
        }

        public static string ToString(IEnumerable<IUser> users, int? userId, string defaultText)
        {
            var sb = new StringBuilder();

            if (userId != 0)
            {
                if (sb.Length != 0)
                {
                    sb = sb.Append(" or ");
                }

                sb = sb.Append(users.Where(row => row.UserId == userId).SingleOrDefault().Name);
            }

            if (sb.Length == 0)
            {
                sb = sb.Append(defaultText);
            }

            return sb.ToString();
        }

        public static string ToString(IEnumerable<IUser> users, int[] userIds, string defaultText)
        {
            var sb = new StringBuilder();

            foreach (var userId in userIds)
            {
                if (userId != 0)
                {
                    if (sb.Length != 0)
                    {
                        sb = sb.Append(" or ");
                    }

                    sb = sb.Append(users.Where(row => row.UserId == userId).SingleOrDefault().Name);
                }
            }

            if (sb.Length == 0)
            {
                sb = sb.Append(defaultText);
            }

            return sb.ToString();
        }

        public static bool? ToBoolean(int? value)
        {
            if (!value.HasValue)
            {
                return null;
            }

            if (value.Value == 1)
            {
                return false;
            }

            if (value.Value == -1)
            {
                return true;
            }

            return null;
        }

        public static bool? ToBoolean(int? value, bool defaultValue)
        {
            if (!value.HasValue)
            {
                return defaultValue;
            }

            if (value.Value == 1)
            {
                return false;
            }

            if (value.Value == -1)
            {
                return true;
            }

            return null;
        }

        public static int ToInteger(int? value)
        {
            if (!value.HasValue)
            {
                return 0;
            }

            return value.Value;
        }

        public static SourceType? ToSourceType(int? value)
        {
            if (!value.HasValue)
            {
                return SourceType.None;
            }

            return (SourceType)value;
        }

        public static IQueryable<ICategory> GetCategoryList()
        {
            return CategoryService.CategoryFetchInfoList()
                 .Cast<ICategory>()
                 .Where(row => row.IsActive)
                 .OrderBy(row => row.Ordinal)
                 .ThenBy(row => row.Name)
                 .AsQueryable();
        }

        public static IQueryable<NameValueItem> GetRoleList()
        {
            var result = new NameValueItemCollection();

            result.Add((int)Role.None, "None");
            result.Add((int)Role.Contribute, "Contribute");
            result.Add((int)Role.FullControl, "Full Control");
            result.Add((int)Role.Review, "Review");

            return result.AsQueryable();
        }

        public static IQueryable<IStatus> GetStatusList()
        {
            return StatusService.StatusFetchInfoList()
                 .Cast<IStatus>()
                 .Where(row => row.IsActive)
                 .OrderBy(row => row.Ordinal)
                 .ThenBy(row => row.Name)
                 .AsQueryable();
        }

        public static IQueryable<ISprint> GetSprintList()
        {
            return SprintService.SprintFetchInfoList()
                 .Cast<ISprint>()
                 .OrderBy(row => row.ProjectName)
                 .ThenByDescending(row => row.EstimatedCompletedDate)
                 .AsQueryable();
        }

        public static IQueryable<ISprint> GetSprintList(int projectId)
        {
            return SprintService.SprintFetchInfoList(new SprintCriteria { ProjectId = projectId })
                 .Cast<ISprint>()
                 .OrderBy(row => row.ProjectName)
                 .ThenByDescending(row => row.EstimatedCompletedDate)
                 .AsQueryable();
        }

        public static IQueryable<ITaskLabelByCount> GetTaskLabelByCountList()
        {
            return TaskService.TaskLabelByCountFetchInfoList()
                 .Cast<ITaskLabelByCount>()
                 .OrderBy(row => row.Name)
                 .AsQueryable();
        }

        public static IQueryable<IProject> GetProjectList()
        {
            return DataHelper.GetProjectList(null);
        }

        public static IQueryable<IProject> GetProjectList(bool? isActive)
        {
            return ProjectService.ProjectFetchInfoList(
                    new ProjectCriteria
                        {
                            IsActive = isActive
                        })
                 .Cast<IProject>()
                 .OrderBy(row => row.Name)
                 .AsQueryable();
        }

        public static IQueryable<IUser> GetUserList()
        {
            return UserService.UserFetchInfoList()
                 .Cast<IUser>()
                 .Where(row => row.IsActive)
                 .OrderBy(row => row.Name)
                 .AsQueryable();
        }
    }
}