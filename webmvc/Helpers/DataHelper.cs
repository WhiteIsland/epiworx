using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Epiworx.Business;
using Epiworx.Core;
using Epiworx.Service;

namespace Epiworx.WebMvc.Helpers
{
    public class DataHelper
    {
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

        public static int ToInteger(bool? value)
        {
            if (!value.HasValue)
            {
                return 0;
            }

            if (value.Value)
            {
                return -1;
            }

            return 1;
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

        public static IQueryable<IProject> GetProjectList()
        {
            return ProjectService.ProjectFetchInfoList()
                 .Cast<IProject>()
                 .Where(row => row.IsActive)
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