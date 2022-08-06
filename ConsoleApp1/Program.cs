using NT.Integration.SharedKernel.OracleManagedHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter Project Path");
                string projectPath = @"D:\\cloneV4azure\\OracleWebresult.Client\\UserLogin_UI\\FirstLab";
                Console.WriteLine("Please enter subApplication (ex. Login, Result, ClientAdmin)");
                string subApplication = "Login";
                Console.WriteLine("Please enter your desirable path for publish");
                string zipFilePath = @"C:\\Users\\abdelrahman.adel\\Desktop\\";

                Console.WriteLine("Please wait it will take a while...");


                RunCmd(projectPath, subApplication);

                string publishFolderPath = projectPath + @"\dist";
                var configFile = Directory.GetFiles(publishFolderPath, "config.json", SearchOption.AllDirectories).FirstOrDefault();
                if (File.Exists(configFile))
                {
                    File.Delete(configFile);
                }

                ZipFile.CreateFromDirectory(Directory.GetDirectories(publishFolderPath).FirstOrDefault(), zipFilePath + @"\Publish.zip");

                Console.WriteLine("Successfully published ^_^");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured while published ^", ex.ToString());
            }
        }

        private static void RunCmd(string projectPath, string subApplication)
        {
            try
            {
                string cwd = $"cd";
                string npmCommand = "npm install";
                string publishCommand = $"ng build --configuration=production --base-href /{subApplication}/";

                List<string> commands = new List<string>();
                commands.Add(cwd);
                commands.Add(npmCommand);
                commands.Add(publishCommand);

                Process process = new Process();
                var startInfo = new ProcessStartInfo()
                {
                    WorkingDirectory = projectPath,
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                process.StartInfo = startInfo;
                process.Start();
                process.StandardInput.WriteLine(string.Join(" & ", commands));
                process.StandardInput.Flush();
                process.StandardInput.Close();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
            }

        }


    }

   

}
