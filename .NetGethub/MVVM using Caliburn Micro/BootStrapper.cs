using Caliburn.Micro;
using MVVM_using_Caliburn_Micro.ViewModels;
using System.Windows;

namespace MVVM_using_Caliburn_Micro
{
    public class BootStrapper : BootstrapperBase
    {
        public BootStrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
