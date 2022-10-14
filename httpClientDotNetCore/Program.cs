using HttpClientDotNetStandard;

namespace httpClientDotNetCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1.test();
            HttpClient httpClient = new HttpClient();
            Console.WriteLine("Hello, World!");
        }
    }
}