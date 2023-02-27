using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace concurrency_and_parallelism.Async
{
    class AsyncMakeTea
    {
        /*
       one thing to notice is once we go the asynchronous path we are no longer allowed to have asynchronous just 
          in one sort of place it --propagates-- through our code from the buttom to up up and up the main. 

      so here we change the boilwater func and make the waiting for the boiling to be async so we change the func 
      but we also go and change the function that call that function to async ,and then the main also because it 
      calling the function that we changed to async,
       */

        public static async Task run()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(await (Maketee()));
        }
        static async Task<string> Maketee()
        {
            var bollingWater = BoileWaterAsync();
            Console.WriteLine("Take the cups out");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("put tea in cups");

            var water = await bollingWater;
            string tea = $"pour {water} in cups";
            return tea;
        }

        private static async Task<string> BoileWaterAsync()
        {
            Console.WriteLine("start the kettle");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("waiting for the kettle");
            await Task.Delay(1000);
            //any thing that have await , will be done in diffrent thread and the rest of the function will be done 
            //in that thread 
            Console.WriteLine("@@@the waiting Task done by another thread " + Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("kettle finishe");
            return "water";
        }
        //static string Maketee()
        //{
        //    var water = BoileWater();
        //    Console.WriteLine("Take the cups out");

        //    Console.WriteLine("put tea in cups");
        //    string tea = $"pour {water} in cups";
        //    return tea;
        //}

        //private static string BoileWater()
        //{
        //    Console.WriteLine("start the kettle");

        //    Console.WriteLine("waiting for the kettle");
        //    Task.Delay(2000).GetAwaiter().GetResult();

        //    Console.WriteLine("kettle finishe");
        //    return "water";
        //}
    }
}
