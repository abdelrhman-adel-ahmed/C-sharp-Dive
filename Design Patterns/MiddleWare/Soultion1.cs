using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{

    public abstract class Pipe 
    {
        protected Action<string> _action;
        public Pipe(Action<string> action)
        {
            _action = action;
        }
        public abstract void Handle(string msg);
    }

    public class Wrap : Pipe
    {
        public Wrap(Action<string> action) : base(action) { }
        public override void Handle(string msg)
        {
            Console.WriteLine("start");
            _action(msg);
            Console.WriteLine("end");
        }
    }
    public class Try : Pipe
    {
        public Try(Action<string> action) : base(action) { }
        public override void Handle(string msg)
        {
            try
            {
                Console.WriteLine("trying");
                _action(msg);
            }
            catch(Exception)
            {

            }
        }
    }


    class Soultion1
    {
        
        public static void First(string msg)
        {
            Console.WriteLine($"exc first func {msg}");
        }

        public static void Second(string msg)
        {
            Console.WriteLine($"exc Second func {msg}");

        }

    }
}
