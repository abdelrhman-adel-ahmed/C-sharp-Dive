using chapter5_primitives_refrence_and_value_types_.ChangeField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter5_primitives_refrence_and_value_types_
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine("ValueTypes");
           // ValueTypes.Run();

            Console.WriteLine("Change Field in boxed value type doesnt reflect in the original value");
            ChangeFieldInBoxedTypes.Run();
        }

    }
}
