using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace DiffrentHttpLibInCsharp.Controllers
{
    [Route("[controller]")]
    public class test : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserLogin userLogin)
        {
            return Ok(userLogin);
        }
        [HttpPost]
        [Route("TestQueryString")]
        public IActionResult TestQueryString(string q1, int q2, float q3)
        {
            return Ok(new { q1, q2, q3 });
        }
        [HttpGet]
        [ActionName("TestQueryString")]
        [Route("TestQueryString")]
        public IActionResult TestQueryStringGet(string q1, int q2, float q3)
        {
            return Ok(new { q1, q2, q3 });
        }
        [HttpGet]
        [ActionName("TestQueryString")]
        [Route("TestQueryStringWithDict")]
        [QueryStringActionFilter]
        public IActionResult TestQueryStringGetWithDic(string q1, int q2, object data)
        {
            return Ok(new { q1, q2, data });
        }
    }

    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class QueryStringActionFilter : ActionFilterAttribute
    {
        private const string _additionalParamsFieldName = "data";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var filters = new Dictionary<string, object>();
            foreach (var kvp in context.HttpContext.Request.Query)
            {
                if (kvp.Key == _additionalParamsFieldName)
                {
                    filters.Add(kvp.Key, kvp.Value);
                }
            }
            context.ActionArguments[_additionalParamsFieldName] = filters.;
            base.OnActionExecuting(context);
        }
    }
}
