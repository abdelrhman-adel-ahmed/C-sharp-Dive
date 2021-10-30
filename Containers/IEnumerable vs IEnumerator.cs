using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
            List<int> mylist = new List<int>() { 1, 2, 3 };
            foreach (var item in mylist)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            IEnumerable<int> ienm = mylist;
            foreach (var item in ienm)
            {
                Console.WriteLine(item);
            }
        }
    }
}
