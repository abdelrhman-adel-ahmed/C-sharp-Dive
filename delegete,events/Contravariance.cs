using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{

    class Base { }
    class Drived : Base { }


    class Contravariance
    {
        delegate void mydelegate(Base b);
        static void TakeDrive(Drived d) { }
        static void TakeBase(Base b) { }

        static void run()
        {
            mydelegate d1 = TakeDrive;
            d1(new Drived());
            d1(new Base());
            mydelegate d2 = TakeBase;
        }
    }
}
