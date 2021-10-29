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
           
           return new MyIEnumerator(this);
 
        }
        //as we said foreach uses IEnumerator to use movenext current
        class MyIEnumerator : IEnumerator<T>
        {
            //pointer to track where we at now in the list 
            int index = -1;
            List<T> thelist;
            public MyIEnumerator(List<T> thelist)
            {
                this.thelist = thelist;
            }

            public bool MoveNext()
            {
                Console.WriteLine("moved");
                return ++index < thelist.count;
            }

            public T Current
            {
                get
                {
                    if (index < 0 || thelist.count <= index)
                        return default(T);
                    return thelist.arr[index];
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                index = -1;
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
            //foreach (var item in mylist)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach syntax sugar
            IEnumerator<int> iterator = mylist.GetEnumerator();
            Console.WriteLine(iterator.Current);
            iterator.MoveNext();
            Console.WriteLine(iterator.Current);





        }
    }
}
