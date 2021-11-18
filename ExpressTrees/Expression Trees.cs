using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressTrees
{
    class Expression_Trees
    {
        public static void run()
        {
            Func<int, bool> test = i => i > 5;
            Console.WriteLine(test(4));
            Console.WriteLine(test(6));
        }
    }
}
