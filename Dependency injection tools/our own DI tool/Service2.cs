using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool
{
    class Service2
    {
        int _rand;
        public Service2()
        {
            _rand = new Random().Next();  
        }
        public string message()
        {
            return "service2 " + _rand;
        }
    }
}
