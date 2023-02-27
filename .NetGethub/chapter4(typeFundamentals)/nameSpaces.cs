using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nameSpaces;
using Text1 = nameSpaces1.Text;


namespace chapter4_typeFundamentals_
{ 
    class nameSpaces
    {
        public static void Run()
        {
            Text t = new Text();
            Text1 t1 = new Text1();
        }
    }
}

namespace nameSpaces
{
    class Text
    {

    }
}

namespace nameSpaces1
{
    class Text
    {

    }
}
