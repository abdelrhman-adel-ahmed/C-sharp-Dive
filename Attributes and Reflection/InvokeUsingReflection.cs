using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace Attributes_and_Reflection
{
    class InvokeUsingReflection
    {
        public static void run()
        {
            //Empp emp = new Empp("ahmed", 150);
            Empp emp1 = (Empp)Activator.CreateInstance(typeof(Empp), "mohamed", 200);
            emp1.OnZeroSalary += Emp1_OnZeroSalary;
            MethodInfo method = typeof(Empp).GetMethod("CalcSalary");
            method.Invoke(emp1, new object[] { 0 });
            
        }

        private static void Emp1_OnZeroSalary(object sender, EventArgs e)
        {
            Empp x = sender as Empp;
            Console.WriteLine($"{x.Name} is fiii");
        }
    }

    class Empp
    {
        private string name;
        private int hourRate;
        private decimal salary;

        public event EventHandler OnZeroSalary;
        public string Name => name;
        public int HourRate => hourRate;
        public Empp(string name, int hourRate)
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
