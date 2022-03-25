using System.Drawing;
using System.IO;
using ZXing;
using ZXing.Common;

namespace QrImageGenerator
{
    public class QrGenerator
    {
        public static byte[] Generate(string barcode, bool isBase64)
        {
            if (isBase64)
            {
                barcode = barcode.ConvertFromBase64String();
            }

            IBarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.QrCode.QrCodeEncodingOptions
                {
                    Width = 160,
                    Height = 160,
                    ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.Q,
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Margin = 0
                }
            };
           // BitMatrix result = writer.Encode(barcode);]
            BarcodeWriter writerr = new BarcodeWriter();
            BitMatrix result =  writerr.Encode(barcode);
            System.Console.WriteLine(result);
            var barcodeBitmap = new Bitmap(result.ToBitmap());
           
            using (var stream = new MemoryStream())
            {
                barcodeBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }
    }

}
