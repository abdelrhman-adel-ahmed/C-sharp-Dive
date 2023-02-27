using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    class cow
    {
        public EventHandler cow_event;
        public string Name { get; set; }
        public void callEvent()
        {
            if (cow_event != null)
            {
                cow_event(this,EventArgs.Empty); //empty return empty EventArgs
            }
        }
    }
    class EventHandler_and_sender
    {

        public static void run()
        {
            cow c1 = new cow { Name = "c1" };
            c1.cow_event += giggle;
            cow c2 = new cow { Name = "c2" };
            c2.cow_event += giggle;
            cow victim = new Random().Next() % 2 == 0 ? c1 : c2;
            victim.callEvent();

            //victim.cow_event(c2, EventArgs.Empty);//we can send any object we want ! 
            //we still can directly call the delegate but we need to send the args
        }
       static void giggle(object sender,EventArgs args)
        {
            cow c = sender as cow;
            Console.WriteLine($"cow {c.Name} giggglessss");
        }
    }
}
