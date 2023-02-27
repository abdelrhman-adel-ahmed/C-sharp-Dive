using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading;

namespace MutableAndImutableIndotNet
{

    struct SolidStruct
    {
        public SolidStruct(int value)
        {
            X = Y = Z = value;
        }

        public readonly int X;
        public readonly int Y;
        public readonly int Z;

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", X, Y, Z);
        }
    }


    public struct Point3D
    {
        private static Point3D origin = new Point3D(0, 0, 0);

        public static ref Point3D Origin => ref origin;
        public int x, y, z;
        public Point3D(int _x, int _y, int _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
        // other members removed for space
    }
    class Program
    {
        static SolidStruct s_value;
        static List<int> ss = new List<int>() { 1, 2, 3 };

        static ref readonly List<int> tt()
        {
            return ref ss;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------test1-------------------------------------");
            //  var t = new test1(1,"dsa");
            drivedFromImmutable naughty = new drivedFromImmutable(1);
            UnsealedImmutable mmm = naughty;
            Console.WriteLine(mmm); // note: base class can access the drived class override tostring method
            naughty.otherValue = 100;
            Console.WriteLine(mmm);
            Console.WriteLine("-------------------------------------------------------------------------");
            ref readonly var x =ref tt();
            x[0] = 100;
            Console.WriteLine(ss[0]);

            Console.ReadKey();
            // var x = new SolidStruct(1);
            // SolidStruct y = x;
            // Thread t = new Thread(LookAtValue);
            // t.IsBackground = true;
            // t.Start();
            //
            // for (int i = 0; i < int.MaxValue; ++i)
            // {
            //     s_value = new SolidStruct(i);
            // }
        }
        static void LookAtValue()
        {
            while (true)
            {
                SolidStruct value = s_value;
                if (value.X != value.Y || value.Y != value.Z)
                {
                    Console.WriteLine(value);
                }

                Console.ReadLine();
            }
        }
    }
}
