using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecelTest
{
    public class Program
    {
        public static string filepath = @"./test.xlsx";
        static void Main(string[] args)
        {
            /*
             cells : 
             A: o رقم المادة
             B: o عنوان المادة التنظيمية
             C: o الإجراء المتخذ
             D: التعليق
             E:o الملاحظات
             */

            Data data = new Data { LowNum = "1", LowTitle = "الماده رقم 1", Decision = "موافق", LowComment = "موافق", Notes = "لا يوجد ملاحظات" };
            Data data2 = new Data { LowNum = "2", LowTitle = "الماده رقم 2", Decision = "مش موافق", LowComment = "بس يابابا", Notes = "لا يوجد ملاحظات" };
            List<Data> dataList = new List<Data> { data, data2 };

            //FirstAttemp
            ThirdAttemp_new_algo.CreateExcelFile(filepath, "قرار 1");
            while (true)
            {
                try
                {
                    ThirdAttemp_new_algo.InsertDataList(dataList);
                }
                catch (Exception ex) { }
            }

        }

    }
}
