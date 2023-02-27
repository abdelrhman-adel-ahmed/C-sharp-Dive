using Containers.Yeild;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Containers
{
    class Program
    {
        static async Task Main(string[] args)
        {

            //Console.WriteLine("---------------arrays-------------------");
            //
            //arrays.run();
            //
            // Console.WriteLine("---------------IEnumeratorr-------------------");
            // IEnumeratorr.run();
            // 
            //Console.WriteLine("---------------IEnumerable_vs_IEnumerator-------------------");
            //IEnumerable_vs_IEnumerator.run();
            //
            //Console.WriteLine("---------------IEnumerable_vs_IEnumerator2-------------------");
            //IEnumerable_vs_IEnumerator2.run();

            Console.WriteLine("Yield implemenation");
            MainClass.Run();
        }
    }
}
