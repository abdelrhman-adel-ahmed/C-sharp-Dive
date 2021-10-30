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
            //in 99% we can just use yield return ,but if you want to write some logic inside the 
            //IEnumerator you can override the behaviour and do so
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
            //non generic IEnumerator
            object IEnumerator.Current => Current;

            public void Dispose()
            {
                //throw new NotImplementedException();
                //free reasoses !! always get called at the end
                //may be you iterate over things in a set in db and want to close connection 
                //after finsh ,so you can put the freeing logic here
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
            //so foreach just call the get enumerator function and refurn ienumerator 
            //then it use movenext and set the item to the current

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
