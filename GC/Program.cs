using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using xps2img;

namespace GCC
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Threading.Timer t = new System.Threading.Timer(TimerCallback, null, 0, 2000);
            //Timer t = new Timer();
            //t.Elapsed += TimerCallback1;
            //t.Interval = 2000;
            //t.Start();
            // test re = new test();
            string xpspath = @"D:\XSP\12332311_1.xps";
            string imagepath = @"D:\XSP\IMage\12332311_1.jpg";
            string[] ssss = imagepath.Split('_');

            using (var xpsConverter = new Xps2Image(xpspath))
            {
                IEnumerable<Bitmap> images = xpsConverter.ToBitmap(new Parameters
                {
                    ImageType = ImageType.Png,
                    Dpi = 300,
                });
                foreach (var image in images)
                {
                    var height = image.Height;
                    var widt = image.Width;
                    image.Save(imagepath);
                }
                long accnumber = GetAcessionNumberFromOutFileName(imagepath);
            }
            Console.ReadKey();
        }

        private static long GetAcessionNumberFromOutFileName(string outPutFileAfterConversion)
        {
            string fileName = outPutFileAfterConversion.Split('_')[0];
            long AccNumber = long.Parse(Path.GetFileNameWithoutExtension(outPutFileAfterConversion));
            return AccNumber;
        }

    }

    class test
    {
        int x;
        public test()
        { x = 100; }
        static test()
        { }
        public static test Instance { get; } = new test();
        //char[] rrr = new char[2] { 'a', 's' };
        String zz = new String(new[] { 'x' });
        DateTime ttt = new DateTime();
        long xy = 111;
        static string ss = "ahmed";

        static string sss()
        {
            return "ahmed";
        }
        static int xx;
        test2 tt = new test2(ss);
    }

    class test2
    {
        string dd;
        public test2(string ss)
        {
            dd = ss;
        }
    }


}
