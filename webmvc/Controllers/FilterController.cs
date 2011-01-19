using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.Service;
using Epiworx.WebMvc.Helpers;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    public class FilterController : Controller
    {
        [Authorize]
        public ActionResult Create(string target, string query)
        {
            var model = new FilterFormModel();

            try
            {
                var filter = FilterService.FilterNew();

                filter.Target = target;
                filter.Query = query;

                this.Map(filter, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(FilterFormModel model)
        {
            var filter = FilterService.FilterNew();

            Csla.Data.DataMapper.Map(model, filter, true);

            filter = FilterService.FilterSave(filter);

            if (filter.IsValid)
            {
                return new JsonResult { Data = this.Url.Action("Edit", new { id = filter.FilterId }) };
            }

            this.Map(filter, model, false);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = new FilterFormModel();

            try
            {
                var filter = FilterService.FilterFetch(id);

                this.Map(filter, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, FilterFormModel model)
        {
            var filter = FilterService.FilterFetch(id);

            Csla.Data.DataMapper.Map(model, filter, true);

            filter = FilterService.FilterSave(filter);

            this.Map(filter, model, true);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var filter = FilterService.FilterFetch(id);

            FilterService.FilterDelete(id);

            return this.RedirectToAction("Index", filter.Target, null);
        }

        public FilterFormModel Map(Filter filter, FilterFormModel model, bool ignoreBrokenRules)
        {
            Csla.Data.DataMapper.Map(filter, model, true);

            model.Tab = filter.Target;
            model.IsNew = filter.IsNew;
            model.IsValid = filter.IsValid;

            if (!ignoreBrokenRules)
            {
                foreach (var brokenRule in filter.BrokenRulesCollection)
                {
                    this.ModelState.AddModelError(string.Empty, brokenRule.Description);
                }
            }

            return model;
        }
    }
}
