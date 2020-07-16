using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary.Models;
using DemoLibrary;

namespace WPFUI.ViewModels
{
    public class ItemsControlViewModel : Screen
    {
        public BindableCollection<PersonModel> People { get; set; }
        DataAccess _dataAccess = new DataAccess();
        public ItemsControlViewModel()
        {
            People = new BindableCollection<PersonModel>(_dataAccess.GetPeople());
        }

        public void AddPerson()
        {
            _dataAccess.AddPerson(People);
        }

        public void RemovePerson()
        {
            People.Remove(_dataAccess.GetRandomItem(People.ToArray()));
        }
    }
}
