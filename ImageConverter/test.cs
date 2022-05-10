using MediaBrowser.Model.Dto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Xps.Packaging;
using xps2img;

namespace ImageConverter
{
    public class test
    {
        public static Bitmap GetTifPagesFromXps(string xXpsFileName, double xQuality)
        {
            var tifPages = new List<byte[]>();
            Bitmap immm =null;
            var thread = new Thread(() =>
            {
                using (var xpsDoc = new XpsDocument(xXpsFileName, FileAccess.Read))
                {
                    DocumentPaginator docSeq = xpsDoc.GetFixedDocumentSequence().DocumentPaginator;

                    RenderTargetBitmap renderTarget = GetPageBitmap(docSeq, 0, new Parameters { ImageType = ImageType.Png ,Dpi=30});
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    using (var stream = new MemoryStream())
                    {
                        encoder.Frames.Add(BitmapFrame.Create(renderTarget));
                        encoder.Save(stream);
                         immm = new Bitmap(stream);

                    }
                    // renderTarget.Render(renderTarget.);
                    //
                    // var jpegEncoder = new JpegBitmapEncoder { QualityLevel = 100 };
                    // jpegEncoder.Frames.Add(BitmapFrame.Create(renderTarget));
                    //
                    // byte[] buffer;
                    // using (var memoryStream = new MemoryStream())
                    // {
                    //     jpegEncoder.Save(memoryStream);
                    //     memoryStream.Seek(0, SeekOrigin.Begin);
                    //     buffer = memoryStream.GetBuffer();
                    // }
                    // tifPages.Add(buffer);
                    // xpsDoc.Close();
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return immm;
        }

        private static RenderTargetBitmap GetPageBitmap(DocumentPaginator documentPaginator, int pageNumber, Parameters parameters)
        {
            const double dpiConst = 96.0;

            double dpi = parameters.Dpi;

            var size = parameters.RequiredSize ?? new Size();

            Func<int, bool> isSizeDefined = requiredSize => requiredSize > 0;
            Action<int, double> calcDpi = (requiredSize, pageSize) =>
            {
                if (isSizeDefined(requiredSize))
                {
                    dpi = (requiredSize / pageSize) * dpiConst;
                }
            };

            try
            {
                using (var page = documentPaginator.GetPage(pageNumber))
                {
                    if (!size.IsEmpty)
                    {
                        var portrait = page.Size.Height >= page.Size.Width;

                        if (portrait || !isSizeDefined(size.Width))
                        {
                            calcDpi(size.Height, page.Size.Height);
                        }

                        if (!portrait || !isSizeDefined(size.Height))
                        {
                            calcDpi(size.Width, page.Size.Width);
                        }
                    }

                    var ratio = dpi / dpiConst;

                    var bitmap = new RenderTargetBitmap((int)Math.Round(page.Size.Width * ratio),
                                                        (int)Math.Round(page.Size.Height * ratio), dpi, dpi, PixelFormats.Pbgra32);

                    bitmap.Render(page.Visual);

                    // Memory leak fix.
                    // http://social.msdn.microsoft.com/Forums/en/wpf/thread/c6511918-17f6-42be-ac4c-459eeac676fd
                    ((FixedPage)page.Visual).UpdateLayout();
                    
                    return bitmap;

                }
            }
            catch (XamlParseException ex)
            {
                throw new ConversionException(ex.Message, pageNumber + 1, ex);
            }
        }
    }
}

