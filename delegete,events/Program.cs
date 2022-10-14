using System;
using delegete_events_weather;
using delegete_events.Delegate_Event;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace delegete_events
{
   
    class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine("--------------hellowrold----------------");
             Helloworld.run();
            
             Console.WriteLine("--------------target and method----------------");
             Method_and_Target.run();
            
             Console.WriteLine("--------------why delegete------------------");
             why_delegate.run();
            
             Console.WriteLine("------------------why delegete soultion-------------------");
             why_delegate_Solution.run();
            
             Console.WriteLine("------------------chaning delegete-------------------");
             chaningDelegete.run();
            
             Console.WriteLine("---------------multicastdelegate vs delegate-------------");
             multicastdelegate_vs_delegate.run();
             
             Console.WriteLine("---------------MulticastingWithParameters-------------");
             MulticastingWithParameters.run();
            
             Console.WriteLine("---------------generic delegate,func, action -------------");
             generic_delegate_func_action.run();
            
             Console.WriteLine("---------------delegate exceptions -------------");
             delegetechainandexcptions.run();

            Console.WriteLine("---------------lambda and anonymous function -------------");
            lambda_and_anonymous.run();

            Console.WriteLine("---------------closures-------------");
            closures.run();

            Console.WriteLine("---------------closures under the hood-------------");
            howClosuerActullayWork.run();
            howClosuerActullayWork2.run();


            Console.WriteLine("---------------event vs delegate-------------");
            delegateVsEvent.run();
            delegateVsEvent2.run();

            Console.WriteLine("---------------EventHandler-------------");
            EventHandler_and_sender.run();
             EventHandler_and_sender2.run();

            Console.WriteLine("---------------student course observer-------------");
            StudentCourse_observer.run();
            Weather_News_observer.run();
            StudentCourse_observer2.run();

            Console.WriteLine("---------------Viedo Encoder Event Delegate-------------");
            VideoEncoder.run();

            Console.WriteLine("---------------Covariance And Contravariance-------------");
            Contravariance.Run1();
            Contravariance h = new Contravariance();
            
            Contravariance.Run2();

            //test t = new test();
            //t.mm += sub;
            //t.mm(1);

            // test t = null;
            //
            // string yy = "ahmed" + t?.x;
            // Console.WriteLine(yy);

            // var container = new SomeContainer();
            //
            // var range = Enumerable.Range(0, 10);
            //
            // foreach (var item in range)
            //     container.SomeNumbers.GetType().GetProperty("SomeNumbers").GetGetMethod().Invoke(container,null);
            // Console.WriteLine(container.SomeNumbers.Count);
            Console.ReadKey();


        }

        public class SomeContainer

        {

            public List<int> SomeNumbers => new List<int>();

        }
        private static string ConvertToBase64(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            string binary = sb.ToString();
            return binary;
        }
        class test
        {
            public string x = null;
          
        }
    }
}
