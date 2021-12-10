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
            if (!pipetype.GetType().IsInstanceOfType(typeof(Pipe)))
            {
                throw new Exception();
            }
            _pipetype.Add(pipetype);
            return this;
        }
        public Pipe Build()
        {
            //it will always return whatever pipe we specife in here , but we want a composition        
            Pipe pipe =(Pipe) Activator.CreateInstance(_pipetype[0], _mainaction);
            return pipe;
        }
    }

    class Soultion1
    {
        public static void run()
        {
            PipeBuilder Pipebuilder= new PipeBuilder(First);
            var middle1 = Pipebuilder.AddPipe(typeof(Try));
            var middel2 = Pipebuilder.AddPipe(typeof(Wrap));
            var pipe = Pipebuilder.Build();
            pipe.Handle("a");         
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
