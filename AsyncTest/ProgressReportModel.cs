using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncTest
{
    class ProgressReportModel
    {
        public int PercentageCompleted { get; set; } = 0;
        public List<WebSiteDTO> SiteDownloaded { get; set; } = new List<WebSiteDTO>();
    }
}
