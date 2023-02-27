using System;
using System.Collections;
using System.Linq;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Diagnostics;

namespace MutableAndImutableIndotNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // var list = ImmutableList.Create<string>("1");
            // list.Add("2");
            // list.ForEach(x => Console.WriteLine(x));
            //
            // var refrenceObj = new List<string> { "22" };
            // refrence(refrenceObj);
            // refrenceObj.ForEach(x => Console.WriteLine(x));
            //
            // var valueObj = new test { x = 200 };
            // value(valueObj);
            // Console.WriteLine(valueObj.x);
            // Console.WriteLine(valueObj.GetType().GetType());
            // Console.WriteLine(refrenceObj.GetType().GetType());
            string x = null;
            shit();
        }

        static void shit()
        {
            Logger.WriteToLogFile(ActionTypeEnum.Information, new StackFrame(1, true), "hello");

        }
        static void refrence(List<string> s)
        {
            s.Add("1");
        }
        static void value(test t)
        {
            t.x = 100;
        }
    }

    public struct test
    {
        public int x;
    }
}
