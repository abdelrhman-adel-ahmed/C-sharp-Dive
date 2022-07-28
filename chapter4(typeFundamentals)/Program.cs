using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter4_typeFundamentals_
{

    class base1 { }
    class base2 { }
    class Test1
    {
        void test()
        {
            //system.object class have some methods overrideable :  tostring , equals , getHashCode, Finalize
            //not overrideable : getType , MemberwiseClone
            Test1 t = (Test1) this.MemberwiseClone();
            string stringRepresentation = this.ToString();
            int hashCode = this.GetHashCode();
        }
    }

    class Employee {
        public void X()
        {
            Console.WriteLine("this is employee");
        }
    }
    class Manager : Employee { 
        public void X()
        {
            Console.WriteLine("this is manager");
        }
    }
    class Program
    {
        public static async Task<int> A()
        {
            await Task.Delay(100);
            throw new Exception("A");
        }

        public static async Task<int> B()
        {
            await Task.Delay(100);
            throw new Exception("B");
        }

        public static async Task tt()
        {
            //var task = Task.WhenAll(A(), B());

            try
            {
                await Task.WhenAll(A(), B());
            }
            catch (Exception ex)
            {
               
            }
        }

        static async Task Main(string[] args)
        {
            await tt();
            byte t = 100;
            t = unchecked((byte)(t + 200));
            
            List<int> ttt = new List<int> { 1, 2, 3, 4, 5, 6 };
            Employee bb = new Manager();
            bb.X();
            Manager m = new Manager();
            Employee e = m as Employee;
            m.X();
            e.X();
            PromoteEmployee(m);
        }
        static void PromoteEmployee(Object o)
        {
            Employee e = (Employee)o;
        }
    }
}
