using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace Containers.Yeild
{
    internal class MainClass
    {
        class GetRandomNumberClass : IEnumerable<int>, IEnumerator<int>
        {
            public int current;
            public int state;
            public int i;
            public int count;
            int IEnumerator<int>.Current => current;

            object IEnumerator.Current => current;
            public bool MoveNext()
            {
                switch (state)
                {
                    case 0:
                        i = 0;
                        goto case 1;
                    case 1:
                        state = 1;
                        if (!(i < count))
                        {
                            return false;
                        }
                        current = rand.Next();
                        state = 2;
                        return true;
                    case 2:
                        i++;
                        goto case 1;
                }

                return false;
            }
            public IEnumerator<int> GetEnumerator()
            {
                return this;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public void Reset()
            {
                throw new NotImplementedException();
            }
            public void Dispose()
            {
            }

        }
        public static Random rand = new Random();

        public static void Run()
        {
            // IEnumerator<int> en = new GetRandomNumberClass().GetEnumerator();
            // while (en.MoveNext())
            // {
            //     Console.WriteLine(en.Current);
            // }
            foreach (int num in GetRandomNumbers(10))
            {
                Console.WriteLine(num);
            }

        }

        // static IEnumerable<int> GetRandomNumbers(int count)
        // {
        //     for (int i = 0; i < count; i++)
        //     {
        //         yield return rand.Next();
        //     }
        // }
        static IEnumerable<int> GetRandomNumbers(int count)
        {
            GetRandomNumberClass rc = new GetRandomNumberClass() { count = 10 };
            return rc;
        }
    }
}
