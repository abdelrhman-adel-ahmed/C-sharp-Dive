using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Patterns.MVC;
using Design_Patterns.repository;

namespace Design_Patterns
{


    class x
    {
        int lock_var = 0;
        public void lock_()
        {
            if (lock_var == 0)
            {
                lock_var = 1;
                return;
            }

            while (lock_var == 1)
                continue;
               
        }

            public void unlock_()
            {

            }
        }

        class Program
        {


            static void Main(string[] args)
            {
                int result = 0;
                x xx = new x();
                List<int> collection = new List<int>();
                foreach (var item in collection)
                {
                    xx.lock_();
                    result += 1;
                    xx.unlock_();
                }
                //Console.WriteLine("---------MVC--------");
                //EntryPoint.Start();
                //Console.WriteLine("---------Dependency Inversion--------");
                //Entrypoint1.run();



                //Console.WriteLine("---------Repository--------");
                //Start.run();
                int result = 0;

                result += 1;
                Console.ReadLine();
            }
        }
    }
