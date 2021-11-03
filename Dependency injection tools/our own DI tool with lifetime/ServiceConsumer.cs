using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool_with_lifetime
{
    class ServiceConsumer
    {
        Service1 _service1;
        public ServiceConsumer(Service1 service)
        {
            _service1 = service;
        }

        public void print()
        {
            _service1.print();
        }
    }
}
