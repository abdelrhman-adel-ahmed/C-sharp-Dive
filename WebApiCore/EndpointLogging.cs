using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace WebApiCore
{
    public class EndpointLogging
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<EndpointLogging> _logger;

        public EndpointLogging(RequestDelegate next, ILogger<EndpointLogging> logger)
        {
            _next = next;
            _logger = logger;
        }
        public Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            switch(endpoint)
            {
                case RouteEndpoint routeEndPoint:
                    _logger.LogInformation($"End point Name {routeEndPoint.DisplayName}");
                    _logger.LogInformation($"Route pattern {routeEndPoint.RoutePattern}");

                    foreach (var type in routeEndPoint.Metadata.Select(md => md.GetType()))
                    {
                        _logger.LogInformation($"{type}");
                    }
                    break;

                case null:
                    _logger.LogInformation("end point is null");
                    break;
            }
            return _next(context);
        }


    }
}
