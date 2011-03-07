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
    public class LabelController : BaseController
    {
        [HttpPost]
        [Authorize]
        public ActionResult Add(int sourceType, int sourceId, LabelFormModel model)
        {
            var label = LabelService.LabelAdd((SourceType)sourceType, sourceId, model.Name);

            if (label.IsValid)
            {
                model.IsNew = true;
            }

            this.Map(label, model, false);

            return PartialView("LabelUserControl", model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int sourceType, int sourceId, string name)
        {
            LabelService.LabelDelete((SourceType)sourceType, sourceId, name);

            return new JsonResult();
        }

        public LabelFormModel Map(Label label, LabelFormModel model, bool ignoreBrokenRules)
        {
            Csla.Data.DataMapper.Map(label, model, true);

            model.Tab = "Task";
            model.IsNew = label.IsNew;
            model.IsValid = label.IsValid;

            if (!ignoreBrokenRules)
            {
                foreach (var brokenRule in label.BrokenRulesCollection)
                {
                    this.ModelState.AddModelError(string.Empty, brokenRule.Description);
                }
            }

            return model;
        }
    }
}
