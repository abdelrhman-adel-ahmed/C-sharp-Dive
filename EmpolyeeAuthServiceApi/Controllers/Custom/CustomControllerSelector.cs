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
            var controllers = GetControllerMapping();
            var routedata=request.GetRouteData();
            string controllerName=routedata.Values["Controller"].ToString();
            string versionNumber = "1";
            var versionQueryString = request.GetQueryNameValuePairs();
            var versionQueryString1 = HttpUtility.ParseQueryString(request.RequestUri.Query);
            if (versionQueryString1["v"]!=null)
            {
                versionNumber = versionQueryString1["v"];
            }

            if(versionNumber=="1")
            {
                controllerName += "v1";
            }
            else if(versionNumber == "2")
            {
                controllerName += "v2";
            }

            HttpControllerDescriptor controllerDesc ;
            controllers.TryGetValue(controllerName,out controllerDesc);
            return controllerDesc;
        }
    }
}