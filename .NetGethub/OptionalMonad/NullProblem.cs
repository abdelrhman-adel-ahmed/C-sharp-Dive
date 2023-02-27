using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace OptionalMonad
{
    public class NullProblem
    {
        public static void Run()
        {
            Person? p1 = Person.Create("ahmed", "mohamed");
            Person? p2 = Person.Create("ali");
            Person p3 = Person.Create("ahmed", "mohamed");
            Console.WriteLine(GetLabel(p1));
            Console.WriteLine(GetLabel(p2));
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            keyValuePairs.Add(1, "ahmed");
            string keyvalue;
            keyValuePairs.TryGetValue(2, out keyvalue);
            //string xx = null;
            //int? l = xx?.Length;
            string? xxx = null;
            int? lll = xxx?.Length;
            int result = func1(func2(func3(2))); //func1 * (func2 *func3) or (func1 *func2) *func3)
            int result2 = func3(func1(func2(2)));
            List<string> strings = new List<string>();
            var boxes = new List<Box> { 
                new Box { Name = "box1", Number = new[] { 1, 2, 3, 4 } },
                new Box { Name = "box2", Number = new[] { 5, 6, 7, 8 } }
             //   new Box { Name = "box3", Number = new[] { 9, 10, 11, 12 }
            
            };
            var query1 = SelectManyImpl(boxes, ff);
            //var query2 = boxes.SelectMany(ff, (box, number) => (number,box.Name));
            var query2 = SelectManyImpl2(boxes,ff, (box, number) => (number, box.Name));
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
        static int func1(int a)
        {
            return a * 2;
        }
        public static int func2(int a)
        {
            return a * 3;
        }
        public static int func3(int a)
        {
            return a * 4;
        }
        public static string GetLabel(Person person)
        {
            /*
             * problems here is first you need to remember the null checks therefore 
             * (face null refrence exception at run time)
             * second is there will be many null checks in the codeBase
             */
            string name = person.LastName is null ? person.FirstName :
                $"{person.FirstName} {person.LastName}";
            return name;
        }
    }

    class Box
    {
        public string Name { get; set; }
        public int[] Number { get; set; }
    }
    public class Person
    {
        public string FirstName { get; }
        public string? LastName { get; }

        public Person(string firstName, string lastName) =>
            (FirstName, LastName) = (firstName, lastName);

        public static Person Create(string firstName, string lastName) =>
            new(firstName, lastName);

        public static Person Create(string firstName) => new(firstName, null);
    }
}
