using System;
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
            ConstantExpression constExp = Expression.Constant(5, typeof(int));
            Console.WriteLine(constExp.NodeType);
            Console.WriteLine(constExp.Type);

        }
    }
}
