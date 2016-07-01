using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using RestApi.IoC;

namespace RestApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : HttpApplication
    {
        private static IContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            var ioc = new AutofacSetup();
            _container = ioc.Init();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}