using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Epiworx.Security;

namespace Epiworx.WebMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "About", // Route name
                "About", // URL with parameters
                new { controller = "Home", action = "About" } // Parameter defaults
            );

            routes.MapRoute(
                "Settings", // Route name
                "Settings", // URL with parameters
                new { controller = "Home", action = "Settings" } // Parameter defaults
            );

            routes.MapRoute(
                "DefaultWithExtension",
                "{controller}/{action}.{format}/{id}",
                new { controller = "Home", action = "Index", id = "" }
            );

            routes.MapRoute(
                "DefaultWithTitle", // Route name
                "{controller}/{action}/{id}/{title}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional, title = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            MvcApplication.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current.Handler is IRequiresSessionState)
            {
                if (Csla.ApplicationContext.AuthenticationType == "Windows")
                {
                    return;
                }

                IPrincipal principal = null;

                try
                {
                    principal = (IPrincipal)HttpContext.Current.Session["EPIWORXUSER"];
                }
                catch
                {
                    principal = null;
                }

                if (principal == null)
                {
                    if (this.User.Identity.IsAuthenticated
                        && this.User.Identity is FormsIdentity)
                    {
                        BusinessPrincipal.LoadPrincipal(this.User.Identity.Name);

                        HttpContext.Current.Session["EPIWORXUSER"] = Csla.ApplicationContext.User;

                        this.Response.Redirect(this.Request.Url.PathAndQuery);
                    }

                    BusinessPrincipal.Logout();
                }
                else
                {
                    Csla.ApplicationContext.User = principal;
                }
            }
        }
    }
}