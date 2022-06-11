using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> ll = new List<int> { 1, 2, 3 };
            var x = ll.Count();
            Do(ll);
        }

        static void Do<T>(T obj)  where T : IEnumerable
        {
            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }
    }
}
