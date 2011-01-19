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

namespace Epiworx.WebMvc.Controllers
{
    public class HourController : Controller
    {
        [Authorize]
        public ActionResult Index(int[] projectId, int[] userId, string date, int? isArchived, string sortBy, string sortOrder)
        {
            var model = new HourIndexModel();

            model.Tab = "Hour";

            model.Projects = DataHelper.GetProjectList();
            model.ProjectId = projectId ?? new int[0];
            model.ProjectName = DataHelper.ToString(model.Projects, model.ProjectId, "any project");
            model.ProjectDisplayName = DataHelper.Clip(model.ProjectName, 40);

            model.Users = DataHelper.GetUserList();
            model.UserId = userId ?? new int[0];
            model.UserName = DataHelper.ToString(model.Users, model.UserId, "any user");
            model.UserDisplayName = DataHelper.Clip(model.UserName, 20);

            model.Date = date ?? string.Empty;
            model.IsArchived = isArchived ?? 1;

            model.Filters = MyService.FilterFetchInfoList("Hour");

            model.SortBy = sortBy ?? "Date";
            model.SortOrder = sortOrder ?? "DESC";
            model.SortableColumns.Add("Date", "Date");
            model.SortableColumns.Add("ProjectName", "Project");
            model.SortableColumns.Add("UserName", "User");

            var criteria = new HourCriteria()
            {
                ProjectId = projectId,
                UserId = userId,
                Date = new DateRangeCriteria(model.Date),
                IsArchived = DataHelper.ToBoolean(isArchived)
            };

            var hours = HourService.HourFetchInfoList(criteria)
                .AsQueryable();

            hours = hours.OrderBy(string.Format("{0} {1}", model.SortBy, model.SortOrder));

            model.Hours = hours;

            return this.View(model);
        }

        [Authorize]
        public ActionResult Create(int? projectId, int? taskId)
        {
            var model = new HourFormModel();

            try
            {
                var hour = HourService.HourNew();

                if (projectId.HasValue
                    && projectId.Value != 0)
                {
                    hour.ProjectId = projectId.Value;
                }

                if (taskId.HasValue
                    && taskId.Value != 0)
                {
                    hour.TaskId = taskId.Value;
                }

                this.Map(hour, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(int? projectId, int? taskId, HourFormModel model)
        {
            var hour = HourService.HourNew();

            Csla.Data.DataMapper.Map(model, hour, true);

            hour = HourService.HourSave(hour);

            if (hour.IsValid)
            {
                return new JsonResult { Data = this.Url.Action("Edit", new { id = hour.HourId }) };
            }

            this.Map(hour, model, false);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = new HourFormModel();

            try
            {
                var hour = HourService.HourFetch(id);

                this.Map(hour, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, HourFormModel model)
        {
            var hour = HourService.HourFetch(id);

            Csla.Data.DataMapper.Map(model, hour, true);

            hour = HourService.HourSave(hour);

            this.Map(hour, model, true);

            return this.PartialView("HourForm", model);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var model = new HourFormModel();

            try
            {
                var hour = HourService.HourFetch(id);

                this.Map(hour, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id, HourFormModel model)
        {
            try
            {
                var hour = HourService.HourFetch(id);

                this.Map(hour, model, true);

                HourService.HourDelete(id);

                return this.View("DeleteSuccess", model);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        public HourFormModel Map(Hour hour, HourFormModel model, bool ignoreBrokenRules)
        {
            Csla.Data.DataMapper.Map(hour, model, true);

            model.Tab = "Hour";
            model.Users = DataHelper.GetUserList();
            model.Projects = DataHelper.GetProjectList();
            model.IsNew = hour.IsNew;
            model.IsValid = hour.IsValid;

            if (!ignoreBrokenRules)
            {
                foreach (var brokenRule in hour.BrokenRulesCollection)
                {
                    this.ModelState.AddModelError(string.Empty, brokenRule.Description);
                }
            }

            return model;
        }
    }
}
