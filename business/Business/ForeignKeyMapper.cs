using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    internal class ForeignKeyMapper
    {
        public static string FetchSourceName(ISource source)
        {
            var result = string.Empty;

            switch (source.SourceType)
            {
                case SourceType.Task:
                    result = source.SourceId.ToString();
                    break;
                default:
                    break;
            }

            return result;
        }

        public static string FetchSourceName(SourceType sourceType, int sourceId)
        {
            var result = string.Empty;

            switch (sourceType)
            {
                case SourceType.Task:
                    result = sourceId.ToString();
                    break;
                default:
                    break;
            }

            return result;
        }

        public static IUser FetchUser(int userId)
        {
            if (userId == 0)
            {
                return null;
            }

            var user = User.FetchUser(new UserCriteria { UserId = userId });

            return user;
        }

        public static string FetchUserName(int userId)
        {
            if (userId == 0)
            {
                return string.Empty;
            }

            var user = User.FetchUser(new UserCriteria { UserId = userId });

            return user.Name;
        }

        public static ICategory FetchCategory(int categoryId)
        {
            if (categoryId == 0)
            {
                return null;
            }

            var category = Category.FetchCategory(new CategoryCriteria { CategoryId = categoryId });

            return category;
        }

        public static string FetchCategoryName(int categoryId)
        {
            if (categoryId == 0)
            {
                return string.Empty;
            }

            var category = Category.FetchCategory(new CategoryCriteria { CategoryId = categoryId });

            return category.Name;
        }

        public static IProject FetchProject(int projectId)
        {
            if (projectId == 0)
            {
                return null;
            }

            var project = Project.FetchProject(new ProjectCriteria { ProjectId = projectId });

            return project;
        }

        public static string FetchProjectName(int projectId)
        {
            if (projectId == 0)
            {
                return string.Empty;
            }

            var project = Project.FetchProject(new ProjectCriteria { ProjectId = projectId });

            return project.Name;
        }

        public static IStatus FetchStatus(int statusId)
        {
            if (statusId == 0)
            {
                return null;
            }

            var status = Status.FetchStatus(new StatusCriteria { StatusId = statusId });

            return status;
        }

        public static string FetchStatusName(int statusId)
        {
            if (statusId == 0)
            {
                return string.Empty;
            }

            var status = Status.FetchStatus(new StatusCriteria { StatusId = statusId });

            return status.Name;
        }
    }
}
