﻿using System;
using delegete_events_weather;
using delegete_events.Delegate_Event;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace delegete_events
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("--------------hellowrold----------------");
            //Helloworld.run();

            //Console.WriteLine("--------------target and method----------------");
            //Method_and_Target.run();

            //Console.WriteLine("--------------why delegete------------------");
            //why_delegate.run();

            //Console.WriteLine("------------------why delegete soultion-------------------");
            //why_delegate_Solution.run();

            //Console.WriteLine("------------------chaning delegete-------------------");
            //chaningDelegete.run();

            Console.WriteLine("---------------multicastdelegate vs delegate-------------");
            multicastdelegate_vs_delegate.run();

            Console.WriteLine("---------------MulticastingWithParameters-------------");
            MulticastingWithParameters.run();
            
            //Console.WriteLine("---------------generic delegate,func, action -------------");
            //generic_delegate_func_action.run();

            //Console.WriteLine("---------------delegate exceptions -------------");
            //delegetechainandexcptions.run();

            //Console.WriteLine("---------------lambda and anonymous function -------------");
            //lambda_and_anonymous.run();

            //Console.WriteLine("---------------closures-------------");
            //closures.run();

            //Console.WriteLine("---------------closures under the hood-------------");
            //howClosuerActullayWork.run();
            //howClosuerActullayWork2.run();


            //Console.WriteLine("---------------event vs delegate-------------");
            //delegateVsEvent.run();
            //delegateVsEvent2.run();

            //Console.WriteLine("---------------EventHandler-------------");
            //EventHandler_and_sender.run();
            // EventHandler_and_sender2.run();

            //Console.WriteLine("---------------student course observer-------------");
            //StudentCourse_observer.run();
            //Weather_News_observer.run();
            StudentCourse_observer2.run();

            //Console.WriteLine("---------------Viedo Encoder Event Delegate-------------");
            //VideoEncoder.run();

            //test t = new test();
            //t.mm += sub;
            //t.mm(1);

            List<int> ss = new List<int>()
            {
                1,2,3,4
            };
            int[] s = new int[] { 1, 2, 3 };

            var t = s.Select(x => x);
            foreach (var item in t)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

        }

        class test
        {
            public Action<int> mm;
            
          
        }
        static void sub(int x)
        {
            Console.WriteLine("ahmed");
        }


    }
}
