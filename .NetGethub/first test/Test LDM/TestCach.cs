using System;
using System.Collections.Generic;
using System.Text;

namespace first_test.Test_LDM
{
    class TestCach
    {
        static int? prop1=null;
        static public int MyProperty1
        {
            get
            {
                if (prop1 == null)
                {
                    prop1 = 1;
                    return 1;
                }
                else
                    return 2;

            }
            set
            {

            }
        }
        static public string MyProperty2 { get; set; }
        static public int MyProperty3 { get; set; }
        static public bool MyProperty4 { get; set; }

    }
}
