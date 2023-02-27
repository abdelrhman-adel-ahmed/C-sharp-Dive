using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("------------------many_to_many------------------------");
            many_to_many.run();
            Console.WriteLine("finish");
            Console.ReadLine();
        }
    }
}
