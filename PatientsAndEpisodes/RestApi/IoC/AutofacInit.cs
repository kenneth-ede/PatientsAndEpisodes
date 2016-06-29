using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace RestApi.IoC
{
    public class AutofacInit
    {
        public IContainer Container { get; private set; }

        public void Configure()
        {
            var builder = new ContainerBuilder();

            OnConfigure(builder);

            if (Container == null)
            {
                Container = builder.Build();
            }
            else
            {
                builder.Update(Container);
            }

            // This tells the MVC application to use container as its dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));

            // Create the depenedency resolver.
            var resolver = new AutofacWebApiDependencyResolver(Container);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        protected virtual void OnConfigure(ContainerBuilder builder)
        {
            // register controllers 
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Resolver.Resolve(builder);

            //AspBindings.Resolve(builder);

            //// helpers
            //AspBindings.RegisterHelpers(builder);

            //// register application context and services for umbraco
            //AspBindings.RegisterUmbracoTypes(builder);

            //AspBindings.RegisterSpatialTypes(builder);
            //AspBindings.RegisterModelBuilders(builder);
            //AspBindings.RegisterSearchTypes(builder);
            //AspBindings.RegisterSettingTypes(builder);
            //AspBindings.RegisterSimpleMappings(builder);
            //AspBindings.RegisterComplexSignatures(builder);
            //AspBindings.RegisterAdvancedSearch(builder);
            //AspBindings.RegisterAccountControllers(builder);
            //AspBindings.RegisterSummaryCollectionBuilders(builder);
            //AspBindings.RegisterModules(builder);
            //AspBindings.RegisterCacheProvider(builder);
            //AspBindings.RegisterRecurringEvents(builder);
        }
    }
}