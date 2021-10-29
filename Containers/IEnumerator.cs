using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Containers_
{
    class List<T>
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
        class MyIEnumerator : IEnumerator<T>
        {
            public T Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

    }

    class IEnumeratorr
    {
        public static void run()
        {
            List<int> mylist = new List<int>();
            mylist.Add(1);
            mylist.Add(2);
            mylist.Add(3);
            mylist.Add(45);
            foreach (var item in mylist)
            {
                Console.WriteLine(item);
            }

        }
    }
}
