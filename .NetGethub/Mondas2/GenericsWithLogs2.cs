using System;
using System.Collections.Generic;

namespace Monads2.generic2
{
    internal class GernericWithLogsMonad2
    {
        /*
         * 1- need mondaic type (container) that have the type and the extra operation we want to do
         * 2- wrapper that take the type and yield monadic type 
         * 3- compose function that output monadic values 
         */
        public static void Run()
        {
           int a = 2;
           int result = MonadExtenssion.RunWithLogs(MonadExtenssion.RunWithLogs(a,Square),AddOne).Result;
           int result2 = a.RunWithLogs(Square).RunWithLogs(AddOne).Result;
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
    public static class MonadExtensionMethods
    {
        public static ThingsWithLogs<T> RunWithLogs<T>(this ThingsWithLogs<T> input, Func<T, ThingsWithLogs<T>> func)
        {
            ThingsWithLogs<T> result = func(input.Result);
            ThingsWithLogs<T> obj = new ThingsWithLogs<T>
            {
                Result = result.Result
            };
            obj.Logs.AddRange(result.Logs);
            return obj;
        }
        public static ThingsWithLogs<T> RunWithLogs<T>(this T input, Func<T, ThingsWithLogs<T>> func)
        {
            return RunWithLogs(Wrape(input), func);
        }

        public static ThingsWithLogs<T> Wrape<T>(this T input)
        {
            return new ThingsWithLogs<T>
            {
                Result = input,
                Logs = new List<string>()
            };
        }
    }
    public static class MonadExtenssion
    {
        public static ThingsWithLogs<T> RunWithLogs<T>(ThingsWithLogs<T> input, Func<T, ThingsWithLogs<T>> func)
        {
            ThingsWithLogs<T> result = func(input.Result);
            ThingsWithLogs<T> obj = new ThingsWithLogs<T>
            {
                Result = result.Result
            };
            obj.Logs.AddRange(result.Logs);
            return obj;
        }
        public static ThingsWithLogs<T> RunWithLogs<T>(T input, Func<T, ThingsWithLogs<T>> func)
        {
            return RunWithLogs(Wrape(input), func);
        }

        public static ThingsWithLogs<T> Wrape<T>(T input)
        {
            return new ThingsWithLogs<T>
            {
                Result = input,
                Logs = new List<string>()
            };
        }
    }
}
