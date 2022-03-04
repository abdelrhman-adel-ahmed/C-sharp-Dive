using System;
using System.Collections;
using System.Linq;
using System.Collections.Immutable;
namespace MutableAndImutableIndotNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = ImmutableList.Create<string>("1");
            list.Add("2");
            list.ForEach(x => Console.WriteLine(x));

        }
    }
}
