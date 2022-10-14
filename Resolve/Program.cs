using Resolver2;
using System;

namespace Resolve1
{
    public class Base : IBase
    {
        public Base()
        {
        }

        public void print()
        {
            System.Console.WriteLine("aaa");
        }
    }
    public class Base2 : IBase2
    {
        public void print2()
        {
            throw new NotImplementedException();
        }
    }

}
