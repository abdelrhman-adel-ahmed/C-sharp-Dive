using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Patterns.MVC;

namespace Design_Patterns
{

    class test
    {
        int i = 1;
        public static void Func(test t)
        {
            t.i = 2;
            Console.WriteLine(t.i);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            test.Func(new test());
            //EntryPoint.Start();

            //Console.ReadLine();
            //Entrypoint1.run();
            double x = 1.00;
            Console.ReadLine();
        }
    }
}
