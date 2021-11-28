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
            Thread t2 = new Thread(calc);
            t1.Start();
            t2.Start();
        }

        private static void calc()
        {
            while(true)
            {
                lock(zrbo)
                {
                    int temp = count;
                    count = temp + 1;
                    Console.WriteLine($"thread id= {Thread.CurrentThread.ManagedThreadId} count= {count}");
                }
                
                Thread.Sleep(1000);
            }
        }
    }
}
