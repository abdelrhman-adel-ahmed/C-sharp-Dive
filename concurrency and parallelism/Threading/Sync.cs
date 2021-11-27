using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace concurrency_and_parallelism.Threading
{
    class Sync
    {
        static int sum = 0;
  
        public static void run()
        {
            Thread t1 = new Thread(calc);
            Thread t2 = new Thread(calc);
            t1.Start();
            t2.Start();
            t1.Join();
            Console.WriteLine(sum);
        }

        static void calc()
        {
            for (int i = 0; i < 500000; i++)
            {
                 sum += 1;
            }
        }

    }
}
