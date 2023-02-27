using System;
using Microsoft.EntityFrameworkCore;
using scaffoldingDbUsingEfCore.Model;

namespace scaffoldingDbUsingEfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FirstDBContext db = new FirstDBContext();

            var employess = db.Employees.AsAsyncEnumerable();
            var en = employess.GetAsyncEnumerator();
            while(en.MoveNextAsync().Result)
            {
                Console.WriteLine(en.Current.Name);
            }
          
            Console.ReadLine();
        }
    }
}
