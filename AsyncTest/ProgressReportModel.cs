using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncTest
{
   public class ProgressReportModel
    {
        public int PercentageCompleted { get; set; } = 0;
        public WebSiteDTO SiteDownloaded { get; set; } = new WebSiteDTO();
    }
}
