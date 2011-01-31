using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.Core;
using Epiworx.Service;
using Epiworx.WebMvc.Helpers;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            var model = new HomeIndexModel();

            model.Tab = "Home";

            model.StartDate = DateTime.Today.ToStartOfWeek();
            model.EndDate = DateTime.Today.ToEndOfWeek();
            model.Tasks = MyService.TaskFetchInfoList();
            model.Hours = MyService.HourFetchInfoList(model.StartDate, model.EndDate);
            model.Feeds = MyService.FeedFetchInfoList(5);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Settings()
        {
            var model = new HomeSettingsModel();

            model.Tab = "Home";
            model.Categories = DataHelper.GetCategoryList();
            model.Statuses = DataHelper.GetStatusList();

            return this.View(model);
        }
    }
}
