using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Exceptions;
using Unity.Lifetime;
using WebAppEmpty.Infrastructure.MessageHandlers;
using WebAppEmpty.Models;
using WebAppEmpty.Services;

namespace WebAppEmpty
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var container = new UnityContainer();
            container.RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>();
            config.DependencyResolver = new UnityResolver(container);
            //config.MessageHandlers.Add(new CustomDelegateHandler());
           
        }
    }

    public class UnityResolver : IDependencyResolver
    {
        private IUnityContainer unityContainer;
        public UnityResolver(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }
        public IDependencyScope BeginScope()
        {
            var child = unityContainer.CreateChildContainer();
            return new UnityResolver(child);
        }
        public void Dispose()
        {
            unityContainer.Dispose();
        }
        public object GetService(Type serviceType)
        {
            try
            {
                return unityContainer.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return unityContainer.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }
    }
}
