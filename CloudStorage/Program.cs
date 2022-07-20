using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStorage
{
    class Program0
    {
        static void Main(string[] args)
        {
            MainDSL.FileUpload();
            //Response<string> response =  zrboo("ahmed", Token());
            //while (true)
            //{
            //    appsettings.zrb = ConfigurationManager.AppSettings["zrbo"];
            //    Console.WriteLine(appsettings.zrb);
            //}
        }

        static string Token()
        {
            return "123";
        }

        static Response<T> zrboo<T>(T url, string token)
        {
            Console.WriteLine(token);
            return new Response<T> { message = url };
        }
    }
    class Response<T>
    {
        public T message { get; set; }
    }
    class appsettings
    {
        public static string zrb
        {
            get
            {
                return zrb;
            }
            set
            {
                zrb = value;
                return;
            }
        }
    }
}
