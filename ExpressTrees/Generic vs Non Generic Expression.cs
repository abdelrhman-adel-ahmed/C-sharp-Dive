using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressTrees
{
    class Generic_vs_Non_Generic_Expression
    {
        public static void run()
        {
            //non generic Expression have the factory methods that return expression objects
            //generic Expression

            Expression<Func<int,bool>> ex = i=>i > 5;
            ConstantExpression conExp= Expression.Constant(5, typeof(int));
        }
    }
}
