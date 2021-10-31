using System;
using System.Collections.Generic;
using System.Text;

namespace Containers_diff
{
    class IEnumerable_vs_IEnumerator2
    {



        public static void run()
        {
            //why ienumerator remember and ienmerable doesnto ? despite they both use the yield (not true). 
            //i think because the foreach we use in the ienumberable , but we use the movenext pointer on 
            //the ienumerrator ,but the foreach under the hood is just movenext !?
            //because the ienumeratr use yield ,but ienumberable construct foreach loop each time and when we do
            //that we create a new ienumerator 
            List<int> Ages = new List<int>()
            {
                10,
                20,
                30,
                40,
                50,
                60,
                70
            };
            // IEnumerator can remember the state IEnumerable cannot
            IEnumerable<int> ienm = Ages;
            IEnumerator<int> iterator = Ages.GetEnumerator();
            IterateFrom10to30(iterator);

        }

        static void IterateFrom10to30(IEnumerator<int> iterator)
        {
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
                if (iterator.Current > 30)
                    IterateFrom40(iterator);

            }
        }
        static void IterateFrom40(IEnumerator<int> iterator)
        {
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
        }

        static void IterateFrom10to30(IEnumerable<int> enunm)
        {
            foreach (var item in enunm)
            {
                Console.WriteLine(item);
                if (item > 30)
                    IterateFrom40(enunm);
            }
        }
        static void IterateFrom40(IEnumerable<int> enunm)
        {
            foreach (var item in enunm)
            {
                Console.WriteLine(item);
            }
        }

    }
}
