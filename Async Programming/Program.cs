using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Async_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            string xx = "{'patient_name': 'John','patient_id':'10005','patient_no':'10000','test_name':'covid','emirate': '1010','collection_date':'22-08-2022','short_url':'link/net.lc'}";
            string yy = xx.Replace('\'', '\"');
            //
    //       WhatsAppDataDTO whatsAppData = new WhatsAppDataDTO()
    //        {
    //            IsTemplate = "true",
    //            MobileNumber = "01112586691",
    //            TemplateCode = "1011",
    //            Data = new Dictionary<string, string>()
    //            {
    //}
    //        };
        }
        private static string QueryString(Dictionary<string, string> queryString)
        {
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            foreach (var item in queryString)
            {
                query.Add(item.Key, item.Value);
            }
            return '?' + query.ToString();
        }
    }

    public class WhatsAppDataDTO
    {
        [JsonIgnore]
        public int SendId { get; set; }

        [JsonProperty("phone_number")]
        public string? MobileNumber { get; set; }

        [JsonProperty("is_template")]
        public string? IsTemplate { get; set; }

        [JsonProperty("template_id")]
        public string? TemplateCode { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();

    }

}
