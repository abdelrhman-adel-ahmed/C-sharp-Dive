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

            Console.WriteLine("----------------Difference_Between_Background_and_Foreground_Thread--------------------");
            Difference_Between_Background_and_Foreground_Thread.run();
        }

    }
}
