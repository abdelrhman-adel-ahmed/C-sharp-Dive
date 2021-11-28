using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace concurrency_and_parallelism.Threading
{
    class Divide_and_Conquer__1
    {
        static List<long> ll = new List<long>();
        public static void run()
        {
            generateRand();
            long total = 0;
            Console.WriteLine("summing");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 500000000; i++)
            {
                total += ll[i];
            }
            watch.Stop();
            Console.WriteLine(total);
            Console.WriteLine("time taken to sum "+ watch.Elapsed);
        }
        static void generateRand()
        {
            Random rand = new Random();
            for (long i = 0; i < 500000000; i++)
            {
                ll.Add(i);
            }
        }
    }
}
