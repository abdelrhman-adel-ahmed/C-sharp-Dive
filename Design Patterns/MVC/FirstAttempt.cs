using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.MVC
{
    class FirstAttempt
    {
        public static void run()
        {
            var uri = new Uri("http://localhost/home/index");
            var container = new MVCContainer();
            container.Resolve(uri);

        }
    }
    abstract class Controller { }
    class HomeController : Controller
    {
        public string Index()
        {
            return "HomeController";
        }
    }

    class TestController : Controller
    {
        public string Index()
        {
            return "TestController";
        }
    }
}
