using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using EmpolyeeAuthServiceApi.Controllers.Custom;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace EmpolyeeAuthServiceApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes ,make the attribute routing work
            config.MapHttpAttributeRoutes();

            //overwrite the httpcontroller selector to implement our own selector 
            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector(config));

            //or we can use the route attribute
           // config.Routes.MapHttpRoute(
           //    name: "Version1",
           //    routeTemplate: "api/v1/student/{id}",
           //    defaults: new { id = RouteParameter.Optional ,controller="StudentV1"}
           //);
           // config.Routes.MapHttpRoute(
           //   name: "Version2",
           //   routeTemplate: "api/v2/student/{id}",
           //   defaults: new { id = RouteParameter.Optional, controller = "StudentV2" }
           //          );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
