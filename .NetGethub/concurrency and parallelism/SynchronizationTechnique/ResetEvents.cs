using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace concurrency_and_parallelism.SynchronizationTechnique
{
    public class ResetEvents
    {
        static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        public static void Run()
        {
            Thread t1 = new Thread(run1);
            t1.Start();
            Console.ReadLine();
            manualResetEvent.Set();
        }

        public static void run1()
        {
            Console.WriteLine("run1 Starting");
            manualResetEvent.WaitOne();
            Console.WriteLine("run1 finish");
            manualResetEvent.WaitOne();
            Console.WriteLine("run1 finally finish");

        }
    }
}
