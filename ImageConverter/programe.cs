using Microsoft.Office.Interop.Excel;
using System;
using System.Windows.Forms;

namespace ImageConverter
{
    public enum DisplayReportOptionType
    {
        AllServiceReportOnly = 5,
        GroupsReportsOnly = 6,
        Both = 7
    }
    public enum DisplayReportNameOptionType
    {
        ServiceClinicalGroupName = 3,
        CustomName = 4
    }
    public class programe
    {
        public static void Main()
        {
            convertToImage();
        }

        public static void convertToImage()
        {
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = null;
            wb = oExcel.Workbooks.Open("D:\\XSP\\" + "19-02-2022_Mahmoud Gamal.xls", false, false, Type.Missing, "", "", true, XlPlatform.xlWindows, "", false, false, 0, false, true, 0);
            Sheets sheets = wb.Worksheets as Sheets;

            // Get the first worksheet
            Worksheet sheet = sheets[0];

            System.Drawing.Image imgRange1 = Clipboard.GetImage();
            imgRange1.Save("D:\\XSP\\" + "aa"+ ".Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }

}


