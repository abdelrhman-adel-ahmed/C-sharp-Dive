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
            if(Controller ==null)
                return "404 page not found";

            var action = GetAction(Controller, uri);
            if (action == null)
                return "404 page not found";
            var parameters = GetQueryString(Controller, uri);
            return action.Invoke(Controller, parameters);
        }

        Controller GetController(Uri uri)
        {
            var path = uri.AbsolutePath;
            // we see if the path start with the controller name that we will but in canonical form
            //we first prefix the controller name with  / and remove the controller word , and then ignore the casing
            //and if any matches we return that controller 
            var controller = ControllerTypes.FirstOrDefault(x => path.StartsWith($"/{x.Name.Replace("Controller","")}",
                StringComparison.InvariantCultureIgnoreCase));
            if (controller == null)
                return null;
            return (Controller)Activator.CreateInstance(controller);
        }
        MethodInfo GetAction(Controller controller,Uri uri)
        {
            //better to use regex here
            var ActionName = uri.AbsolutePath.Split('/').Last();

            //InvariantCultureIgnoreCase will ingnore the casign in x name and also in the ActionName
            return controller.GetType().GetMethods().FirstOrDefault
                (x => x.Name.Equals(ActionName,StringComparison.InvariantCultureIgnoreCase));

        }

        public object[] GetQueryString(Controller controller,Uri uri)
        {
            return null;
        }
    }
}
