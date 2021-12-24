using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Patterns.MVC;
using Design_Patterns.repository;

namespace Design_Patterns
{


    class test
    {
        public static void convertToPDF()
        {
            string xpsPath = "D:\\convertXpsToPdf\\xps\\example.xps";
            string pdfPath = "D:\\convertXpsToPdf\\pdf\\output.pdf";
            using (PdfSharp.Xps.XpsModel.XpsDocument pdfXpsDoc = PdfSharp.Xps.XpsModel.XpsDocument.Open(xpsPath))
            {
               PdfSharp.Xps.XpsConverter.Convert(pdfXpsDoc, pdfPath, 0);
            }
        }
    }
    class Program
    {


        static void Main(string[] args)
        {
            // test.convertToPDF();
            string name = "321321.aspx";
            int num = int.Parse(name.Split('.')[0]);
            //Console.WriteLine("---------MVC--------");
            //EntryPoint.Start();
            //Console.WriteLine("---------Dependency Inversion--------");
            //Entrypoint1.run();



            //Console.WriteLine("---------Repository--------");
            //Start.run();

            //Console.WriteLine("---------Mimic Webresult--------");
            //StartUp.run();

           //Console.WriteLine("---------MiddleWare--------");
           ////test1.run();
           ////test2.run();
           //test3.run();
           ////Soultion1.run();
           //FinalSolution.FinalSolution.run();

            Console.ReadKey();
        }
    }
}
