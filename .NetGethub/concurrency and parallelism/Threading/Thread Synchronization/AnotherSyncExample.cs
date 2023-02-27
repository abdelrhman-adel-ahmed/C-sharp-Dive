using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace concurrency_and_parallelism.Threading
{
    class AnotherSyncExample
    {
        static object zrbo = new object();
        static Random rand = new Random();

        public static void run()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(UseBathRoomStall).Start();
            }

        }

        static void UseBathRoomStall()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " trying to obtain bathroom");
            lock (zrbo)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " obtained the lock");
                Thread.Sleep(rand.Next(2000));
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " on my way to release the lock");
            } 
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " on my way to exit");
        }
    }
}
