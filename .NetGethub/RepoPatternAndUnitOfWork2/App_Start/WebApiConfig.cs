using RepoPatternAndUnitOfWork2.Contracts.UnitOfWork;
using RepoPatternAndUnitOfWork2.Core;
using RepoPatternAndUnitOfWork2.Data;
using System.Configuration;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;

namespace RepoPatternAndUnitOfWork2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString();
            var container = new UnityContainer();
            container.RegisterFactory(typeof(UserAccountsDbContext), (c) => new UserAccountsDbContext(connectionString));
            container.RegisterType<IUserAccountsUnitOfWork, UsersUnitOfWork>();
            config.DependencyResolver = new UnityDependencyResolver(container);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
