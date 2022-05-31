using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NT.Integration.Shield;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace cryptography
{
    class Program
    {
        static async Task Main(string[] args)
        {
           //List<Task<int>> tasks = new List<Task<int>>()
           //{
           //    ddd(false,1),
           //    ddd(true,2),
           //    ddd(false,3),
           //    ddd(true,4),
           //    ddd(false,5),
           //
           //};
           // int[] xx = null;
           // try
           // {
           //     xx = await Task.WhenAll(tasks);
           // }
           // catch (Exception ex)
           // {
           //
           //     Console.WriteLine(ex.Message);
           // }
           // if (xx != null)
           // {
           //     for (int i = 0; i < xx.Length; i++)
           //     {
           //         Console.WriteLine(xx[i]);
           //     }
           // }
            //string guid1 = Guid.NewGuid().ToString();
            //string guid = Guid.NewGuid().ToString("N");
            string str = "ahmed";
           string cihperText = EncryptionHandler.EncryptText(str);
           string originalText = EncryptionHandler.DecryptText(cihperText);
        }
        static  async Task<int> ddd(bool x, int num)
        {
            if (x)
                throw new Exception($"Task {num}");
            return  num;
        }
    }
}
