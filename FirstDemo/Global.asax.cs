using Castle.Windsor;
using Castle.Windsor.Installer;
using FirstDemo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FirstDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IWindsorContainer _container;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MvcApplication.BootstrapContainer();
        }
        private static void BootstrapContainer()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.Named("BLL"));
            _container.Install(FromAssembly.This());
            
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_container.Kernel));
        }
        protected void Application_End()
        {
            _container.Dispose();
        }



    }
}
