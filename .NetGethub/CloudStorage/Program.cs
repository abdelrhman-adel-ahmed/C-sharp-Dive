using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CloudStorage
{

    public class EncryptDecryptText
    {
        private string encryptDecryptkey = "";

        public EncryptDecryptText(string key)
        {
            encryptDecryptkey = key;
        }

        public string EncryptString(string clearText)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(clearText);
            SymmetricAlgorithm symmetricAlgorithm = SymmetricAlgorithm.Create();
            MemoryStream memoryStream = new MemoryStream();
            byte[] bytes2 = Encoding.ASCII.GetBytes(encryptDecryptkey);
            byte[] bytes3 = Encoding.ASCII.GetBytes(encryptDecryptkey);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(bytes3, bytes2), CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.Close();
            return Convert.ToBase64String(memoryStream.ToArray());
        }

    }
    class Program0
    {
        private static bool IsValidEmailAddress(string emailaddress)
        {
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            Match match = regex.Match(emailaddress);
            return match.Success;
        }
        static void Main(string[] args)
        {
            var x =IsValidEmailAddress("ckj2128@@mail.haitian.com");
            EncryptDecryptText en = new EncryptDecryptText("zxcvbnmasdfghjkl");
            var xx = en.EncryptString("123");
            MainDSL.FileUpload();
            //Response<string> response =  zrboo("ahmed", Token());
            //while (true)
            //{
            //    appsettings.zrb = ConfigurationManager.AppSettings["zrbo"];
            //    Console.WriteLine(appsettings.zrb);
            //}
        }

        static string Token()
        {
            return "123";
        }

        static Response<T> zrboo<T>(T url, string token)
        {
            Console.WriteLine(token);
            return new Response<T> { message = url };
        }
    }
    class Response<T>
    {
        public T message { get; set; }
    }
    class appsettings
    {
        public static string zrb
        {
            get
            {
                return zrb;
            }
            set
            {
                zrb = value;
                return;
            }
        }
    }
}
