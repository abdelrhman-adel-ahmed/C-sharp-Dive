using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool
{
    class Service1: IService1
    {
        Service2 _service2;
        public Service1(Service2 service2)
        {
            _service2 = service2;
        }
        public void print()
        {
            Console.WriteLine("Service1 " + _service2.message());
        }
    }

    
}
