using System;
using System.IO;
using System.Web;

namespace QrImageGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //string url = "http://10.25.0.11:5050/api/ApiBarcode/Generate?barcodeData=AR%20JBbmVpcyBBbCBLaGFpciBMQUICATUDEDIwMjEtMTItMDUgMDM6MjcEAjg0BQE0";
            ////translate url special character to respective charachters e.x %20 --> space 
            //string zrbo = HttpUtility.UrlDecode(url);
            //Console.WriteLine(url);
            //Console.WriteLine(zrbo);
            //Console.WriteLine(QrGenerator.Generate(url, false));
            hamada.Instance.test1();
            hamada1.Instance.test2();

            Console.ReadKey() ;
        }
    }


    class hamada
    {
        public static hamada Instance { get; } = new hamada(); 
        public static readonly string x = "sdsa";
        public readonly static string DBPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"UploaderDB.db");  
        
        public void test1()
        {
            Console.WriteLine("hamada1");
        }
    }

    class hamada1
    {
        public static hamada1 Instance { get; } = new hamada1();
        public static readonly string x = "aaaaa";
        public readonly static string DBPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dsdsa");

        public void test2()
        {
            Console.WriteLine("hamada2");
        }
    }
}
