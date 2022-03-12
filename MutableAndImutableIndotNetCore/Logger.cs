using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MutableAndImutableIndotNetCore
{
    class Logger
    {
        public static void WriteToLogFile(StackFrame stackframe, Exception exception, string exceptionDetail)
        {
            WriteToLogFile(ActionTypeEnum.Exception, stackframe, exceptionDetail + Environment.NewLine + exception.ToString());
        }


        public static void WriteToLogFile(ActionTypeEnum logAction, StackFrame stackframe, string message)
        {
            try
            {
                string directoryPath = Path.Combine("D:\\test");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                using (StreamWriter streamWriter = new StreamWriter(Path.Combine(directoryPath, DateTime.Now.ToString("yyyy-MM-dd HH") + ".txt"), true))
                {
                    string method = stackframe.GetMethod().ToString();
                    string linenumber = stackframe.GetFileLineNumber().ToString();

                    string[] str = new string[7];
                    str[0] = DateTime.Now.ToString("HH:mm:ss.fff");
                    str[1] = " || ";
                    str[2] = method.PadRight(33);
                    str[3] = " || ";
                    str[2] = stackframe.GetFileLineNumber().ToString().PadRight(33);
                    str[3] = " || ";
                    str[4] = logAction.ToString().PadRight(11);
                    str[5] = " || ";
                    str[6] = message;
                    streamWriter.WriteLine(string.Concat(str));
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
