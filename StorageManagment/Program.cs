using GoogleDriveAPI;
using GoogleDriveAPI.Entities;
using System;
using System.Diagnostics;
using System.Threading;

namespace StorageManagement
{
    public class Program
    {
        long _start { get; set; }
        long? _stop { get; set; }
        static readonly double StopwatchToTimeSpanTicks = (double)Stopwatch.Frequency / TimeSpan.TicksPerSecond;

        static void Main(string[] args)
        {
            GetTimestamp();

            StorageAccountDTO storageAccountDTO = new StorageAccountDTO() { ClientId = "277099692431-9544flm1hi4388ota27ukb59v9fp9p39.apps.googleusercontent.com", ClientSecret = "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", RefreshToken = "1//04UnFKWTKQVlbCgYIARAAGAQSNwF-L9IrkU6HhWO6yUCTUH-2O4KaJjB0s_xflElNTvlkm9APEEp2vKKVVb1YiRTpzUAQC5QaBrw" };
        }
        static long GetTimestamp()
        {
            var timestamp = Stopwatch.GetTimestamp();
            return unchecked((long)(timestamp / StopwatchToTimeSpanTicks));
        }
        void StopTiming()
        {
            _stop ??= GetTimestamp();
        }
    }
    public class StorageAccountDTO
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RefreshToken { get; set; }
    }

}

