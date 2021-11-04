using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool_with_lifetime
{
    class Service2
    {
        private static readonly Random random = new Random();
        int _rand;
        public Service2()
        {
            _rand = random.Next();
        }
        public string message()
        {
     
            return "service2 " + _rand;
        }
    }
}
