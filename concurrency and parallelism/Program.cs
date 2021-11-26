using System;
using System.Threading.Tasks;

namespace concurrency_and_parallelism
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Maketee());
        }

        static string Maketee()
        {
            var water = BoileWater();
            Console.WriteLine("Take the cups out");

            Console.WriteLine("put tea in cups");
            string tea = $"pour {water} in cups";
            return tea;
        }

        private static string BoileWater()
        {
            Console.WriteLine("start the kettle");

            Console.WriteLine("waiting for the kettle");
            Task.Delay(2000).GetAwaiter().GetResult();

            Console.WriteLine("kettle finishe");
            return "water";
        }
    }
}
