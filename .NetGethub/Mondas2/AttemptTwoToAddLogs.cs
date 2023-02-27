using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondas2
{
    internal class AttemptTwoToAddLogs
    {
        public static void Run()
        {
            //This approach have problem because we cannot align the type and compose them 
            //Square(Square(2)); unless we do this Square(Square(2).Result); of we also introduce 
            //the number wrapper that make the number enter the NumberWithLogs world
            //another problem that we cannot send number to AddOne(2) so  we can fix this be adding
            //a wrapper function that help number to enter the numberOfLogs
            //echo system, now we can do this 

            //make the number enter the AddOne NumberWithLogs world
            AddOne(WrapWithLogs(2));
            Square(Square(WrapWithLogs(2)));


        }
        public static NumberWithLogs Square(NumberWithLogs number)
        {
            number.Result = number.Result * number.Result;
            //problem here is rdundancy of adding the logs
            number.Logs.Add("square function get called");
            return number;
        } 

        public static NumberWithLogs AddOne(NumberWithLogs number)
        {
            number.Result = number.Result + 1;
            number.Logs.Add("AddOne function get called");
            return number;
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
