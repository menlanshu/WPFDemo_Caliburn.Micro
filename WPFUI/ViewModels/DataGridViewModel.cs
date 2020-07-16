using Caliburn.Micro;
using DemoLibrary;
using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.ViewModels
{
    public class DataGridViewModel : Screen
    {
        public BindableCollection<PersonModel> People { get; set; }
        private DataAccess _dataAccess = new DataAccess();

        public DataGridViewModel()
        {
            People = new BindableCollection<PersonModel>(_dataAccess.GetPeople());
        }
    }
}
