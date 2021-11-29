using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiffrentHttpLibInCsharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        //static HttpClient httpclient = new HttpClient();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<String> Get(string CityName)
        {
            string ApiKey = "879f31d0e4294ab7bb6181804212911";
            var url = new Uri($"http://api.weatherapi.com/v1/current.json?key={ApiKey}&q={CityName}");
            using (HttpClient httpclient = new HttpClient())
            { 
            var response = await httpclient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
