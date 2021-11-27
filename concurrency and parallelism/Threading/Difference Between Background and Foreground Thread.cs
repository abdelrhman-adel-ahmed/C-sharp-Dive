using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace concurrency_and_parallelism.Threading
{
    class Difference_Between_Background_and_Foreground_Thread
    {

        public static void run()
        {
            int numOfProcessors = Environment.ProcessorCount;
            Console.WriteLine("num of processors in the machine = "+ numOfProcessors);
            for (int i = 0; i < numOfProcessors; i++)
            {
                Thread t1 = new Thread(pp);
                //meaning once the thread that create t1 thread finishs t1 will terminate.
                //you will see some output even after the main thread printed and finsihed ,i think that because
                //the threads already queued out that they want to print somthing out in the conosle before the main
                //thread finish so the console print those queued tasks
                t1.IsBackground = true;
                t1.Start(i);
            }

            Console.WriteLine("main thread, thread id= " + Thread.CurrentThread.ManagedThreadId);

        }

        static void pp(object threadNUM)
        {
            while(true)
                Console.WriteLine($"thread num = {threadNUM} thread id= {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
