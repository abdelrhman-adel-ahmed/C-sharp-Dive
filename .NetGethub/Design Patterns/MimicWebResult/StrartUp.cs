using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    class StartUp
    {
        public static void run()
        {
            Func<Iprovider, int> x = (Iprovider provider) =>
            {
                return 1;
            };

            int yy = x(new Provider1());
            Console.WriteLine(yy);
        }

    }
}
