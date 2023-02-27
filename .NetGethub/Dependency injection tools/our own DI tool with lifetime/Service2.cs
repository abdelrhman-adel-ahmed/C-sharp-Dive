using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool_with_lifetime
{
    class Service2
    {
        int _rand;
        static int count=0;
        public Service2()
        {
            count++;
        }
        public string message()
        {
     
            return "service2 " + count;
        }
    }
}
