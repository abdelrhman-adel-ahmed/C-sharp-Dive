using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool
{
    class Service1
    {
        public void print()
        {
            Console.WriteLine("Service1");
        }
    }

    class ServiceConsumer
    {
        Service1 s1;
        public ServiceConsumer(Service1 s)
        {
            s1 = s;
        }

        public void print()
        {
            s1.print();
        }
    }
}
