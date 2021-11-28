using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace concurrency_and_parallelism.Threading
{
    class Divide_and_Conquer__2
    {
        //we will create 8 threads that each one will take portion of the array and sum it so we will divide the array
        //into 8 ,and then each thread work on one portion and then each thread will put its result in another array
        //at the index specified for that thread by the portionnumber
        static List<long> numbers = new List<long>();
        static List<long> PortionResults = new List<long>(Environment.ProcessorCount);
        static int PortionSize;
        static object zrbo = new object();
        public static void run()
        {
            generateRand();
            PortionSize = numbers.Count / Environment.ProcessorCount;

            long total = 0;
            Console.WriteLine("summing");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 500000000; i++)
            {
                total += numbers[i];
            }
            watch.Stop();
            Console.WriteLine(total);
            Console.WriteLine("time taken to sum " + watch.Elapsed);

            Console.WriteLine();

            Stopwatch watch2 = new Stopwatch();
            watch2.Start();
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads.Add(new Thread(SumYourPortion));
                threads[i].Start(i);
            }
            foreach (Thread item in threads)
            {
                item.Join();
            }
            long total2 = 0;
            foreach (long item in PortionResults)
            {
                total2 += item;
            }
            watch2.Stop();
            Console.WriteLine(total2);
            Console.WriteLine("time taken to sum 2 " + watch2.Elapsed);
        }
        static void SumYourPortion(object portionnumber)
        {
            long sum = 0;
            int Portionnumber = (int)portionnumber;
            //we start from the portion number * the size of the portion ,i.e portion 1 the size of each portion is 10
            //so we start from index 10 , tell the 1 *10 +10 = 20
            int baseIndex = Portionnumber * PortionSize;
            int BoundIndex = Portionnumber * PortionSize + PortionSize;
            for (int i = baseIndex; i < BoundIndex; i++)
            {
                sum += numbers[i];
            }
            PortionResults.Add(sum);
        }
        static void generateRand()
        {
            // Random rand = new Random();
            for (long i = 0; i < 500000000; i++)
            {
                lock (zrbo)
                {
                    numbers.Add(i);
                }

            }
        }
    }
}
