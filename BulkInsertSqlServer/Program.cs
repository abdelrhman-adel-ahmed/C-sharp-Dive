using System.Configuration;

namespace BulkInsertSqlServer;

internal class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ToString();
    }
}