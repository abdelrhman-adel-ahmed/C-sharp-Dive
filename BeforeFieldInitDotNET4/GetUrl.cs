using System;
using System.IO;

namespace BeforeFieldInitDotNET4
{
    public class GetUrl
    {
        readonly static string DBPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"UploaderDB.db");
        IgenericRepo _webResultUrlRepository = new genericRepo(DBPath);

        public static string MyProperty31 { get; set; } = "a";
        public static string MyProperty => GetProperty();

        private static string GetProperty()
        {
            return DateTime.Now.ToString();
        }
        public static string MyProperty1 => GetProperty();
        public static string MyProperty2 => GetProperty();
        public static string MyProperty3 => GetProperty();
        public static string MyProperty4 => GetProperty();

        //embodied expression get evaluated first thing , it has something to do with the get , i think 
        //the convension is pefore i set anything i will get first thats why they get evaluated first
        public static string MyProperty5
        {
            get { return GetZrbo(); }
        }
        public static string MyProperty6 = GetZrbo();
        private static string GetZrbo()
        {
            return DateTime.Now.ToString();
        }


        // static GetUrl()
        // {
        //
        // }
        public void getShortUrl()
        {
            _webResultUrlRepository.RunRepo();
        }

    }
}
