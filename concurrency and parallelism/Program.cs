﻿using System;
using System.Threading.Tasks;
using concurrency_and_parallelism.Async;
using concurrency_and_parallelism.Threading;
namespace concurrency_and_parallelism
{

    class Program
    {

        //static async Task Main(string[] args)
        //{
        //await AsyncMakeTea.run(); 
        //}
        static void Main(string[] args)
        {

            // ThreadOverHead.ThreadoverHead();

            // Console.WriteLine("----------------Hello_World_Thread--------------------");
            // Hello_World_Thread.run();

            // Console.WriteLine("----------------Sync--------------------");
            // Sync.run();

            // Console.WriteLine("----------------Difference_Between_Background_and_Foreground_Thread--------------------");
            // Difference_Between_Background_and_Foreground_Thread.run();

            // Console.WriteLine("----------------Basic_Thread_Synchronization--------------------");
            // Basic_Thread_Synchronization.run();

            // Console.WriteLine("----------------AnotherSyncExample--------------------");
            // AnotherSyncExample.run();

            // Console.WriteLine("----------------LockKeyWord--------------------");
            // LockKeyWord.run();


            //Console.WriteLine("----------------Divide_and_Conquer__1--------------------");
            //Divide_and_Conquer__1.run();

            //Console.WriteLine("----------------Divide_and_Conquer__2--------------------");
            //Divide_and_Conquer__2.run();

           //Console.WriteLine("----------------Producer_Consumer_1--------------------");
           //Producer_Consumer_1.run();

           // Console.WriteLine("----------------ProducerConsumerImp1--------------------");
           // ProducerConsumerImp1.run();
            int sum = 0;
            for (int i = 0; i < 25; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);
        }

    }
}
