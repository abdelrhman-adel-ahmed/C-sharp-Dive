using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace concurrency_and_parallelism.Threading

//we have multiple consumer that want to cooperate with each other to take numbers from a list and add them
{
    class ProducerConsumerImp1
    {
        static Queue<int> Numbers = new Queue<int>();
        static Random rand = new Random();
        const int ThreadNum = 3;
        //the capacity of the list will be the num of threads ,each thread will put the sum that it calcualted in the 
        //Sums list 
        static List<int> Sums = new List<int>() { 0, 0, 0 };
        static List<Thread> threads = new List<Thread>();
        static object xx = new object();
        static bool ProducerFinish = false;
        public static void run()
        {
            new Thread(ProduceNumers).Start();
            Thread.Sleep(1000);
            for (int i = 0; i < ThreadNum; i++)
            {
                Thread t1 = new Thread(SumNumbers);
                t1.Start(i);
                threads.Add(t1);
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
            int sum = 0;
            foreach (var num in Sums)
            {
                sum += num;
            }
            Console.WriteLine(sum);
        }

        static void SumNumbers(object ThreadNumber)
        {
            DateTime StartTime = DateTime.Now;
            int mySum = 0;
            //thread will keep pulling out numbers from the queue as long as 
            //1- the time between the thread start and now is less than 10 sec ,2- there is something in the queue 
            //but if the time is not pased and there is nothing in the queue the thread will keep thrashing the cpu
            //inside the loop even if there is nothing to pull
            while ((DateTime.Now - StartTime).Seconds < 10)
            {
                //we put the lock here beacuse one thread can enter and dequee and item and then queue will be empty
                //and then other thread pass the condition before the other thread dequeue then it try to deqeueu
                //so it will throw an excpetion , also the queue here i think is not support conccurency so
                //i think two thread can dequee the same item 

                /*
                 in .net 1.0 if there is an excption in non main thread if the excption is not handled ,the thread
                would die but the process will keep going ,in version 2.0 if the thread that have un handeled 
                excption the entire process will die, you can configure that 
                 */
                lock (xx)
                {
                    if (Numbers.Count != 0)
                    {
                        int CurrentNum = Numbers.Dequeue();                  
                        Console.WriteLine($"consuming thread {ThreadNumber} : consume { CurrentNum}");
                        mySum += CurrentNum;
                    }
                }
            }
            //or we can use conccurent collection 
            lock (Sums)
                Sums.Insert((int)ThreadNumber, mySum);
            //may be all consuming threads finish before the producer finish so they will print out the sums 
            //so i want them to wait until the producer finish even if the time they supose to run in finishes
            while (!ProducerFinish) { continue; }
        }
        static void ProduceNumers()
        {
            for (int i = 0; i < 25; i++)
            {
                //Numbers.Enqueue(rand.Next(10));
                Console.WriteLine($"Producing thread produced: {i}");
                Numbers.Enqueue(i);
                Thread.Sleep(rand.Next(1000));
            }
            ProducerFinish = true;
        }



    }
}
