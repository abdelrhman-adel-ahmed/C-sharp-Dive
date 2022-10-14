using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management.Instrumentation;
using System.Net.Http;

namespace _.net_assemblies
{
    class Base
    {
        public void Print()
        {
            Console.WriteLine("Base");
        }
    }
    class Drived1 : Base
    {
        public void Drived1P()
        {
            Console.WriteLine("Drived1");
        }
    }
    class Drived2 : Base
    {
        public void Print()
        {
            Console.WriteLine("Base");
        }
        public void Drived2P()
        {
            Console.WriteLine("Drived2");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            DateTime dateTime = DateTime.Now;
            string url = $"https://localhost:44316/weatherforecast?time={DateTime.Now}";
            HttpResponseMessage xx = client.GetAsync(url).GetAwaiter().GetResult();
            string xxx = xx.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Drived1 drived1 = new Drived1();
            Drived2 drived2 = new Drived2();
            Base bb = drived1;
            bb.Print();
            drived1 = (Drived1)bb;
            drived1.Drived1P();

            // var frameworkPath = RuntimeEnvironment.GetRuntimeDirectory();
            //
            // var cscPath = Path.Combine(frameworkPath, "csc.exe");
            // Console.WriteLine(frameworkPath);  // C:\Windows\Microsoft.NET\Framework\v4.0.30319
            // Console.WriteLine(cscPath);
            // Console.ReadLine();

            //string BackupRetention = "1";
            //int x = Convert.ToInt32((string.IsNullOrEmpty(BackupRetention) ? "0" : BackupRetention));
            //Console.WriteLine(x);
            // Branch bb = new Branch() { Name = "zrbo", Password = "elno", OracleId = 0 };
            // long OracleId = bb.OracleId.GetValueOrDefault();
            Console.ReadLine();

        }



    }

    public class Branch
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public long? OracleId { get; set; }
    }
}
