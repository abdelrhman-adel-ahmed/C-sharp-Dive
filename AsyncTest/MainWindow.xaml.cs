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
            var watch = Stopwatch.StartNew();
            RunDownloadSync();
            watch.Stop();
            var timeTaken = watch.ElapsedMilliseconds;
            resultWindow.Text += $"Total time to of execution is: {timeTaken}";
        }

        private void AsyncExec_Click(object sender, RoutedEventArgs e)
        {
            var watch = Stopwatch.StartNew();

            RunDownloadAsync();
            
            watch.Stop();
            var timeTaken = watch.ElapsedMilliseconds;
            resultWindow.Text += $"Total time to of execution is: {timeTaken}";

        }
        private async Task RunDownloadAsync()
        {
            List<string> websites = PrepData();
            foreach (var website in websites)
            {
                WebSiteDTO result = await Task.Run(() => DownLoadWebSiteAsync(website));
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

            return output;
        }
    }
}
