using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool
{
    class ServiceConsumer
    {
        Service1 _service;
        public ServiceConsumer(Service1 service)
        {
            _service = service;
        }

        public void print()
        {
            _service.print();
        }
    }
}
