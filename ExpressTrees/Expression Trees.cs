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
            Expression<Func<int,bool> > test= i => i > 5;

        }
    }
}
