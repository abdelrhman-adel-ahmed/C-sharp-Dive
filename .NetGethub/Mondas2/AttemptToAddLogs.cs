using System.Collections.Generic;
using System.Linq;

namespace Mondas2
{
    internal class AttemptToAddLogs
    {

        public static void Run()
        {
            //This approach have problem because we cannot align the type and compose them 

            //Square(Square(2));
            AddOne(Square(2));
        }
        public static NumberWithLogs Square(int number)
        {
            var obj = new NumberWithLogs();
            obj.Result = number * number;
            obj.Logs.Add("Square function ran and added one");
            return obj;
        }

        public static NumberWithLogs AddOne(NumberWithLogs number)
        {
            var obj = new NumberWithLogs();
            obj.Result = number.Result + 1;
            obj.Logs.Add("Add one added one to the result");
            return obj;
        }
    }
}
