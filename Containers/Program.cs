using System;
using Containers_;
using Containers_Ienumerable;
using Containers_diff;
using System.IO;
using System.Text;
using System.Threading.Tasks;

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

        static async Task Main(string[] args)
        {

            //Console.WriteLine("---------------arrays-------------------");
            //
            //arrays.run();
            //
            // Console.WriteLine("---------------IEnumeratorr-------------------");
            // IEnumeratorr.run();
            // 
            //Console.WriteLine("---------------IEnumerable_vs_IEnumerator-------------------");
            //IEnumerable_vs_IEnumerator.run();
            //
            //Console.WriteLine("---------------IEnumerable_vs_IEnumerator2-------------------");
            //IEnumerable_vs_IEnumerator2.run();
            Console.WriteLine("7xGv44eFFXnQasXP7QH3xtNmkdqBAW5p".Length);
            try
            {
                int x = await Rune();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("ahmed");
        }
        static Task<int> Rune()
        {
            Task<int> t;
            try
            {
                t = Do();
                Console.WriteLine("dsada");
                return t;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Do();
        }
        async static Task<int> Do()
        {
            await Task.Delay(2000);
            throw new Exception("excpppppppppppppppppppp");
        }
    }
}
