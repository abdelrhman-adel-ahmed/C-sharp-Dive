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
            var uri = new Uri("http://localhost/test/print?name=ahmed");
            var container = new MVCContainer();
            var result = container.Resolve(uri);
            Console.WriteLine(result); 

        }
    }
    abstract class Controller { }
    class HomeController : Controller
    {
        public string Index()
        {
            return "HomeController say hi";
        }

        public int GetId()
        {
            return 1;
        }
    }

    class TestController : Controller
    {
        public string Index()
        {
            return "TestController say hi";
        }

        public string print()
        {
            return "TestController print action";
        }
    }
}
