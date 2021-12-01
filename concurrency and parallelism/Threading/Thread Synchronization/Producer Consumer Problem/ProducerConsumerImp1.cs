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
        static List<int> Sums = new List<int>(ThreadNum);
        public static void run()
        {
            ProduceNumers();
            for (int i = 0; i < 3; i++)
            {
                new Thread(SumNumbers).Start(i);
            }
        }

        static void SumNumbers(object ThreadNumber)
        {
            DateTime StartTime = DateTime.Now;
            int mySum = 0;
            while ((DateTime.Now - StartTime).Seconds < 10)
            {
                if (Numbers.Count != 0)
                {
                    mySum += Numbers.Dequeue();
                }
            }
            Sums[(int)ThreadNumber] = mySum;
        }
        static void ProduceNumers()
        {
            for (int i = 0; i < 25; i++)
            {
                Numbers.Enqueue(rand.Next(10));
                Thread.Sleep(rand.Next(1000));
            }
        }



    }
}
