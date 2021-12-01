using System;
using System.Threading.Tasks;
using concurrency_and_parallelism.Async;
using concurrency_and_parallelism.Threading;
using System.Threading;

namespace concurrency_and_parallelism
{

    class Program
    {
        static NoneBlockingQueue<int> s = new NoneBlockingQueue<int>();
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

            //Console.WriteLine("----------------ProducerConsumerImp1--------------------");
            //ProducerConsumerImp1.run();

            Console.WriteLine("----------------NoneBlockingQueue--------------------");
            Thread t1 = new Thread(producerThread);
            Thread t2 = new Thread(consumner);
            t1.Start();
            t2.Start();
    
        }

        static void producerThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Producer Thread produced {i}");
                s.Enqueue(i);
            }
        }
        static void consumner()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Consumer Thread Consumed {s.Dequeuee()}"); 
            }
        }

    }
}
