using System;
using Containers_;
using Containers_Ienumerable;
using Containers_diff;
using System.IO;
using System.Text;

namespace Containers
{

    interface intfce { }
    class drived1 : intfce
    {
        public void x()
        {

        }
    }
    class drivied2 : intfce
    {
        public void print()
        {

        }
    }


    class test1
    {
        public int tt { get; }
        public string ss { get; } = new string("Dsaddddddddd");

        public test1(int x, string y)
        {
            Console.WriteLine(ss.GetHashCode());
            tt = x;
            ss = y;
            Console.WriteLine(ss.GetHashCode());
        }
    }

    class Program
    {
        static readonly string DBPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? "", @"UploaderDB.db");

        static void Main(string[] args)
        {
        
            //Console.WriteLine("---------------arrays-------------------");
            //
            //arrays.run();
            //
           Console.WriteLine("---------------IEnumeratorr-------------------");
           IEnumeratorr.run();
           
            //Console.WriteLine("---------------IEnumerable_vs_IEnumerator-------------------");
            //IEnumerable_vs_IEnumerator.run();
            //
            //Console.WriteLine("---------------IEnumerable_vs_IEnumerator2-------------------");
            //IEnumerable_vs_IEnumerator2.run();


        }
    }
}
