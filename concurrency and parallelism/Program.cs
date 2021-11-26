using System;
using System.Threading.Tasks;

namespace concurrency_and_parallelism
{
    class Program
    {
        /*
         one thing to notice is once we go the asynchronous path we are no longer allowed to have asynchronous just 
            in one sort of place it --propagates-- through our code from the buttom to up up and up the main. 
            
        so here we change the boilwater func and make the waiting for the boiling to be async so we change the func 
        but we also go and change the function that call that function to async ,and then the main also because it 
        calling the function that we changed to async,
         */
        static void Main(string[] args)
        {
            Console.WriteLine(Maketee());
        }
        static async  Task<string> Maketee()
        {
            var bollingWater = BoileWaterAsync();
            Console.WriteLine("Take the cups out");

            Console.WriteLine("put tea in cups");

            var water = await bollingWater;
            string tea = $"pour {water} in cups";

            return tea;
        }

        private static async Task<string> BoileWaterAsync()
        {
            Console.WriteLine("start the kettle");

            Console.WriteLine("waiting for the kettle");
            await Task.Delay(2000);

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
