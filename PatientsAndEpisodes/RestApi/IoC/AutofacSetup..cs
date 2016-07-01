using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using RestApi.Models;
using RestApi.Repository;

namespace RestApi.IoC
{
    public class AutofacSetup
    {
        public IContainer Init(bool useInMemoryRepository = false)
        {
            var builder = new ContainerBuilder();

            // Get HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // register types
            builder.RegisterType<PatientContext>().AsImplementedInterfaces();

            if (useInMemoryRepository)
            {
                builder.RegisterType<InMemoryRepository>().AsImplementedInterfaces();
            }
            else
            {
                builder.RegisterType<PatientRepository>().AsImplementedInterfaces();
            }

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }
    }
}