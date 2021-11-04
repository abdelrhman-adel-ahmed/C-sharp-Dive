using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Design_Patterns.MVC
{
    class MVCContainer
    {
        List<Type> ControllerTypes = new List<Type>();
        public MVCContainer()
        {
            var ControllerType = typeof(Controller);
            ControllerTypes =
            ControllerType.Assembly.GetTypes().Where(type => !type.IsAbstract && ControllerType.IsAssignableFrom(type)).ToList();
               
        }
        public object Resolve(Uri uri)
        {
            //get the controller from the url path
            var Controller = GetController(uri);
            var action = GetAction(Controller, uri);
            return action;

        }

        Controller GetController(Uri uri)
        {
            var path = uri.AbsolutePath;
            // we see if the path start with the controller name that we will but in canonical form
            //we first prefix the controller name with  / and remove the controller word , and then ignore the casing
            //and if any matches we return that controller 
            var controller = ControllerTypes.FirstOrDefault(x => path.StartsWith($"/{x.Name.Replace("Controller","")}",
                StringComparison.InvariantCultureIgnoreCase));
        
            return (Controller)Activator.CreateInstance(controller);
        }
        MethodInfo GetAction(Controller controller,Uri uri)
        {
            var func_name = uri.AbsolutePath.Split('/').Last();

            var actionFunc = controller.GetType().GetRuntimeMethods().FirstOrDefault(x=> func_name == x.Name.ToLower());
            actionFunc.Invoke(Activator.CreateInstance(controller.GetType()), new object[0]);
            Console.WriteLine(actionFunc.Invoke(Activator.CreateInstance(controller.GetType()),new object[0]));
            return actionFunc;
        }
    }
}
