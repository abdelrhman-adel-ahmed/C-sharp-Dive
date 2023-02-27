using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    class delegateVsEvent2
    {

        class TrainSignal
        {
            private Action traingcoming;
            public event Action Traincoming
            {
                //if we dont add the add,remove we can use the event direclty without needed to use 
                //another action delegate
                add {
                    traingcoming += value; //value is the function delegte that get passed when we add event
                    Console.WriteLine("adding");
                }
                remove {
                    traingcoming -= value;
                    Console.WriteLine("removing");
                }
            }
            public void HereComesATrain()
            {
                //there is logic here 

                //Traincoming(); note:we cannot invoke the evene directly here because if just code ,when we 
                //add the add and remove ,but we will use the private delegate we create
                traingcoming();
               

                Console.WriteLine(traingcoming.Target);
            }
        }
        class Car
        {
            public Car(TrainSignal trainsingnal)
            {
                //note here we add our private method to the action and this is legit !
                //add me on to the list of subscriberssss 
                trainsingnal.Traincoming += StopTheCar;

            }
            public void StopTheCar()
            {
                Console.WriteLine("stooooooooooooop");
            }
        }

        public static void run()
        {
            TrainSignal t = new TrainSignal();
            Car c = new Car(t);
            Car c1 = new Car(t);
            Car c2 = new Car(t);
            t.HereComesATrain(); //invoke the functions ,that we have
            t.Traincoming -= c.StopTheCar;
            t.HereComesATrain();
            //event prevent to call delegate directly or assign to it directly ,but you can use += ,-=
            //t.TarinsComing(); 
            //t.TarinsComing = null; 

            //how the compiler do that (see the notes)

            //we can add and remove using the method add,remove that event provide





        }
    }
}
