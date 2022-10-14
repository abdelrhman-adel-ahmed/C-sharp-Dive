using NT.SharedKernel.AppContainer;

namespace TestIoc
{
    internal class Test
    {
        public static void Register()
        {
            IocContainer.RegisterAssembly("C:\\Users\\Abdelrahman.Adel\\Desktop\\AbdelrahmanAdel\\Resolve\\bin\\Debug\\Resolve.dll", LifeStyle.Transient);
        }
    }
    
    
    
}
