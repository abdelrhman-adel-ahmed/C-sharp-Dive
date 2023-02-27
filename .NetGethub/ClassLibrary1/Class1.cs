using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.IO;
using VideoLibrary;

namespace ClassLibrary1
{
    public class Class1
    {
        public static void aa()
        {
            var source = @"C:\Users\Abdelrahman.Adel\Desktop\testConverter";
            var youtube = YouTube.Default;
            var vid = youtube.GetVideo("https://www.youtube.com/watch?v=S1Xr31x_R0M");
            File.WriteAllBytes(source + vid.FullName, vid.GetBytes());
        }

    }
}
