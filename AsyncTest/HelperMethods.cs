using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncTest
{
    public class HelperMethods : Window
    {
        public static async Task<List<WebSiteDTO>> RunDownloadAsyncParallel()
        {
            //the old approach of async we used,we have to wait for each call till it finish and procced to the next 
            //here we dont wait for any call we make them all in parrallel, but still we will wait untill all of them 
            //finishes to make call to ReportWebSiteInfo func ,so the total time we take is the time the longest request
            //take to finish 
            List<string> websites = PrepData();
            List<Task<WebSiteDTO>> tasks = new List<Task<WebSiteDTO>>();

            foreach (var website in websites)
            {
                tasks.Add(Task.Run(() => DownLoadWebSiteAsync(website)));
            }
            WebSiteDTO[] results = await Task.WhenAll(tasks);
            return new List<WebSiteDTO>(results);
        }

        public static async Task<List<WebSiteDTO>> RunDownloadAsync()
        {
            List<string> websites = PrepData();
            List<WebSiteDTO> output = new List<WebSiteDTO>();

            foreach (var website in websites)
            {
                //await will return to the caller so the caller is now free to run untill the awit is finished 
                //note: that after function that get awaited finishes it continute in diffrent thread than the one 
                //it was running in 
                //ThreadNumTextBox.Text += $"RunDownloadAsync before await thread id: {Thread.CurrentThread.ManagedThreadId} {Environment.NewLine}";
                WebSiteDTO result = await Task.Run(() => DownLoadWebSiteAsync(website));
                output.Add(result);
                //ThreadNumTextBox.Text += $"RunDownloadAsync after await thread id: {Thread.CurrentThread.ManagedThreadId} {Environment.NewLine}";
            }
            return output;
        }
        public static List<WebSiteDTO> RunDownloadSync()
        {
            List<string> websites = PrepData();
            List<WebSiteDTO> output = new List<WebSiteDTO>();
            foreach (var website in websites)
            {
                WebSiteDTO result = DownLoadWebSite(website);
                output.Add(result);
            }
            return output;
        }



        public async static Task<WebSiteDTO> DownLoadWebSiteAsync(string websiteUrl)
        {
            WebSiteDTO output = new WebSiteDTO();
            HttpClient clinet = new HttpClient();

            System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            output.websiteUrl = websiteUrl;
            HttpResponseMessage message = await clinet.GetAsync(websiteUrl);
            System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            output.websiteData = await message.Content.ReadAsStringAsync();
            System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId);


            return output;
        }
        public static WebSiteDTO DownLoadWebSite(string websiteUrl)
        {
            WebSiteDTO output = new WebSiteDTO();
            WebClient clinet = new WebClient();

            output.websiteUrl = websiteUrl;
            output.websiteData = clinet.DownloadString(websiteUrl);

            return output;
        }

        public static List<string> PrepData()
        {
            List<string> output = new List<string>();

            output.Add("https://www.facebook.com");
            output.Add("https://www.google.com");
            output.Add("https://www.microsoft.com");
            output.Add("https://www.stackoverflow.com");
            output.Add("https://en.wikipedia.org");

            return output;
        }
    }
}
