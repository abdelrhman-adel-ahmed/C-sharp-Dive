using Aspose.Cells.Rendering;
using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Drawing.Imaging;

namespace ExcelToImage
{
    class Program
    {
        static void Main(string[] args)
        {
            // FirstMethod();
            //SecondMethod();
            ThirdMethod();
        }
        private static void ThirdMethod()
        {
            string fileNameToProcess = @"D:\XSP\file_example_XLS_10.xls";
            //Start Excel and create a new document.
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            try
            {
                wb = oExcel.Workbooks.Open(fileNameToProcess.ToString(), false, false, Type.Missing, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", false, false, 0, false, true, 0);
                //wb.RefreshAll();
                Microsoft.Office.Interop.Excel.Sheets sheets = wb.Worksheets as Microsoft.Office.Interop.Excel.Sheets;
                for (int i = 1; i <= sheets.Count; i++)
                {
                    Microsoft.Office.Interop.Excel.Worksheet sheet = sheets[i];
                    //Following is used to find range with data
                    string startRange = "A1";
                    Microsoft.Office.Interop.Excel.Range endRange = sheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                    Microsoft.Office.Interop.Excel.Range range = sheet.get_Range(startRange, endRange);
                    range.Rows.AutoFit();
                    range.Columns.AutoFit();
                    range.Copy();
                    //Image imgRange1 = Clipboard.GetImage();
                    //imgRange1.Save(@"C:\Users\infoobjects\Desktop\" + "Test1" + i + ".Jpeg", ImageFormat.Jpeg);
                    //Console.Write("Specified range converted to image successfully. Press Enter to continue.");
                    //sheets[i].Delete();
                }
                wb.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            finally
            {
                wb.Close();
                oExcel.Quit();
                oExcel = null;
            }

            Console.ReadLine();
        }

        private static void SecondMethod()
        {
            Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();

            if (xl == null)
            {
                return;
            }
            var xx = AppDomain.CurrentDomain.BaseDirectory;
            Microsoft.Office.Interop.Excel.Workbook wb = xl.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + "11-6-2022 pra_Faten Khalf.xls");
            Microsoft.Office.Interop.Excel.Range r = wb.ActiveSheet.Range["A1:C5"];
            r.CopyPicture(Microsoft.Office.Interop.Excel.XlPictureAppearance.xlScreen,
                           Microsoft.Office.Interop.Excel.XlCopyPictureFormat.xlBitmap);

            //IDataObject data = Clipboard.GetDataObject();
            //if (data.GetDataPresent(DataFormats.Bitmap))
            //{
            //    Image image = (Image)data.GetData(DataFormats.Bitmap, true);
            //    image.Save(AppDomain.CurrentDomain.BaseDirectory + @"sample.jpg",
            //        System.Drawing.Imaging.ImageFormat.Jpeg);
            //}

        }

        private static void FirstMethod()
        {
            string sourceDir = @"D:\XSP\file_example_XLS_10.xls";
            //Output directory
            string outputDir = "D:\\XSP\\Success";

            Aspose.Cells.Workbook book = new Aspose.Cells.Workbook(sourceDir);

            Aspose.Cells.Worksheet sheet = book.Worksheets[0];

            Aspose.Cells.Rendering.ImageOrPrintOptions options = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;
            options.ImageType = Aspose.Cells.Drawing.ImageType.Jpeg;

            // Sheet2Image By Page conversion
            SheetRender sr = new SheetRender(sheet, options);
            for (int j = 0; j < sr.PageCount; j++)
            {
                sr.ToImage(j, outputDir + "test_" + (j + 1) + ".jpg");
            }
        }
    }
}
