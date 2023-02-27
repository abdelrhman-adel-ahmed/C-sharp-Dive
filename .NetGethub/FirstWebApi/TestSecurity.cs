using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDataAceess;

namespace FirstWebApi
{
    public class TestSecurity
    {

        public static bool Login(string username ,string password)
        {
            firstdbEntities2 db = new firstdbEntities2();
            return db.users.Any(t => t.username.Equals(username, StringComparison.OrdinalIgnoreCase)
            && t.password == password);
        }
    }
}