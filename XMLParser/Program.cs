using System;
using System.IO;
using System.Linq;
using System.Xml;


namespace XMLParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            loop();
        }

        static void loop()
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\NTECH_Product\MM\ClientModule\ClientReports");
            foreach (var innerDirectoryInfo in dir.EnumerateDirectories())
            {
                foreach (var item in innerDirectoryInfo.EnumerateDirectories())
                {
                    foreach (var item2 in item.EnumerateFiles())
                    {
                        if (item2.Extension == ".csproj")
                        {
                            changeCsprog(item2.FullName);
                        }

                    }
                }
            }
        }
        static void changeCsprog(string filePath)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(filePath);
            XmlNodeList nodeList = doc.GetElementsByTagName("HintPath");
            foreach (XmlElement node in nodeList)
            {
                if (node.InnerText.Contains("SharedKernalLibraries"))
                {
                    node.InnerText = node.InnerText.Replace("SharedKernalLibraries", "SharedKernelLibraries");
                }
            }
            doc.Save(filePath);
        }
    }
}
