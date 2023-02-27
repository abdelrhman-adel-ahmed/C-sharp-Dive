using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Assembly.Load("");
            //Assembly.LoadFile();
            //Assembly asss = Assembly.LoadFrom("D:\\Personal\\Slave1.dll");
            ////Assembly assss = Assembly.LoadFrom("D:\\Personal\\Slave2.dll");
            //Type tt = asss.GetTypes()[0];
            //object slave1 = Activator.CreateInstance(tt, null);

            //MethodInfo jj = slave1.GetType().GetRuntimeMethods().First();
            //object obj = Activator.CreateInstance(tt);
            //jj.Invoke(obj, null);
            ////slave11?.Slave1Fun();
            Details dd = new Details { MyProperty1 = 1, MyProperty2 = 2, MyProperty3 = 3 };
            Dynamic ddd = new Dynamic() {data=new ExpandoObject ()};
            dynamic data = new ExpandoObject();
            Dictionary<string, string> dss = new Dictionary<string, string>();
            dss.Add("aa", "vv");
            var xx = JsonConvert.SerializeObject(new Zrboo() { Details = dd,data= dss });
            Console.WriteLine(JsonConvert.SerializeObject(dd));
            Console.ReadKey();
        }
        
    }
    class Zrboo
    {
        public Details Details { get; set; }
        public Dictionary<string,string> data { get; set; }
    }
    class Details
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
        public int MyProperty3 { get; set; }

    }
    class Dynamic
    {
        public dynamic data { get; set; }
    }
}
