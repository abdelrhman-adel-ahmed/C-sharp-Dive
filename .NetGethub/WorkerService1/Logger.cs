namespace WorkerService1
{
    public class Logger
    {
        readonly IConfiguration _configuration;  
        public Logger(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public void WriteToLogFile(ActionTypeEnum logAction, string message, bool newLine = true,
          [System.Runtime.CompilerServices.CallerMemberName] string methodName = "")
        {
            try
            {
                string baseLogPath = Path.Combine(_configuration.GetSection("Logger").Value);
                string directoryPath = Path.Combine(baseLogPath, DateTime.Now.ToString("yyyy-MM-dd"));
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string filePath = Path.Combine(directoryPath, DateTime.Now.ToString("yyyy-MM-dd HH") +
                    (logAction == ActionTypeEnum.Exception ? "_Exception" : string.Empty) + ".txt");


                using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                {
                    string[] str = new string[8];
                    str[0] = DateTime.Now.ToString("HH:mm:ss.fff");
                    str[1] = " || ";
                    str[2] = methodName.PadRight(33);
                    str[3] = " || ";
                    str[4] = logAction.ToString().PadRight(11);
                    str[5] = " || ";
                    str[6] = message;
                    if (logAction == ActionTypeEnum.Exception && newLine)
                        str[7] = Environment.NewLine + "==============================================" + Environment.NewLine;
                    streamWriter.WriteLine(string.Concat(str));
                }
            }
            catch (Exception)
            {
            }
        }
    }
    public enum ActionTypeEnum
    {
        Information = 1,
        Action = 2,
        Exception = 3
    }
}
