using ClassLibrary1;
using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeToMP3
{
    internal class Program
    {
        public static void test()
        {
            var source = @"C:\Users\Abdelrahman.Adel\Desktop\testConverter\";
           // var youtube = YouTube.Default;
            //var vid = youtube.GetVideo("https://www.youtube.com/watch?v=S1Xr31x_R0M");
            HttpClient httpClient = new HttpClient();
            var bytes = httpClient.GetAsync("https://www.youtube.com/watch?v=S1Xr31x_R0M").Result.Content.ReadAsByteArrayAsync().Result;
            File.WriteAllBytes(source + "zz", bytes);
            Class1.aa();
            var inputFile = new MediaFile { Filename = source + "zz" };
            var outputFile = new MediaFile { Filename = $"{source + "zz"}.mp3" };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                engine.Convert(inputFile, outputFile);
            }
        }
        static void Main(string[] args)
        {
            test();
        }
    }
}
