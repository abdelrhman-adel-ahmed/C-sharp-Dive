using System;
using Containers_;
using Containers_Ienumerable;
using Containers_diff;
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

    class Program
    {
        static void Main(string[] args)
        {
           

            intfce b1 = new drivied2();
            drived1 d = (drived1)b1;


            //Console.WriteLine("---------------arrays-------------------");
            //arrays.run();

            //Console.WriteLine("---------------IEnumeratorr-------------------");
            //IEnumeratorr.run();

            //Console.WriteLine("---------------IEnumerable_vs_IEnumerator-------------------");
            //IEnumerable_vs_IEnumerator.run();

            //Console.WriteLine("---------------IEnumerable_vs_IEnumerator2-------------------");
            //IEnumerable_vs_IEnumerator2.run();


        }
    }
}
