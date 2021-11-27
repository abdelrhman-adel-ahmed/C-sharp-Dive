using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace concurrency_and_parallelism.Threading
{
    class ThreadOverHead
    {
        public static void xx(object obj) { }
        
        public static void ThreadoverHead()
        {
            const int OneMB = 1024 * 1024;
            using (ManualResetEvent wakeThread = new ManualResetEvent(false))
            {
                int ThreadNum = 0;
                try
                {
                    while(true)
                    {
                        Thread t = new Thread(xx);
                        t.Start(wakeThread);
                        Console.WriteLine($"{++ThreadNum} {Process.GetCurrentProcess().VirtualMemorySize64/OneMB}MB");
                    }
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine($"out of memory after creating {ThreadNum}");
                    Debugger.Break();
                    wakeThread.Reset();
                }
            }
        }

    
    }
}
