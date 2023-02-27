using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace concurrency_and_parallelism.Threading
{
    class Basic_Thread_Synchronization
    {

        static int count = 0;
        static object zrbo = new object();

        public static void run()
        {
            Thread t1 = new Thread(calc);
            Thread t2 = new Thread(calc2);
            t1.Start();
            t2.Start();
        }

        private static void calc()
        {
            for (int i = 0; i < 500000; i++)
            {
                count += i;
                Console.WriteLine($"thread id= {Thread.CurrentThread.ManagedThreadId} count= {count}");
                //Thread.Sleep(1000);
            }
        }
        private static void calc2()
        {
            for (int i = 500000; i < 1000000; i++)
            {
                count += i;
                Console.WriteLine($"thread id= {Thread.CurrentThread.ManagedThreadId} count= {count}");
                //Thread.Sleep(1000);
            }
        }
    }
}
