using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.Service;
using Epiworx.WebMvc.Helpers;
using Epiworx.WebMvc.Models;
using Epiworx.WebMvc.Properties;

namespace Epiworx.WebMvc.Controllers
{
    public class FeedController : BaseController
    {
        [Authorize]
        public ActionResult Index(int? userId, string date, string sortBy, string sortOrder)
        {
            var model = new FeedIndexModel();

            model.Tab = "Feed";

            model.Users = DataHelper.GetUserList();
            model.UserId = userId ?? 0;
            model.UserName = DataHelper.ToString(model.Users, model.UserId, "any user");
            model.UserDisplayName = DataHelper.Clip(model.UserName, 20);

            model.Date = date ?? string.Empty;

            model.SortBy = sortBy ?? "CreatedDate";
            model.SortOrder = sortOrder ?? "DESC";
            model.SortableColumns.Add("CreatedDate", "Date");
            model.SortableColumns.Add("Type", "Type");
            model.SortableColumns.Add("UserName", "User");

            var criteria = new FeedCriteria()
            {
                CreatedBy = userId,
                CreatedDate = new DateRangeCriteria(model.Date)
            };

            var feeds = FeedService.FeedFetchInfoList(criteria)
                .AsQueryable();

            feeds = feeds.OrderBy(string.Format("{0} {1}", model.SortBy, model.SortOrder));

            model.Feeds = feeds;

            return this.View(model);
        }
    }
}
