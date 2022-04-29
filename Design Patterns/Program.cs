using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    public enum DisplayReportOption
    {
        AllServiceReportOnly = 5,
        GroupsReportsOnly = 6,
        Both = 7
    }
    public enum ReportStatus
    {
        None = 0,
        NotReviwed = 1,
        Reviewed = 2
    }
     public enum UploadStorageType
    {
        GoogleDrive = 1,
        AzureFileStorage = 2,
        AzureBlobStorage = 3
    }
    public class ReportDTO
    {
        public UploadStorageType StorageTypeId { get; set; }
        public string AzureFilePath { get; set; }
        public string ContainerName { get; set; }
        public long? DriveAccountID { get; set; }
        public long AccessionId { get; set; }
        public float? SizeInKB { get; set; }
        public string GoogleFileId { get; set; }
        public string OracleId { get; set; }
        public bool Report_clicked { get; set; }
        public string DownloadLink { get; set; }
        public string GoogleDriveUrl { get; set; }
        public DateTime? ResultDate { get; set; }
        public DateTime VisitDate { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public ReportStatus Report_status { get; set; }
        public long Id { get; set; }
        public string AzureAccessToken { get; set; }
        public DisplayReportOption? DisplayReportOption { get; set; }
    }
    public class AccessionResultDTO
    {
        public long AccNumber { get; set; }
        public DateTime VisitDate { get; set; }
        public string PatientName { get; set; }
        public string PatientNumber { get; set; }
        public string ClinicRefNo { get; set; }
        public DateTime? ResultDate { get; set; }
        public long Id { get; set; }
        public bool IsAccesstionContainReviewedResult { get; set; }
        public bool IsAnyReportNotClicked { get; set; }
        public DisplayReportOption? DisplayReportOption { get; set; }
        public List<ReportDTO> ReportDTOList { get; set; }
    }
    public class SearchModelDTO
    {
        public int TotalRecord { get; set; }
        public string GeneralName { get; set; }
        public List<AccessionResultDTO> AccessionResultDTOList { get; set; }
    }
    class Program
    {

        static void AddReportsToAccession(SearchModelDTO searchModelDTO)
        {
            if (searchModelDTO != null && searchModelDTO.AccessionResultDTOList != null && searchModelDTO.AccessionResultDTOList.Count > 0)
            {
                List<ReportDTO> reportDTOList = new List<ReportDTO>
                    {
                        new ReportDTO{AccessionId=100},
                    };
                searchModelDTO.AccessionResultDTOList.ForEach(c => c.ReportDTOList = reportDTOList.Where(x => x.AccessionId == c.Id)?.ToList());
                searchModelDTO.AccessionResultDTOList.ForEach(c => c.IsAccesstionContainReviewedResult = reportDTOList.Any(x => x.AccessionId == c.Id && !string.IsNullOrEmpty(x.GoogleDriveUrl)));
                searchModelDTO.AccessionResultDTOList.ForEach(c => c.IsAnyReportNotClicked = reportDTOList.Any(x => x.AccessionId == c.Id && !x.Report_clicked));
            }
        }
        static void Main(string[] args)
        {
            // SearchModelDTO searchModelDTO = new SearchModelDTO
            // {
            //     AccessionResultDTOList = new List<AccessionResultDTO>
            //     {
            //         new AccessionResultDTO { AccNumber = 100 }
            //     },
            //     TotalRecord = 10,
            // };
            // AddReportsToAccession(searchModelDTO);
           //DateTime dateTime;
           //string dateInStringFormat = "1/1/1980 12:00:00 AM";
           //string formatType = "Long";
           //if(!DateTime.TryParseExact(dateInStringFormat,
           //                                GetDateFormate(), new CultureInfo("en-US"),
           //                                DateTimeStyles.None, out dateTime))
           //{
           //
           //}
           //int xx = 86399;
           //DateTime ss = new DateTime(Convert.ToDateTime("4/19/2022 1:33:41 AM"));
            //var xxx = new Uri("https://kauws.kau.edu.sa/KAU_WS_WEBAPI/api/Labs/UpdateResults");
            //Console.WriteLine("builder design pattern ");
            //Builder.Run();
            string x = "username = test & loginType = 2 & IsWebForm = True";
            Console.WriteLine(x);
            string[] qq = x.Split('&');

            Console.WriteLine(qq);
            Console.ReadKey();
        }
        private static string GetDateFormate()
        {
            //yyyy-MM-dd"
            return "d/M/yyyy h:mm:ss tt";
        }
    }
}
