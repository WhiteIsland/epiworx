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
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            var model = new UserIndexModel();

            model.Tab = "User";
            model.Users = DataHelper.GetUserList();

            return this.View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new UserFormModel();

            try
            {
                var user = UserService.UserNew();

                this.Map(user, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(UserFormModel model)
        {
            var user = UserService.UserNew();

            Csla.Data.DataMapper.Map(model, user, true);

            user.SetPassword(model.Password);

            try
            {
                user = UserService.UserSave(user);

                if (user.IsValid)
                {
                    return new JsonResult { Data = this.Url.Action("Edit", new { id = user.UserId }) };
                }
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("", ex.Message);
            }

            this.Map(user, model, false);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = new UserFormModel();

            try
            {
                var user = UserService.UserFetch(id);

                this.Map(user, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, UserFormModel model)
        {
            var user = UserService.UserFetch(id);

            Csla.Data.DataMapper.Map(model, user, true);

            if (!string.IsNullOrEmpty(model.Password))
            {
                user.SetPassword(model.Password);
            }

            user = UserService.UserSave(user);

            this.Map(user, model, true);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            UserService.UserDelete(id);

            return this.RedirectToAction("Index", "User");
        }

        public UserFormModel Map(User user, UserFormModel model, bool ignoreBrokenRules)
        {
            Csla.Data.DataMapper.Map(user, model, true);

            model.Tab = "User";
            model.Roles = DataHelper.GetRoleList();
            model.IsNew = user.IsNew;
            model.IsValid = user.IsValid;

            if (!ignoreBrokenRules)
            {
                foreach (var brokenRule in user.BrokenRulesCollection)
                {
                    this.ModelState.AddModelError(string.Empty, brokenRule.Description);
                }
            }

            if (!ignoreBrokenRules
                && !string.IsNullOrWhiteSpace(model.Password)
                && (model.Password != model.PasswordConfirmation))
            {
                this.ModelState.AddModelError("Password", "Passwords must match.");
                this.ModelState.AddModelError("PasswordConfirmation", "Passwords must match.");
                this.ModelState.AddModelError(string.Empty, "Passwords must match.");
            }

            return model;
        }
    }
}
