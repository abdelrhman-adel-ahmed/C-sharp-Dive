using NT.SharedKernel.SSNCore;
using OracleWebResult.Enums;
using OracleWebResult.Shared.Entities;
using OracleWebResult.SqlHelper;
using System;
using System.Threading.Tasks;
using FFMpegCore;
using Xabe.FFmpeg.Downloader;
using System.Threading;

namespace InsertIntoUserLoginTokens
{
    internal class Program
    {
     

        public static async Task run()
        {
            int counter = 1000000;
            string connectionstring = "DATA SOURCE=nat-sqldev.privatelink.database.windows.net;Database=webresultv.4_stage;PERSIST SECURITY INFO=True;USER ID=Nat_AdminDev;password=SQL_P@ssw0rd;Max Pool Size=700";
            for (int i = 0; i < counter; i++)
            {
                UserToken userToken = new UserToken
                {
                    UserId = 2,
                    IssuerIpAddress = "0.0.0.0",
                    SessionId = Guid.NewGuid().ToString(),
                    Token = "ABC",
                    UserTypeId = UserType.Payer,
                    BrowserId = "Test",
                    ClientLoginTime = DateTime.Now,
                    CreatedDate = DateTime.Now
                };
                SetLoginTime(userToken, 2);
                if (i >= 30000)
                {
                    userToken.UserTypeId = UserType.Patient;
                }
                else if (i >= 100000)
                {
                    userToken.UserTypeId = UserType.Lab;
                }
                else if (i >= 200000)
                {
                    userToken.UserTypeId = UserType.AccNum;
                }
                else if (i >= 300000)
                {
                    userToken.UserTypeId = UserType.BranchManager;
                }
                else if (i >= 300000)
                {
                    userToken.UserTypeId = UserType.BranchManager;
                }
                using (SqlManager sqlManager = new SqlManager(connectionstring))
                {
                    sqlManager.OpenConnection();
                    new UserTokensOperations().InsertUserToken(sqlManager, userToken, "NationalTe");
                }
            }
        }

        private static void SetLoginTime(UserToken userToken, double ClientUtcOffset)
        {
            DateTime ClientLoginTime = DateTime.UtcNow.AddHours(ClientUtcOffset);
            DateTime ClientLoginRoundedTime = new DateTime(ClientLoginTime.Year, ClientLoginTime.Month, ClientLoginTime.Day, ClientLoginTime.Hour, 0, 0);
            if (ClientLoginTime.Minute > 0 || ClientLoginTime.Second > 0)
                ClientLoginRoundedTime = ClientLoginRoundedTime.AddHours(1);
            userToken.ClientLoginTime = ClientLoginRoundedTime;

        }
        static async Task Main(string[] args)
        {
            Task parent = Task.Run(() =>
            {
                Console.WriteLine("Starting child task...");
                Task childTask = Task.Run(() =>
                {
                    Console.WriteLine("Child task running and stopping for a second");
                    Thread.Sleep(1000);
                    Console.WriteLine("Child task finished");
                });
            });

            Console.WriteLine("Waiting for parent task");
            parent.Wait();
            Console.WriteLine("Parent task finished");
           // await run();

        }
    }
}
