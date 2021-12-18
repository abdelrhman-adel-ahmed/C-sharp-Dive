using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace concurrency_and_parallelism
{
    class ListOfUrls
    {

        public static async Task run()
        {
            await AsyncDownload();
            await AsyncDownloadParrallel();
        }

        public static async Task AsyncDownloadParrallel()
        {
            List<string> urls = Urls();
            Stopwatch profiler = new Stopwatch();
            List<Task<HttpResponseMessage>> Tasks = new List<Task<HttpResponseMessage>>();
            profiler.Start();
            foreach (var url in urls)
            {
                HttpClient c = new HttpClient();
                Tasks.Add(Task.Run(() => c.GetAsync(url)));
            }
            var result = Task.WhenAll(Tasks);
            profiler.Stop();
            Console.WriteLine($"Async Parrallel takes {profiler.Elapsed.TotalSeconds} senconds");

        }
        public static async Task AsyncDownload()
        {
            List<string> urls = Urls();
            List<WebSiteDTO> output = new List<WebSiteDTO>();
            Stopwatch profiler = new Stopwatch();
            profiler.Start();
            foreach (var url in urls)
            {
                HttpClient c = new HttpClient();
                HttpResponseMessage content = await Task.Run(() => c.GetAsync(url));
                WebSiteDTO o = new WebSiteDTO
                {
                    url = url,
                    Content = content.Content.ToString()
                };
                output.Add(o);
            }
            profiler.Stop();
            Console.WriteLine($"Async takes {profiler.Elapsed.TotalSeconds} senconds");
        }
        private static HttpClient Factory()
        {
            HttpClient c = new HttpClient();

            return c;
        }
        public static Task<string> ParseContent(HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync();

        }
        private static List<string> Urls()
        {
            List<string> urls = new List<string>();

            urls.Add("https://www.facebook.com");
            urls.Add("https://www.google.com");
            urls.Add("https://www.microsoft.com");
            urls.Add("https://www.stackoverflow.com");
            urls.Add("https://en.wikipedia.org");

            return urls;
        }
    }

    class WebSiteDTO
    {
        public string Content { get; set; }
        public string url { get; set; }
    }


    class SyncDownload
    {

        public static void run()
        {
            download();
        }

        private static void download()
        {
            List<string> urls = Urls();
            Stopwatch profiler = new Stopwatch();
            profiler.Start();
            foreach (var url in urls)
            {
                WebClient c = new WebClient();
                var result = c.DownloadString(url);
            }
            profiler.Stop();
            Console.WriteLine($"Sync takes {profiler.Elapsed.TotalSeconds} senconds");
        }
        private static List<string> Urls()
        {
            List<string> urls = new List<string>();

            urls.Add("https://www.facebook.com");
            urls.Add("https://www.google.com");
            urls.Add("https://www.microsoft.com");
            urls.Add("https://www.stackoverflow.com");
            urls.Add("https://en.wikipedia.org");

            return urls;
        }
    }

}
