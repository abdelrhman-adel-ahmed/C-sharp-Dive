using System;
using System.Collections.Generic;

namespace LINQ.LinqOperatorsImp
{
    internal class SelectManyImp
    {
        public static void Run()
        {
            var boxes = new List<Box> {
                new Box { Name = "box1", Number = new[] { 1, 2, 3, 4 } },
                new Box { Name = "box2", Number = new[] { 5, 6, 7, 8 } }
             //   new Box { Name = "box3", Number = new[] { 9, 10, 11, 12 }
            
            };
            var query1 = SelectManyImpl(boxes, ff);
            //var query2 = boxes.SelectMany(ff, (box, number) => (number,box.Name));
            var query2 = SelectManyImpl2(boxes, ff, (box, number) => (number, box.Name));
            var ss2 = ToListImp(query2);
            var ss = ToListImp(query1);
        }
        public static List<TSource> ToListImp<TSource>(IEnumerable<TSource> source)
        {
            return new List<TSource>(source);
        }
        private static IEnumerable<TResult> SelectManyImpl<TSource, TResult>(
             IEnumerable<TSource> source,
             Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (TSource item in source)
            {
                foreach (TResult result in selector(item))
                {
                    yield return result;
                }
            }
        }
        private static IEnumerable<TResult> SelectManyImpl2<TSource, TCollection, TResult>(
              IEnumerable<TSource> source,
              Func<TSource, IEnumerable<TCollection>> selector,
              Func<TSource, TCollection, TResult> resultSelector)
        {
            foreach (TSource element in source)
            {
                foreach (TCollection subElement in selector(element))
                {
                    yield return resultSelector(element, subElement);
                }
            }
        }
        private static int[] ff(Box bo)
        {
            return bo.Number;
        }

    }
    class Box
    {
        public string Name { get; set; }
        public int[] Number { get; set; }
    }
}

