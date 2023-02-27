using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace EmpolyeeAuthServiceApi.Controllers.Custom
{
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        HttpConfiguration _configuration;
        public CustomControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            //get all the controllers that inherete from apicontroller
            var controllers = GetControllerMapping();
            //gets the request route data the route data 
            var routedata = request.GetRouteData();
            //the route data value is a dict that have name that we use in the url api/student -->have the student
            string controllerName = routedata.Values["Controller"].ToString();
            string versionNumber = "1";
            //dict of key value pairs of the query string .
            var versionQueryString = request.GetQueryNameValuePairs();
            var versionQueryString1 = HttpUtility.ParseQueryString(request.RequestUri.Query);
            if (versionQueryString1["v"] != null)
            {
                versionNumber = versionQueryString1["v"];
            }

            if (versionNumber == "1")
            {
                //we have the controller name that we put in the url api/student --> we have student ,
                //but the actual controller named studentv1 so we append v1 or v2 depend on what we specife in the 
                //query string
                controllerName += "v1";
            }
            else if (versionNumber == "2")
            {
                controllerName += "v2";
            }

            //we can either use TryGetValue to get the contrller descirptor obj or we can do it out self by 
            //accesing the controllers list and get the controller name and the value of contrllers dict is
            //the contrllerdesciptor it self
            var controllertype = controllers[controllerName];
            HttpControllerDescriptor controllerDesc;
            //it get the specifide controller using the controller name
            controllers.TryGetValue(controllerName, out controllerDesc);
            return controllertype;
        }
    }
}