using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.Windows;

namespace WpfApp1.ViewModels
{
    class PropertiesViewModel
    {
        public Property SelectedProperty { get; set; }
        public virtual ObservableCollection<Property> AllProperties { get; set; }
        private AirBnbContext Db { get; set; }

        public ICommand CreatePropertyCommand { get; set; }
        public ICommand DeletePropertyCommand { get; set; }
        public ICommand EditPropertyCommand { get; set; }

        public PropertiesViewModel()
        {
            CreatePropertyCommand = new RelayCommand(CreateProperty);
            DeletePropertyCommand = new RelayCommand(DeleteProperty);
            EditPropertyCommand = new RelayCommand(EditProperty);

            Db = new();
            Db.Properties.Load();
            AllProperties = Db.Properties.Local.ToObservableCollection();
        }

        public void CreateProperty()
        {
            Property newProperty = new("","","","",0,0,0,0,"","","");
            AllProperties.Add(newProperty);
            Db.SaveChanges();

            EditProperty newWindow = new(newProperty, Db);
            newWindow.Show();
        }

        public void DeleteProperty()
        {
            AllProperties.Remove(SelectedProperty);
            Db.SaveChanges();
        }

        public void EditProperty()
        {
            EditProperty newWindow = new(SelectedProperty, Db);
            newWindow.Show();
        }

        public event EventHandler RequestClose;
        protected void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}
