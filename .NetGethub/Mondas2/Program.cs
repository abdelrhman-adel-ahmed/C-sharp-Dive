using Monads2;
using Monads2.generic2;
using System;
using System.Collections.Generic;

namespace Mondas2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AttemptTwoToAddLogs.Run();
            //AttemptThreeToAddNumberWithLogs.Run();
            //GernericWithLogsMonad.Run();
            GernericWithLogsMonad2.Run();
        }

        public int Sqaure(int number)
        {
            return number * number;
        }

        public int AddOne(int number)
        {
            return number + 1;
        }
    }

    class NumberWithLogs
    {
        public int Result { get; set; }
        public List<string> Logs { get; set; } = new List<string>();
    }
}
