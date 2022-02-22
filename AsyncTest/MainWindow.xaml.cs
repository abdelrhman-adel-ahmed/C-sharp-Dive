using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Threading;

namespace AsyncTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HelperMethods HelperMethods = new HelperMethods();
        public static MainWindow InstanceMainWindow = new MainWindow();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void UpdateThreadText()
        {
            ThreadNumTextBox.Text += $"async contoller thread id: {Thread.CurrentThread.ManagedThreadId} {Environment.NewLine}";
        }
        private void NormalExec_Click(object sender, RoutedEventArgs e)
        {
            //we have to problem with sync:
            //1- we cannot do any thing with the UI till the event finish
            //2-we can see the results all at once not in the order of there execution because the event fucntion
            //is not returned 
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var watch = Stopwatch.StartNew();
            List<WebSiteDTO> Results = HelperMethods.RunDownloadSync();
            ReportWebSiteInfo(Results);
            watch.Stop();
            var timeTaken = watch.ElapsedMilliseconds;
            resultWindow.Text += $"Total time to of execution is: {timeTaken} {Environment.NewLine}";
        }
       public async Task RunDownloadAsync(IProgress<ProgressReportModel> Progress)
        {
            List<string> websites = HelperMethods.PrepData();
            ProgressReportModel report = new ProgressReportModel();

            foreach (var website in websites)
            {
                WebSiteDTO result = await Task.Run(() => HelperMethods.DownLoadWebSiteAsync(website));

                report.SiteDownloaded = result;
                report.PercentageCompleted += 100 / websites.Count;
                Progress.Report(report);
                //ReportWebSiteInfo(website);
            }
        }
        private async void AsyncExec_Click(object sender, RoutedEventArgs e)
        {
            ThreadNumTextBox.Text = "";
            resultWindow.Text = " ";
            Stopwatch watch = Stopwatch.StartNew();
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += ReportProgress;
            ThreadNumTextBox.Text += $"async contoller before await thread id: {Thread.CurrentThread.ManagedThreadId} {Environment.NewLine}";
            await RunDownloadAsync(progress);
            ThreadNumTextBox.Text += $"async contoller after await thread id: {Thread.CurrentThread.ManagedThreadId} {Environment.NewLine}";

            watch.Stop();
            long timeTaken = watch.ElapsedMilliseconds;
            resultWindow.Text += $"Total time to of execution is: {timeTaken}";
        }

        private void ReportProgress(object sender, ProgressReportModel e)
        {
            dashboardprogress.Value = e.PercentageCompleted;
            ReportWebSiteInfo(e.SiteDownloaded);
        }

        private async void ParallelExecuteAsync_Click(object sender, RoutedEventArgs e)
        {
            ThreadNumTextBox.Text = "";
            resultWindow.Text = " ";
            var watch = Stopwatch.StartNew();

            ThreadNumTextBox.Text += $"async contoller before await thread id: {Thread.CurrentThread.ManagedThreadId} {Environment.NewLine}";
            var Results = await HelperMethods.RunDownloadAsyncParallel();
            ReportWebSiteInfo(Results);
            ThreadNumTextBox.Text += $"async contoller after await thread id: {Thread.CurrentThread.ManagedThreadId} {Environment.NewLine}";

            watch.Stop();
            var timeTaken = watch.ElapsedMilliseconds;
            resultWindow.Text += $"Total time to of execution is: {timeTaken}";
        }
        private void ReportWebSiteInfo(List<WebSiteDTO> results)
        {
            resultWindow.Text = " ";
            foreach (var result in results)
            {
                resultWindow.Text += $"{result.websiteUrl} Downloaded: {result.websiteData.Length} Charachters long. " +
                        $"{Environment.NewLine}";
            }
        }
        private  void ReportWebSiteInfo(WebSiteDTO result)
        {
            //resultWindow.Text = " ";
            resultWindow.Text += $"{result.websiteUrl} Downloaded: {result.websiteData.Length} Charachters long. " +
                        $"{Environment.NewLine}";
        }
    }
}
