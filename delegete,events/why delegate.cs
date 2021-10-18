using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    class why_delegate
    {

        public static void run()
        {
            IEnumerable<int> result = getallnumberlessthanfive(
                new[] { 1, 2, 5, 7, 8, 9, 10 });
            foreach (int number in result)
                Console.WriteLine(number);
        }
        //diffrence between the two is just instead if 5 we put 10 , so instead of copy and past
        //we can pass also value to the IEnumerable (IEnumerable<int> numbers,int value)
        //but what if the expression change from < to >
        static IEnumerable<int> getallnumberlessthanfive(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                if (number < 5)
                    yield return number;
            }
        }
        static IEnumerable<int> getallnumberlessthanten(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                if (number < 10)
                    yield return number;
            }
        }
        static IEnumerable<int> getallnumbergraterthanten(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                if (number > 10)
                    yield return number;
            }
        }
    }


    class why_delegate_Solution
    {
        delegate bool medelegete(int number);

        static bool lessthanfive(int number) { return number < 5; }
        static bool lessthanten(int number) { return number < 10; }
        static bool greaterthanten(int number) { return number > 10; }

        //now our code is much simpler and pretty due to the delegte ,we just send the target function that 
        //we want to be called to calculated the right value 
        public static void run()
        {
            int[] arr = new[] { 1, 2, 5, 7, 8, 9, 10, 3124, 312, 314, 6, 7, 80 };

            IEnumerable<int> result = runnumberthroughcalc(greaterthanten, arr);

            foreach (int number in result)
                Console.WriteLine(number);
        }

        static IEnumerable<int> runnumberthroughcalc(medelegete calc, IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                if (calc(number))
                    yield return number;
            }
        }
    }
    class why_delegate_Solution_with_lambda
        {
        delegate bool medelegete(int number);
        
        //now our code is much simpler and pretty due to the delegte ,we just send the target function that 
        //we want to be called to calculated the right value 
        public static void run()
        {
            int[] arr = new[] { 1, 2, 5, 7, 8, 9, 10, 3124, 312, 314, 6, 7, 80 };

            IEnumerable<int> result = runnumberthroughcalc((number) => (number < 5), arr);
            // (number) is the argument and before => and after the arrow is the body of the method 
            //in misl level il level compiler convert this like we declare it above ,

            foreach (int number in result)
                Console.WriteLine(number);
        }

        static IEnumerable<int> runnumberthroughcalc(medelegete calc, IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                if (calc(number))
                    yield return number;
            }
        }
    }

}
