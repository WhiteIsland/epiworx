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
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var model = new HomeIndexModel();

            model.Tab = "Home";

            model.Tasks = MyService.TaskFetchInfoList();
            model.Hours = MyService.HourFetchInfoList(DateTime.Today.ToStartOfWeek(), DateTime.Today.ToEndOfWeek());

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
