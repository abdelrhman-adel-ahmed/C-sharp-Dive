using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using ExecelTest;
using Fingers10.ExcelExport.ActionResults;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.ExtendedProperties;

namespace test01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            WindowsIdentity x = WindowsIdentity.GetCurrent();
            var userIdentity = HttpContext.User.Identity;
            var windowsUserIdentity = (WindowsIdentity)userIdentity;
            string result = $"application code execting using : {x.Name} {Environment.NewLine}";
            result += $"user name that authenticated : {User.Identity.Name} {Environment.NewLine}";
            var pro = x.GetType().GetProperties().ToList();
            foreach (var item in pro)
            {
                var tt = item.GetValue(x);
            }
            x.GetType().GetProperties().ToList().ForEach(t => result += $"{t.Name} : {t?.GetValue(x)} {Environment.NewLine}");
            return result;
        }

        [HttpGet]
        [Route("Excel")]
        public async Task Excel()
        {
            string filename = "test.xlsx";
            string path = @"C:\Users\Abdelrahman.Adel\OneDrive - Link Development\PersonaProjects\.NetGethub\ExecelTest\bin\Debug\test.xlsx";

            // HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            byte[] byteArray = System.IO.File.ReadAllBytes(path);

            // response.Content = new StreamContent(stream);
            // response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = filename };
            // response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            // //response.Content.Headers.ContentDisposition.FileName = filename;
            // //return response;
            // return response;
            HttpContext.Response.Headers["content-disposition"] = $"attachment; filename={filename}";
            await HttpContext.Response.Body.WriteAsync(byteArray, 0, byteArray.Length);
        }
        [HttpGet("DownloadExecl")]
        public IActionResult ExcelDownload()
        {
            Data data = new Data { LowNum = "1", LowTitle = "الماده رقم 1", Decision = "موافق", LowComment = "موافق", Notes = "لا يوجد ملاحظات" };
            Data data2 = new Data { LowNum = "2", LowTitle = "الماده رقم 2", Decision = "مش موافق", LowComment = "بس يابابا", Notes = "لا يوجد ملاحظات" };
            List<Data> dataList = new List<Data> { data, data2 };
            return new ExcelResult<Data>(dataList,"sheet1","test");
        }
    }
}

