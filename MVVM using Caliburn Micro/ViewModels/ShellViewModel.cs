using Caliburn.Micro;

namespace MVVM_using_Caliburn_Micro.ViewModels
{
    public class ShellViewModel : Screen
    {

        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
    }
}
