using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebApiContrib.Formatting.Jsonp;
using System.Web.Http.Cors;

namespace FirstWebApi
{
    public static class WebApiConfig
    {

        public class CustomeJsonFormatter : JsonMediaTypeFormatter
        {
            public CustomeJsonFormatter()
            {
                this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            }
            public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
            {
                base.SetDefaultContentHeaders(type, headers, mediaType);
                headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
        }
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional}
            );
            //cors can for specific sites to request from us ,second param is accpet headers , third 
            //is the http methods you will accepts get,post,...,we can enable cors on specific controllers only
            //or specific action inside the controllers by setting it like attribue in the controller
            EnableCorsAttribute cors = new EnableCorsAttribute("https://localhost:44374", "*","*");
            config.EnableCors(cors);
            
            //var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //config.Formatters.Add(jsonpFormatter);

            //foramtter custom configrations 
           // config.Formatters.Remove(config.Formatters.XmlFormatter);//will not return xml  
           // config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            // config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = 
            //     new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            // config.Formatters.JsonFormatter.SupportedMediaTypes
            //     .Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            //config.Formatters.Add(new CustomeJsonFormatter());

        }
    }
}
