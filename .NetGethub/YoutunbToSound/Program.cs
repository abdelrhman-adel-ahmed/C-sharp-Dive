using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using VideoLibrary;

namespace YoutunbToSound
{
    class Program
    {

        public static void test()
        {
            var source = @"C:\Users\Abdelrahman.Adel\Desktop\testConverter\\";
            var ListofSources = new List<String>
            {
                "https://www.youtube.com/watch?v=766J2PbZhUU",
                @"https://www.youtube.com/watch?v=0_5BFx01Kbk"
            };
            foreach (var item in ListofSources)
            {
                var youtube = YouTube.Default;
                var vid = youtube.GetVideo(item);
                // HttpClient httpClient = new HttpClient();
                // var bytes = httpClient.GetAsync("https://www.youtube.com/watch?v=S1Xr31x_R0M").Result.Content.ReadAsByteArrayAsync().Result;
                File.WriteAllBytes(source + vid.FullName, vid.GetBytes());

                var inputFile = new MediaFile { Filename = source + vid.FullName };
                var outputFile = new MediaFile { Filename = $"{source + vid.FullName}.mp3" };

                using (var engine = new Engine())
                {
                    engine.GetMetadata(inputFile);

                    engine.Convert(inputFile, outputFile);
                }
            }
            
        }
        static void Main(string[] args)
        {
            test();
        }
    }
}
