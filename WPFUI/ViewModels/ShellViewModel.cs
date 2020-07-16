using Caliburn.Micro;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName = "Long";
        private string _lastname;
        private BindableCollection<Person> _people = new BindableCollection<Person>();
        private Person _selectedPerson;


        public ShellViewModel()
        {
            People.Add(new Person { FirstName = "Fu", LastName = "Long" });
            People.Add(new Person { FirstName = "Kuang", LastName = "Dali" });
            People.Add(new Person { FirstName = "Hua", LastName = "Tingting" });
            
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

        public BindableCollection<Person> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public Person SelectedPerson
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