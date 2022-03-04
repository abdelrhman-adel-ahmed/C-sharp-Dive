using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace benchMark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Bench>();
            Console.ReadKey();
        }
    }
}
