using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{

    class TrainSignal
    {
        public Action TarinsComing;
        public void HereComesATrain()
        {
            //there is logic here 
     
            TarinsComing();
      
       
            Console.WriteLine(TarinsComing.Target);
        }
    }   
    class Car
    {
        public Car(TrainSignal trainsingnal)
        {
            //note here we add our private method to the action and this is legit !
            //add me on to the list of subscriberssss 
            trainsingnal.TarinsComing += StopTheCar;

        }
        void StopTheCar()
        {
            Console.WriteLine("stooooooooooooop");
        }
    }

    class delegateVsEvent
    {
        public static void run()
        {
            TrainSignal t = new TrainSignal();
            Car c = new Car(t);
            Car c1 = new Car(t);
            Car c2 = new Car(t);
            t.HereComesATrain(); //invoke the functions ,that we have

            //problem with using row delegate as signals
            t.TarinsComing(); //invoke the delegete directly
            t.TarinsComing = null; //remove all the subscibers hehehe(delegate direct maniplulation)

            //event solve those problems

        }
    }
}
