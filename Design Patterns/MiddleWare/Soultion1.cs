using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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
    public class PipeBuilder
    {
        Action<string> _mainaction;
        List<Type> _pipetype;
        public PipeBuilder(Action<string> mainaction)
        {
            _mainaction = mainaction;
            _pipetype = new List<Type>();
        }
        public PipeBuilder AddPipe(Type pipetype)
        {
            if(!pipetype.IsInstanceOfType(typeof(Pipe)))
            {
                throw new Exception();
            }
            _pipetype.Add(pipetype);
            return this;
        }
        public Action<string> Build()
        {
            var pipe = Activator.CreateInstance(_pipetype[0], _mainaction);
            return null;
        }
    }

    class Soultion1
    {
        public static void run()
        {
            var Pipe = new PipeBuilder(First).AddPipe(typeof(Try)).AddPipe(typeof(Wrap)).Build();
            Pipe("a");
        }
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
