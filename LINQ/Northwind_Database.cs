using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LINQ
{
    class Northwind_Database
    {

        public static void run()
        {
            IEnumerable<Customer> customers = Db.GetCustomerList();
            foreach(var Customer in customers)
            {
                Console.WriteLine(Customer.ContactName);
                Console.WriteLine(Customer.CompanyName);
                Console.WriteLine(Customer.Country);
                Console.WriteLine();

            }
        }
       
    }

    class Db
    {
        public static List<Customer> GetCustomerList()
        {
            string cs = ConfigurationManager.ConnectionStrings["northwind"].ConnectionString;
            List<Customer> CustomerList = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Customers ", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Customer c = new Customer
                    {
                        CustomerID = (string)row["CustomerID"],
                        CompanyName = (string)row["CompanyName"],
                        Country = (string)row["Country"],
                        ContactName = (string)row["ContactName"],
                    };
                    CustomerList.Add(c);
                }
            }
            return CustomerList;
        }
    }

    class Customer
    {
        public string CustomerID { get; set; }
        public string  CompanyName { get; set; }
        public string Country { get; set; }
        public string ContactName { get; set; }
    }
}
