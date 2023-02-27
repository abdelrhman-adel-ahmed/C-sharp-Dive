using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monads2
{
    internal class GernericWithLogsMonad
    {

        public static void Run()
        {
            var a = MonadExtenssion<int>.Wrape(5);
            var b = MonadExtenssion<int>.RunWithLogs(a, Square);
            var c = MonadExtenssion<int>.RunWithLogs(b, AddOne);
        }


        public static ThingsWithLogs<int> AddOne<T>(T input)
        {
            ThingsWithLogs<int> obj = new ThingsWithLogs<int>
            {
                Result = Convert.ToInt32(input) + 1
            };
            obj.Logs.Add("add one get called");
            return obj;
        }
        public static ThingsWithLogs<int> Square<T>(T input) 
        {
            int ss = Convert.ToInt32(input);
            ThingsWithLogs<int> obj = new ThingsWithLogs<int> { Result = ss * ss };
            obj.Logs.Add("Square one get called");
            return obj;
        }
    }

    public class ThingsWithLogs<T>
    {
        public T Result { get; set; }
        public List<string> Logs { get; set; } = new List<string>();
    }

    public static class MonadExtenssion<T>
    {
        public static ThingsWithLogs<T> RunWithLogs(ThingsWithLogs<T> input, Func<T, ThingsWithLogs<T>> func)
        {
            ThingsWithLogs<T> result = func(input.Result);
            ThingsWithLogs<T> obj = new ThingsWithLogs<T>
            {
                Result = result.Result
            };
            obj.Logs.AddRange(result.Logs);
            return obj;
        }

        public static ThingsWithLogs<T> Wrape(T input)
        {
            return new ThingsWithLogs<T>
            {
                Result = input,
                Logs = new List<string>()
            };
        }
    }
}
