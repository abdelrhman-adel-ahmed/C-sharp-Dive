using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    class User
    {

    }
    interface activator
    {
         void activate();
    }
    class Email: activator
    {
        public void activate()
        {
            Console.WriteLine("email activator");
        }
    }
    class Message: activator
    {
        public void activate()
        {
            Console.WriteLine("message activator");
        }
    }
    class Register
    {
        public Register(User user, activator activator)
        {
            activator.activate();
        }
       
    }

    class DependencyInversion
    {
        public DependencyInversion()
        {
            Register reg = new Register(new User(), new Message());

        }
    }
    public class entrypoint
    {
       public  static void run()
        {
            DependencyInversion d = new DependencyInversion();
        }
    }
}
