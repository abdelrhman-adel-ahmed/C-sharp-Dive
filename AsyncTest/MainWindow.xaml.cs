using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Net;
using System.Threading;
namespace AsyncTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NormalExec_Click(object sender, RoutedEventArgs e)
        {
            //we have to problem with sync:
            //1- we cannot do any thing with the UI till the event finish
            //2-we can see the results all at once not in the order of there execution because the event fucntion
            //is not returned 
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var watch = Stopwatch.StartNew();
            RunDownloadSync();
            watch.Stop();
            var timeTaken = watch.ElapsedMilliseconds;
            resultWindow.Text += $"Total time to of execution is: {timeTaken} {Environment.NewLine}";
        }

        private async void AsyncExec_Click(object sender, RoutedEventArgs e)
        {
            ThreadNumTextBox.Text = "";
            var watch = Stopwatch.StartNew();

            ThreadNumTextBox.Text += $"async contoller before await thread id: {Thread.CurrentThread.ManagedThreadId} {Environment.NewLine}";
            await RunDownloadAsync();
            ThreadNumTextBox.Text += $"async contoller after await thread id: {Thread.CurrentThread.ManagedThreadId} {Environment.NewLine}";

            watch.Stop();
            var timeTaken = watch.ElapsedMilliseconds;
            resultWindow.Text += $"Total time to of execution is: {timeTaken}";

        }
        private async Task RunDownloadAsyncParallel()
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
            var results = await Task.WhenAll(tasks);
            foreach (var item in results)
            {
                ReportWebSiteInfo(item);
            }
        }
        private async Task RunDownloadAsync()
        {
            List<string> websites = PrepData();
            foreach (var website in websites)
            {
                //await will return to the caller so the caller is now free to run untill the awit is finished 
                //note: that after function that get awaited finishes it continute in diffrent thread than the one 
                //it was running in 
                ThreadNumTextBox.Text += $"RunDownloadAsync before await thread id: {Thread.CurrentThread.ManagedThreadId} {Environment.NewLine}";
                WebSiteDTO result = await Task.Run(() => DownLoadWebSiteAsync(website));
                ThreadNumTextBox.Text += $"RunDownloadAsync after await thread id: {Thread.CurrentThread.ManagedThreadId} {Environment.NewLine}";
                ReportWebSiteInfo(result);
            }
        }
        private void RunDownloadSync()
        {
            List<string> websites = PrepData();
            foreach (var website in websites)
            {
                WebSiteDTO result = DownLoadWebSite(website);
                ReportWebSiteInfo(result);
            }
        }

        private void ReportWebSiteInfo(WebSiteDTO result)
        {
            resultWindow.Text += $"{result.websiteUrl} Downloaded: {result.websiteData.Length} Charachters long. " +
            $"{Environment.NewLine}";
        }

        private WebSiteDTO DownLoadWebSiteAsync(string websiteUrl)
        {
            WebSiteDTO output = new WebSiteDTO();
            WebClient clinet = new WebClient();

            output.websiteUrl = websiteUrl;
            output.websiteData = clinet.DownloadString(websiteUrl);

            return output;
        }
        private WebSiteDTO DownLoadWebSite(string websiteUrl)
        {
            WebSiteDTO output = new WebSiteDTO();
            WebClient clinet = new WebClient();

            output.websiteUrl = websiteUrl;
            output.websiteData = clinet.DownloadString(websiteUrl);

            return output;
        }

        private List<string> PrepData()
        {
            List<string> output = new List<string>();

            resultWindow.Text = "";
            output.Add("https://www.facebook.com");
            output.Add("https://www.google.com");
            output.Add("https://www.microsoft.com");
            output.Add("https://www.stackoverflow.com");
            output.Add("https://en.wikipedia.org");

            return output;
        }
    }
}
