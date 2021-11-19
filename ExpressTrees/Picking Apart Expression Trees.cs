﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressTrees
{
    class Picking_Apart_Expression_Trees
    {

       public static void run()
        {
            //Func<int, bool> del = i => i > 5;
            //constant is factory method that create and return ConstantExpression object
            //Expression class is full of factory methods
            ConstantExpression constExp = Expression.Constant(5, typeof(int));
            //NodeType is ExpressionType which is just enum with all experssion that avilable in c#
            Console.WriteLine(constExp.NodeType);
            Console.WriteLine(constExp.Type);
            Console.WriteLine(constExp.Value);
            //              expression : is somthing that reutrn in place of it self a value 
            /*
             * i > 5 we have 3 exp here i: it take a value and replace it self with it ,5 is a experssion 
             * it replace 5 with 5 ! , > is (operator) binary experssion it take two expression and return bool
             * in place of it self.
             */
            // then i , i is paramater is experssion that accept int 
            ParameterExpression iparam = Expression.Parameter(typeof(int), "i");
            Console.WriteLine(iparam.NodeType);
            Console.WriteLine(iparam.Type);
            Console.WriteLine(iparam.Name);

        }
    }
}
