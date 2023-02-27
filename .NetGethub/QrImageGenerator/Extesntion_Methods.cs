using System;
using System.Text;

namespace QrImageGenerator
{
    public static class Extesntion_Methods
    {
        public static string ConvertFromBase64String(this string barcode)
        {
            try
            {
                byte[] data = Convert.FromBase64String(barcode);
                return Encoding.UTF8.GetString(data);
            }
            catch
            {
                throw new InvalidOperationException("Invalid Base 64 string format");
            }
        }
    }
}
