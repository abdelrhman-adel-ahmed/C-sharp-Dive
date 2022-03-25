using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Containers_Ienumerable
{

    class List<T> : IEnumerable<T>
    {
        T[] arr = new T[6];
        int count;
        public void Add(T item)
        {
            if (arr.Length == count)
                Array.Resize(ref arr, arr.Length * 2);
            arr[count++] = item;
        }
     
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return arr[i];
            }
        }

        //non generic IEnumerable,shit hole :) when ever you see generic types there is non generic
        //types because microsoft push the realese without generics and then add generics 
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class IEnumerable_vs_IEnumerator
    {

        public static void run()
        {
            //we can do this sytanx sugar ,the compiler will convert and add ,the add method to add
            // the item ---but--- without adding the IEnumeralbe it will not work 
            //List<int> mylist = new List<int>() { 1, 2, 3 };
            //foreach (var item in mylist)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine();

            //IEnumerable<int> ienm = mylist;
            //foreach (var item in ienm)
            //{
            //    Console.WriteLine(item);
            //} List<int> mylist = new List<int>() { 1, 2, 3 };
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
            Task.Delay(10000);
            IterateFrom10to30(ref ienm);

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

        static void IterateFrom10to30(ref IEnumerable<int> enunm)
        {
            foreach (var item in enunm)
            {
                Console.WriteLine(item);
                if (item > 30)
                    IterateFrom40(ref enunm);
            }
        }
        static void IterateFrom40(ref IEnumerable<int> enunm)
        {
            foreach (var item in enunm)
            {
                Console.WriteLine(item);
            }
        }
    }
}
