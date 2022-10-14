using NT.SharedKernel.AppContainer;
using Resolve1;
using Resolver2;

namespace TestIoc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IocContainer.RegisterAssembly("C:\\Users\\Abdelrahman.Adel\\Desktop\\AbdelrahmanAdel\\Resolve\\bin\\Debug\\Resolve.dll", LifeStyle.Transient);
            IBase xx = IocContainer.ResolveAssembly<IBase>();
            IBase2 xxx = IocContainer.ResolveAssembly<IBase2>();

        }
    }
}
