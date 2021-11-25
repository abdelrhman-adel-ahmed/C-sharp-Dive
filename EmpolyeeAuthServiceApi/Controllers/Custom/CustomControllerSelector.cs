using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace EmpolyeeAuthServiceApi.Controllers.Custom
{
    public class CustomControllerSelector:DefaultHttpControllerSelector
    {
        HttpConfiguration _configuration;
        public CustomControllerSelector(HttpConfiguration configuration) :base(configuration)
        {
            _configuration = configuration;
        }
    }
}