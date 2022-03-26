using Caliburn.Micro;

namespace MVVM_using_Caliburn_Micro.ViewModels
{
    public class ShellViewModel : Screen
    {

        private string _firstName = "ahmed";

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName); //notify all people that using FullName that it has been changed
                NotifyOfPropertyChange(() => FullName);
            }
        }


        private string _lastName = "mohamed";

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
