using System;
using System.Threading.Tasks;
using concurrency_and_parallelism.Async;

namespace concurrency_and_parallelism
{
    class Program
    {
      
        static async Task Main(string[] args)
        {
           await AsyncMakeTea.run(); 
        }
   
    }
}
