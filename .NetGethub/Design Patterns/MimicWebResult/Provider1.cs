using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    class Provider1 : Iprovider
    {
        public void addParameters()
        {
            Console.WriteLine("Adding Parameters");
        }
    }
}
