using System;
using System.Linq;

namespace Mondas2
{
    internal class AttemptThreeToAddNumberWithLogs
    {
        /*
         monads : 
        1-  wraper type in or ex numberWithLogs 
        2 - wrape normal values and allow entry to the monad ecosystem in our ex WrapWithLogs (yielding monadic value)
        3- Run Function (the transform operator (shuveee) ) takes wrapper type and transform function 
        that accept the unwrape type and return the wraper type 
        or we can say compose function that output monadic values (monadic function)

        sooooooooo
        we have Square -> int: MInt (NumberWithLogs)
                AddOne -> int: MInt (NumberWithLogs)

        ex. nullabel  
        1- wrapper type is the Nullable
        2- wrapper of normal values are the constructor of the nullable 
        3- run function , we can say it .value which unwrap the nullabel and give us the value back
        so we can say a: a => Ma (m here is nullablity of a)
         */
        public static void Run()
        {
            var a = WrapWithLogs(2);
            var b = RunWithLogs(a, Square);
            var c = RunWithLogs(b, Square);
        }

        public static NumberWithLogs RunWithLogs(NumberWithLogs input, Func<int, NumberWithLogs> transform)
        {
            NumberWithLogs newNumberWithLogs = transform(input.Result);

            var obj = new NumberWithLogs
            {
                Result = newNumberWithLogs.Result
            };
            input.Logs.Add(string.Join(',', newNumberWithLogs.Logs));
            obj.Logs.AddRange(input.Logs);
            return obj;
        }
        public static NumberWithLogs Square(int number)
        {

            var obj = new NumberWithLogs
            {
                Result = number * number
            };
            obj.Logs.Add("Square one added one to the result");
            return obj;
        }

        public static NumberWithLogs AddOne(int number)
        {
            var obj = new NumberWithLogs
            {
                Result = number + 1
            };
            obj.Logs.Add("AddOne function get called");
            return obj;
        }
        public static NumberWithLogs WrapWithLogs(int number)
        {
            return new NumberWithLogs
            {
                Result = number
            };
        }
    }
}
