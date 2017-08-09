using FluentValidation.Mvc;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebClient.App_Start;
using WebClient.Infrastructure;

namespace WebClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FluentValidationModelValidatorProvider.Configure();
            log4net.Config.XmlConfigurator.Configure();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(Bootstrapper.Container));
            Bootstrapper.Logger.Info("Session started");

        }
        protected void Application_Error()
        {
            var e = Server.GetLastError();
            Server.ClearError();
            Bootstrapper.Logger.Fatal("Unexpected error occured", e);
            
            Response.Redirect("/Error/FatalError");
        }

        protected void Application_End()
        {
            if(Bootstrapper.Container != null)
            {
                Bootstrapper.Logger.Info("Session ended");
                Bootstrapper.Container.Dispose();
            }
        }
    }
}
