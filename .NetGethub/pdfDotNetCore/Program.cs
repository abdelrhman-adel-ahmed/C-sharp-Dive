using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;

namespace pdfDotNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> paths = new List<string>
            {
                @"C:\Users\abdelrahman.adel\Desktop\90288905_361_842_3_9000002286048_020921134421_Urine CS.pdf",
                @"C:\Users\abdelrahman.adel\Desktop\73727_362_0_0_1872427_280921181918_FBS-_new_Test2.pdf",
                @"C:\Users\abdelrahman.adel\Desktop\90284327_361_925_3_9000002281470_050921154941_Blood Culture One Sample.pdf"
            };
            List<byte[]> pdfsAsBytes = new List<byte[]>();
            foreach (string path in paths)
            {
                pdfsAsBytes.Add(File.ReadAllBytes(path));
            }

            Merg(MergePDSharper, pdfsAsBytes, "pdfsharper","sharper.pdf");
            Merg(MergePDFsItextSharp, pdfsAsBytes, "ITextSharp","itext.pdf");

            Console.ReadKey();
        }

        public static void Merg(Func<List<byte[]>, byte[]> mergFunc, List<byte[]> pdfsAsBytes, string MergLib,string outFileName)
        {
            var watch = Stopwatch.StartNew();
            byte[] mergedPdfs = mergFunc(pdfsAsBytes);
            watch.Stop();
            Console.WriteLine($"Time Taken By {MergLib} dontNet = {watch.ElapsedMilliseconds} in Milliseconds");
            Console.WriteLine($"Time Taken By {MergLib} dontNet = {watch.ElapsedTicks} in ticks");
            File.WriteAllBytes(@$"C:\Users\abdelrahman.adel\Desktop\{outFileName}", mergedPdfs);

        }
        public static byte[] MergePDSharper(List<byte[]> pdfs)
        {
            List<PdfSharpCore.Pdf.PdfDocument> lstDocuments = new List<PdfSharpCore.Pdf.PdfDocument>();
            foreach (byte[] pdf in pdfs)
            {
                lstDocuments.Add(PdfSharpCore.Pdf.IO.PdfReader.Open(new MemoryStream(pdf), PdfDocumentOpenMode.Import));
            }

            using (PdfSharpCore.Pdf.PdfDocument outPdf = new PdfSharpCore.Pdf.PdfDocument())
            {
                for (int i = 1; i <= lstDocuments.Count; i++)
                {
                    foreach (PdfSharpCore.Pdf.PdfPage page in lstDocuments[i - 1].Pages)
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


        public static byte[] MergePDFsItextSharp(List<byte[]> pdfFiles)
        {
            if (pdfFiles.Count > 1)
            {
                iTextSharp.text.pdf.PdfReader finalPdf;
                Document pdfContainer;
                PdfWriter pdfCopy;
                MemoryStream msFinalPdf = new MemoryStream();

                finalPdf = new iTextSharp.text.pdf.PdfReader(pdfFiles[0]);
                pdfContainer = new Document();
                pdfCopy = new PdfSmartCopy(pdfContainer, msFinalPdf);

                pdfContainer.Open();

                for (int k = 0; k < pdfFiles.Count; k++)
                {
                    finalPdf = new iTextSharp.text.pdf.PdfReader(pdfFiles[k]);
                    for (int i = 1; i < finalPdf.NumberOfPages + 1; i++)
                    {
                        ((PdfSmartCopy)pdfCopy).AddPage(pdfCopy.GetImportedPage(finalPdf, i));
                    }
                    pdfCopy.FreeReader(finalPdf);

                }
                finalPdf.Close();
                pdfCopy.Close();
                pdfContainer.Close();

                return msFinalPdf.ToArray();
            }
            else if (pdfFiles.Count == 1)
            {
                return pdfFiles[0];
            }
            return null;
        }
    }
}
