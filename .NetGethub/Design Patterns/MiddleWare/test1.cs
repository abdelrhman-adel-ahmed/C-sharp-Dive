using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    class test1
    {

        public static void run()
        {
            //Wrap(First);
            //Wrap(Second);
            Try(() => Wrap(First));
            Wrap(() => Try(Second));
        }
        public static void First()
        {
            Console.WriteLine("exc first func");
        }

        public static void Second()
        {
            Console.WriteLine("exc Second func");

        }

        public static void Wrap(Action function)
        {
            Console.WriteLine("start");
            function();
            Console.WriteLine("end");
        }

        public static void Try(Action function)
        {
            try
            {
                Console.WriteLine("trying");
                function();
            }
            catch(Exception)
            {

            }
        }

    }
}
