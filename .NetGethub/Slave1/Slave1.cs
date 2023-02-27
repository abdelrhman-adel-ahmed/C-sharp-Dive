using Slave2;
using System;

namespace Slave1
{
    public class Slave1Class
    {
        public void Slave1Fun()
        {
            Console.WriteLine("calling Slave2 from Slave2");
            Slave2Class slave2 = new Slave2Class();
            slave2.Slave2Fun();
            Console.WriteLine("Slave1");
        }
    }
}
