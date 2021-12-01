using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace concurrency_and_parallelism.Threading
{
    //normal queue will through an error if we try to Dequeue an empty queue ....
    class NoneBlockingQueue<T>
    {
        readonly Queue<T> queue = new Queue<T>();

        public void Enqueue(T item)
        {
            lock(queue)
            {
                queue.Enqueue(item);
                Monitor.Pulse(queue);

            }
        }
        public T Dequeuee()
        {
            lock (queue)
            {
                //we put this for loop because if we dont it will complain about not all code path reutrn a value
                for (;;)
                {
                    if (queue.Count > 0)
                        return queue.Dequeue();
                    Monitor.Wait(queue);
                }
              
            }
        }





    }
}
