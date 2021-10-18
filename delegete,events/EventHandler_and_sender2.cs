using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{

    public enum CowStat
    {
        Awake,
        Sleep,
        Dead
    }
    class CowTippedEventArgs : EventArgs
    {
        public CowStat CurrentCowState { get; private set; }
        public CowTippedEventArgs(CowStat CuurentState)
        {
            CurrentCowState = CuurentState;
        }
    }
    class cow2
    {
        public EventHandler<CowTippedEventArgs> cow_event;
        public string Name { get; set; }
        public void callEvent()
        {
            if (cow_event != null)
            {
                //eventargs is usfull when we need extra information
                cow_event(this, new CowTippedEventArgs(CowStat.Awake)); //empty return empty EventArgs
            }
        }
    }
    class EventHandler_and_sender2
    {
        public static void run()
        {
            cow2 c1 = new cow2 { Name = "c1" };
            c1.cow_event += giggle;
            cow2 c2 = new cow2 { Name = "c2" };
            c2.cow_event += giggle;
            cow2 victim = new Random().Next() % 2 == 0 ? c1 : c2;
            victim.callEvent();

            //victim.cow_event(c2, EventArgs.Empty);//we can send any object we want ! 
            //we still can directly call the delegate but we need to send the args
        }
        static void giggle(object sender, CowTippedEventArgs args)
        {
            cow2 c = sender as cow2;
            Console.WriteLine($"cow {c.Name} giggglessss {args.CurrentCowState}");
        }
    }
}
