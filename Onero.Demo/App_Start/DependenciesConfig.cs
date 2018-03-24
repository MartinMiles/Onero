using System.Reflection;
using System.Web.Mvc;
using Onero.Demo.Collections;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Container = SimpleInjector.Container;

namespace Onero.Demo
{
    public static class DependenciesConfig
    {
        private static Container Container;

        public static void RegisterDependencies()
        {
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // register types as normal
            //Container.Register<IRegexExtractor, RegexExtractor>();

            Container.RegisterSingleton<Collections.Inerfaces.ICollection>(Collections.Collection.GetInstance(new CollectionRepository(new Configuration())));

            Container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            Container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(Container));
        }
    }
}