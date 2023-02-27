using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{

    class Base { }
    class Drived : Base { }

    class Animal { }
    class Giraffes : Animal { }
    class Turtle : Animal { }

    class Contravariance
    {
        delegate void mydelegate(Base b);
        delegate void mydelegate1(Drived b);
        static void TakeDrive(Drived d) { }
        static void TakeBase(Base b) { }

        public static void Run2() {
            
            Animal[] animals = new Giraffes[10]; 
            animals[0] = new Giraffes();
            animals[1] = new Turtle();
            // array covarivance is not a good feature because we can do this,and we cannot capture this error 
            //untill run time.
        }
        public static void Run1()
        {
           mydelegate1 d1 = TakeDrive;
           d1(new Drived());
           mydelegate d2 = TakeBase;
           d2(new Drived());
           d2(new Base());
           ICovariant<Base> covariant = (ICovariant<Drived>) null;
            IContraVariant<Drived> contraVariant = (IContraVariant<Base>)null;

        }
    }
    interface ICovariant<out T>
    {
        T Name { get; }
        T Get();
    }
    interface IContraVariant<in T>
    {
        T Name { set; }
        void Set(T t);
    }
}
