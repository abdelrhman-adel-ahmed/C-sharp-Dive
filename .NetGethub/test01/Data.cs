using Fingers10.ExcelExport.Attributes;

namespace ExecelTest
{
    public class Data
    {
        [IncludeInReport(Order =1)]
        public string LowNum { get; set; }
        [IncludeInReport(Order = 2)]
        public string LowTitle { get; set; }
        [IncludeInReport(Order = 3)]
        public string LowComment { get; set; }
        [IncludeInReport(Order = 4)]
        public string Notes { get; set; }
        [IncludeInReport(Order = 5)]
        public string Decision { get; set; }
    }
}