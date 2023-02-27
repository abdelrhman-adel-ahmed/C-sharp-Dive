using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace concurrency_and_parallelism.Threading
{
    class Hello_World_Thread
    {

        public static void run()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t1 = new Thread(pp);
                t1.Start(i);
            }

            Console.WriteLine("main thread, thread id= " + Thread.CurrentThread.ManagedThreadId);

        }

        static void pp(object threadNUM)
        {
            Console.WriteLine($"thread num = {threadNUM} thread id= {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
