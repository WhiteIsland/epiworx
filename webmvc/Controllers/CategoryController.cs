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
    public class CategoryController : BaseController
    {
        [Authorize]
        public ActionResult Create()
        {
            var model = new CategoryFormModel();

            try
            {
                var category = CategoryService.CategoryNew();

                this.Map(category, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(CategoryFormModel model)
        {
            var category = CategoryService.CategoryNew();

            Csla.Data.DataMapper.Map(model, category, true);

            category = CategoryService.CategorySave(category);

            if (category.IsValid)
            {
                return new JsonResult { Data = this.Url.Action("Edit", new { id = category.CategoryId }) };
            }

            this.Map(category, model, false);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = new CategoryFormModel();

            try
            {
                var category = CategoryService.CategoryFetch(id);

                this.Map(category, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, CategoryFormModel model)
        {
            var category = CategoryService.CategoryFetch(id);

            Csla.Data.DataMapper.Map(model, category, true);

            category = CategoryService.CategorySave(category);

            this.Map(category, model, true);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            CategoryService.CategoryDelete(id);

            return this.RedirectToAction("Settings", "Home", null);
        }

        public CategoryFormModel Map(Category category, CategoryFormModel model, bool ignoreBrokenRules)
        {
            Csla.Data.DataMapper.Map(category, model, true);

            model.Tab = "Home";
            model.IsNew = category.IsNew;
            model.IsValid = category.IsValid;

            if (!ignoreBrokenRules)
            {
                foreach (var brokenRule in category.BrokenRulesCollection)
                {
                    this.ModelState.AddModelError(string.Empty, brokenRule.Description);
                }
            }

            return model;
        }
    }
}
