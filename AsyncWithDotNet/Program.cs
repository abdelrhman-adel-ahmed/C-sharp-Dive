using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWithDotNet
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var ints = new List<int> { 1, 2, 3, 4, 5 };
            var values =  await GetInts(ints);
            //foreach (var item in values)
            //{
            //    Console.WriteLine(item);
            //}
            Console.ReadKey();
        }

        static Task<int> ReturnIntTask(int userId)
        {
            return Task.Run(() => userId * 2);
        }
        static  Task<int[]> GetInts(IEnumerable<int> ints)
        {
           var getUserInts = new List<Task<int>>();
           foreach (var item in ints)
           {
               getUserInts.Add(ReturnIntTask(item));
           }
           return Task.WhenAll(getUserInts);
        }
        public static byte[] MergePdf(List<byte[]> pdfs)
        {
            List<PdfSharp.Pdf.PdfDocument> lstDocuments = new List<PdfSharp.Pdf.PdfDocument>();
            foreach (byte[] pdf in pdfs)
            {
                lstDocuments.Add(PdfReader.Open(new MemoryStream(pdf), PdfDocumentOpenMode.Import));
            }

            using (PdfSharp.Pdf.PdfDocument outPdf = new PdfSharp.Pdf.PdfDocument())
            {
                for (int i = 1; i <= lstDocuments.Count; i++)
                {
                    foreach (PdfSharp.Pdf.PdfPage page in lstDocuments[i - 1].Pages)
                    {
                        outPdf.AddPage(page);
                    }
                }

                MemoryStream stream = new MemoryStream();
                outPdf.Save(stream, false);
                byte[] bytes = stream.ToArray();

                return bytes;
            }
        }
    }
}
