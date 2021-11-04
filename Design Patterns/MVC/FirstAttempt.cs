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
            var ControllerType = typeof(Controller);
            ControllerType.Assembly.GetTypes().Where(type => !type.IsAbstract && ControllerType.IsAssignableFrom(type)).ToList()
                .ForEach(type => Console.WriteLine(type));
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
