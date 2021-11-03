using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool
{
    class Service1
    {
        public Service1(Service2 service2)
        {

        }
        public void print()
        {
            Console.WriteLine("Service1");
        }
    }

    
}
