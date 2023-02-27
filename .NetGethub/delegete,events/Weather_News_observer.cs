using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{

    interface IObserver
    {
        void Update(float temp);
    }
    interface ISubject
    {
        void Subscribe(IObserver o);
        void Notify();
    }

    class WeatherStation : ISubject
    {
        private List<IObserver> ObserverList;
        public float Temperature
        {
            get { return _Temperature; }
            set
            {
                if (this is WeatherStation)
                {
                    _Temperature = value;
                    //when the temp change we will notify the observers
                    Notify();
                }
            }
        }
        private float _Temperature;
        public WeatherStation()
        {
            ObserverList = new List<IObserver>();
        }
        public void Notify()
        {
            ObserverList.ForEach(o =>
            {
                o.Update(_Temperature);
            });
        }

        public void Subscribe(IObserver o)
        {
            ObserverList.Add(o);
        }
    }


    class NewsAgency : IObserver
    {
        public string AgencyName { get; set; }
        public NewsAgency(string name)
        {
            AgencyName = name;
        }
        public void Update(float temp)
        {
            Console.WriteLine("news agency " + AgencyName + "reporting " + temp + " degree");
        }
    }
    class Weather_News_observer
    {

        public static void run()
        {
            WeatherStation w = new WeatherStation();

            NewsAgency n1 = new NewsAgency("bbc");
            NewsAgency n2 = new NewsAgency("nbc");
            NewsAgency n3 = new NewsAgency("abc");

            w.Subscribe(n1);
            w.Subscribe(n2);
            w.Subscribe(n3);
            w.Temperature = 32;

        }
    }
}
