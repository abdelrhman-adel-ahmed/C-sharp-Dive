using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Text;
using System.Threading.Tasks;

namespace ExpressTrees
{
    public class Expression_Trees
    {
        delegate bool rr(int i);

        public static void run()
        {
            /*expression object cannot refer directly to methods and it not convert the lambda to method !!
             * it convert it to punsh of objects
             * static bool ssdasdas(int i)
            {
            return i>5;
            }
            Expression<Func<int, bool>> test = ssdasdas;

            */

    
            
         

            Expression<Func<int,bool> > exp= i => i > 5;


            //----------------what compiler generates for experession----------------------
            ParameterExpression left = Expression.Parameter(typeof(int), "i");
            ParameterExpression[] parameters = new ParameterExpression[] { left };
            Expression<Func<int, bool>> expression =
                //first we want to make lambda expression , first arg is the body of type expression
                //which take the first arg (node type)wich is graterthan func that take two args left and right
                //,second args is the parameters[] which we send to the lambda here its the i 
              Expression.Lambda<Func<int, bool>>
                      (Expression.GreaterThan
                                  (left, Expression.Constant
                                              (5, typeof(int))), parameters);

            //-------------------------------------------------
            Console.WriteLine(exp.Body);
            Console.WriteLine(exp.Body.GetType());
            Console.WriteLine(exp.Body.GetType().GetType());
            //logical binary expression inherte from binary expression
            BinaryExpression bin = (BinaryExpression) exp.Body;
            Console.WriteLine(bin.Left);
            Console.WriteLine(bin.NodeType);

            Console.WriteLine(bin.Right);




        }
    }
}
