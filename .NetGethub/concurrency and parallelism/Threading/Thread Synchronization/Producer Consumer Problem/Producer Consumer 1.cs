using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace concurrency_and_parallelism.Threading
{
    class Producer_Consumer_1
    {
        static Queue<int> queue = new Queue<int>();

        public static void run()
        {
            Thread t1 = new Thread(Producer);
            Thread t2 = new Thread(Consumer);
            t1.Start();
            t2.Start();
        }

        public static void Producer()
        {
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
                Thread.Sleep(1000);
            }
        }
        public static void Consumer()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
