using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressTrees
{
    class Intro
    {
        public static void run()
        {
            //.net doesnot know any thing about this c# syntax
            Func<int, bool> test = i => i > 5;
            Console.WriteLine(test(4));
            Console.WriteLine(test(6));
          

        }
    }
}
