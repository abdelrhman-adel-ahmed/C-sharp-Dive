using System;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;

using System.Threading.Tasks;
using NT.Integration.SharedKernel.OracleManagedHelper;
using System.Data.Common;
using System.Threading;

namespace cryptography
{
    public class ResultDTO
    {
        public int SendKey { get; set; }
        public string NationalId { get; set; }
        public string ArabicName { get; set; }
        public string PassportNumber { get; set; }
        public string Result { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CollectioDate { get; set; }
        public string VisitId { get; set; }
        public string WebResult_ShortUrl { get; set; }
        public string Token { get; set; }
    }
    class Program
    {
        public static Task<ResultDTO> GetResult(OracleManager oracleManager)
        {
            oracleManager.CommandParameters.Add("resultcur", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);
            return MapResult(oracleManager.ExcuteReaderAsync($"MOI_HAG_GET_RESULTS", CommandType.StoredProcedure));
        }

        public static async Task<ResultDTO> MapResult(Task<DbDataReader> dataReader)
        {
            DbDataReader reader = await dataReader;

            ResultDTO result = null;
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    result = new ResultDTO
                    {
                        SendKey = Convert.ToInt32(reader["send_key"]),
                        NationalId = reader["national_id"].ToString(),
                        ArabicName = reader["arabic_name"].ToString(),
                        PassportNumber = reader["passport_no"].ToString(),
                        Result = reader["result"].ToString(),
                        BirthDate = Convert.ToDateTime(reader["birth_date"]),
                        CollectioDate = Convert.ToDateTime(reader["collection_date"]),
                        VisitId = reader["visit_id"].ToString(),
                        WebResult_ShortUrl = reader["webresult_shorturl"].ToString(),
                    };
                }
            }
            reader.Close();
            return result;
        }

        public static int var1 { get; set; }
        public static int var2 { get; set; }
        public static object lockk { get; set; }


        public static void cacl1()
        {
            lock (lockk)
            {
                cacl2();
            }
        }
        public static void cacl2()
        {
            lock (lockk)
            {
                cacl1();
            }
        }
        public static async Task CallDB()
        {
            OracleManager oracleManager = new OracleManager(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            await oracleManager.OpenConnectionAsync();
            await GetResult(oracleManager);
            oracleManager.CloseConnection();
        }
        static async Task Main(string[] args)
        {


           //bool hamada = true;
           //int count = 0;
           //while (hamada)
           //{
           //    count++;
           //    await Task.Run(async () =>await CallDB());
           //   
           //}
            //List<Task<int>> tasks = new List<Task<int>>()
            //{
            //    ddd(false,1),
            //    ddd(true,2),
            //    ddd(false,3),
            //    ddd(true,4),
            //    ddd(false,5),
            //
            //};
            // int[] xx = null;
            // try
            // {
            //     xx = await Task.WhenAll(tasks);
            // }
            // catch (Exception ex)
            // {
            //
            //     Console.WriteLine(ex.Message);k
            // }
            // if (xx != null)
            // {
            //     for (int i = 0; i < xx.Length; i++)
            //     {
            //         Console.WriteLine(xx[i]);
            //     }
            // }
            //string guid1 = Guid.NewGuid().ToString();
            //string guid = Guid.NewGuid().ToString("N");
            //string str = "ahmed";
            //byte[] stringInBytes = Encoding.UTF8.GetBytes(str);
            //string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
            //string cihpertestxt = base64.PadRight(32);
            //string cihperText = EncryptionHandler.EncryptText(cihpertestxt);
            //string originalText = EncryptionHandler.DecryptText(cihperText);
            int count = 0;
            bool zrboo = true;
            while (zrboo)
            {
                ztboooo(count);
                count++;
            }
            //int ss = 1;
            //configurationHelper.onInit();
            //var x1 = AppSettings.key1;
            //var x2 = AppSettings.key1;
            AppSettings.execute(() => { return "3211"; });
            AppSettings.execute((string X) => { return true; });

            var x1 = AppSettings2.key1;
            var x2 = AppSettings2.key1;
        }
        static async Task<int> ddd(bool x, int num)
        {
            if (x)
                throw new Exception($"Task {num}");
            return num;
        }

        static void ztboooo(int numofRows)
        {
            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection conn = new OracleConnection(cs);
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter($"select * from v$session where ROWNUM <= {numofRows}", conn);
            OracleCommandBuilder builder = new OracleCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Console.WriteLine(ds.Tables[0].Rows.Count);
        }
    }
    class configurationHelper
    {
        public static void onInit()
        {
            AppSettings.key1 = ConfigurationManager.AppSettings["key1"];
            AppSettings.key2 = ConfigurationManager.AppSettings["key2"];
        }
    }
    class configurationHelper2
    {
        public static string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }

    class AppSettings
    {
        public static void execute(Func<string, bool> proces)
        {

        }
        public static void execute(Func<string> proces)
        {

        }
        public static string key1 { get; set; }
        public static string key2 { get; set; }
    }


    class AppSettings2
    {
        public static string key1 => getKey1();
        private static string key11; //private backing field
        public static bool key1_optained = false;

        private static string getKey1()
        {
            if (!key1_optained)
            {
                key11 = configurationHelper2.Get("key1");
                key1_optained = true;
            }
            return key11;
        }

        public static string key2 => getKey2();

        private static string getKey2()
        {
            return configurationHelper2.Get("key2");

        }
    }
}
