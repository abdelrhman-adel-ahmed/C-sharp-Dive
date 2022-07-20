using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace concurrency_and_parallelism.SynchronizationTechnique
{
    class Bathroom
    {
        public void BeUsed(int threadNumber)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"thead {threadNumber} is using bathroom");
                Thread.Sleep(500);
            }
        }
    }
    class Locks
    {
        static Bathroom stall = new Bathroom();
        public static void Run()
        {
            for (int i = 0; i < 3; i++)
            {
                new Thread(RegularUser).Start();
            }
            new Thread(ShittyUser).Start();
        }
        static void RegularUser()
        {
            //if we lock the stall object here without locking down in shittyUser , that will not prevent 
            //the shittyUser thread from accessing the object method , although we lock the object ! 
            lock(stall)
                stall.BeUsed(Thread.CurrentThread.ManagedThreadId);
        }
        static void ShittyUser()
        {
            stall.BeUsed(100);
        }
    }
}
