using Caliburn.Micro;
using DemoLibrary.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName = "Long";
        private string _lastname;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;


        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Fu", LastName = "Long" });
            People.Add(new PersonModel { FirstName = "Kuang", LastName = "Dali" });
            People.Add(new PersonModel { FirstName = "Hua", LastName = "Tingting" });
            
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }
        
        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public bool CanClearText(string firstName, string lastName)
        {
            return !(string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName));
        }

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }
        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }

    }
}