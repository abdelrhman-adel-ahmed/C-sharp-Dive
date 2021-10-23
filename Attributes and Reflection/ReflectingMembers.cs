using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Attributes_and_Reflection
{
    class ReflectingMembers
    {
        public static void run()
        {
            Emp emp1 = new Emp("ahmed", 100);
            emp1.OnZeroSalary += Emp1_OnZeroSalary;
            emp1.CalcSalary(0);
            MemberInfo[] members = typeof(Emp).GetMembers();
            Console.WriteLine("----------public members of emp-----------");
            foreach (var member in members)
            {
                Console.WriteLine(member);
            }
            //why binding flag construction made this way ?
            MemberInfo[] members1 = typeof(Emp).GetMembers(BindingFlags.Instance | BindingFlags.NonPublic);
            Console.WriteLine("----------private and instance members of emp-----------");
            foreach (var member in members1)
            {
                Console.WriteLine(member);
            }
            Console.WriteLine("----------Field info-----------");

            FieldInfo[] fields = typeof(Emp).GetFields(BindingFlags.NonPublic |BindingFlags.Instance);
            foreach (var field in fields)
            {
                Console.WriteLine(field);
            }
            Console.WriteLine("----------method info-----------");

            MemberInfo[] methods = typeof(Emp).GetMethods();
            foreach (var method in methods)
            {
                  Console.WriteLine(method);
            }
        }


        private static void Emp1_OnZeroSalary(object sender, EventArgs e)
        {
            Emp emp = (Emp)sender;
            Console.WriteLine($"{emp.Name} is a shity emp");
        }
    }

    class Emp
    {
        private string name;
        private int hourRate;
        private decimal salary;

        public event EventHandler OnZeroSalary;
        public string Name => name;
        public int HourRate => hourRate;
        public Emp(string name, int hourRate)
        {
            this.name = name;
            this.hourRate = hourRate;
        }

        public decimal CalcSalary(int hours)
        {
            salary = hours * hourRate;
            if (salary <= 0)
                OnZeroSalary(this, EventArgs.Empty);

            return salary;
        }
    }
}
