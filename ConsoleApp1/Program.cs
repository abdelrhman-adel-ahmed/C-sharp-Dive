using NT.Integration.SharedKernel.OracleManagedHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Program
    {
        class t1
        {
            public string x = "t1 x";
            public t2 t = new t2();
        }
        class t2
        {
            public string y ="t2 y";
            public string z = "t2 z";
            public int x = 100;
        }

        static void dss(ref List<string> hh)
        {
            hh = null;
        }
        static async Task Main(string[] args)
        {
            //string url = "rn = AlBorg_ResultSubServices & UserName = System & RegistrationClinicServiceId = 18421191 & ReportName = Complete Blood Picture(CBC)&BranchName = Auditing.& BranchId = 1132 & UserTimeZoneId = Egypt Standard Time&Hijri = 0 & OffsetTime = 2 & IsWebResult = 1 & IsAmended = False & un = System & ip = &rcopy = false & IsFromResult = &RegistrationId = 4324572 & ClinicalGroupId = 1";
            //var x = url.Split('&');
            //Console.WriteLine(x);
            //List<string[]> y = x.Select(part => part.Split('=')).ToList(); //each string will get split so we have string arr for each part
            //Console.WriteLine(y);
            //var z = y.Where(part => part.Length == 2);//that mean we have key without a value , beacause each part of the qurey string
            //                                          //"key=value" so when we split it it will contain arr string that its length is 2
            //Console.WriteLine(z);
            //var n = z.ToDictionary(sp => sp[0], sp => sp[1]);
            //Console.WriteLine(n);
            //Action funcc = test.outerFunc();
            //funcc();
            List<string> hh = new List<string> { "123", "1231" };
            t1 tt = new t1();
            t1 ttt = tt;
            tt.t.y = "zrboo";
            tt.t.x = 200;
            Console.WriteLine(ttt.t.y);
            Console.WriteLine(ttt.t.x);

        }
        static async Task zz()
        {
            await ss();
        }
        static async Task ss()
        {
            HttpClient client = new HttpClient();
            var respponse = await client.GetAsync("https://www.google.com");
            string response = await respponse.Content.ReadAsStringAsync();
            Console.WriteLine(response);
        }

    }

    class test
    {
        public static Action outerFunc()
        {
            string message = "ahmed";
            void innerFunc()
            {
                Console.WriteLine(message);
            }
            return innerFunc;
        }
    }


}
