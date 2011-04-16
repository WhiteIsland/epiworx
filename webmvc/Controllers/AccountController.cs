using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Epiworx.Business;
using Epiworx.Core.Helpers;
using Epiworx.Core.Messenger;
using Epiworx.Security;
using Epiworx.Service;
using Epiworx.WebMvc.Helpers;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    [HandleError]
    public class AccountController : BaseController
    {
        public IFormsAuthenticationService FormsService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (this.FormsService == null)
            {
                this.FormsService = new FormsAuthenticationService();
            }

            base.Initialize(requestContext);
        }

        public ActionResult LogOn()
        {
            var model = new LogOnModel();

            return this.View(model);
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                if (this.ValidateUser(model.UserName, model.Password))
                {
                    this.FormsService.SignIn(model.UserName, model.RememberMe);

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return this.Redirect(returnUrl);
                    }

                    return this.RedirectToAction("Index", "Home");
                }

                this.ModelState.AddModelError(string.Empty, "The user name or password provided is incorrect.");
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            this.FormsService.SignOut();

            BusinessPrincipal.Logout();

            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (this.ModelState.IsValid)
            {
                BusinessPrincipal.Login();

                var user = UserService.UserNew();

                user.Name = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.Role = Role.Review;

                user.SetPassword(model.Password);

                user = UserService.UserSave(user);

                if (user.IsValid)
                {
                    BusinessPrincipal.Logout();

                    BusinessPrincipal.LoadPrincipal(model.UserName);

                    this.FormsService.SignIn(model.UserName, false);

                    this.Session["EPIWORXUSER"] = Csla.ApplicationContext.User;

                    return this.RedirectToAction("Index", "Home");
                }

                this.ModelState.AddModelError(string.Empty, user.BrokenRulesCollection.ToString(","));
            }

            return this.View(model);
        }

        public ActionResult ForgotPassword()
        {
            var model = new ForgotPasswordModel();

            return this.View(model);
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (this.ModelState.IsValid)
            {
                UserPasswordService.UserPasswordReset(model.Name);

                return this.RedirectToAction("LogOff");
            }

            return this.View(model);
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            var model = new ChangePasswordModel();

            model.Tab = "Home";

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (this.ModelState.IsValid)
            {
                UserPasswordService.UserPasswordChange(model.NewPassword, model.ConfirmPassword);

                return this.RedirectToAction("LogOff");
            }

            model.Tab = "Home";

            return this.View(model);
        }

        public ActionResult ChangePasswordSuccess()
        {
            return this.View();
        }

        public bool ValidateUser(string userName, string password)
        {
            try
            {
                var result = BusinessPrincipal.Login(userName, password);

                this.Session["EPIWORXUSER"] = Csla.ApplicationContext.User;

                return result;
            }
            catch
            {
                return false;
            }
        }
    }
}
