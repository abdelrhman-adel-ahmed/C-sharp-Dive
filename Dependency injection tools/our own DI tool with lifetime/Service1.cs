using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool_with_lifetime
{
    class Service1
    {
        static int x;
        Service2 _service2;
        public Service1(Service2 service2)
        {
             x++;
            _service2 = service2;
        }
        public void print()
        {
            Console.WriteLine($"Service1 {x} " + _service2.message());
        }
    }

    
}
