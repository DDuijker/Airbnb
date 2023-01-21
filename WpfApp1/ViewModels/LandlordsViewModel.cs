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
using System.ComponentModel;

namespace WpfApp1.ViewModels
{
    class LandlordsViewModel : INotifyPropertyChanged
    {
        private Landlord _selectedLandlord;
        public Landlord SelectedLandlord { 
            get
            {
                return _selectedLandlord;
            }
            set
            {
                _selectedLandlord = value;
                Notify("SelectedLandlord");

                if (value == null) return;

                var _landlordProperties = Db.Properties.Where(property => property.Landlord.Id == value.Id);
                LandlordProperties = ToObservableCollection(_landlordProperties);
                Notify("LandlordProperties");
            }
        }
        public Property SelectedProperty { get; set; }
        public virtual ObservableCollection<Landlord> AllLandlords { get; set; }
        public virtual ObservableCollection<Property> LandlordProperties { get; set; }
        private AirBnbContext Db { get; set; }

        public ICommand CreateLandlordCommand { get; set; }
        public ICommand DeleteLandlordCommand { get; set; }
        public ICommand CreatePropertyCommand { get; set; }
        public ICommand EditLandlordCommand { get; set; }
        public ICommand DeletePropertyCommand { get; set; }
        public ICommand EditPropertyCommand { get; set; }

        public LandlordsViewModel()
        {
            CreateLandlordCommand = new RelayCommand(CreateLandlord);
            DeleteLandlordCommand = new RelayCommand(DeleteLandlord);
            CreatePropertyCommand = new RelayCommand(CreateProperty);
            EditLandlordCommand = new RelayCommand(EditLandlord);
            DeletePropertyCommand = new RelayCommand(DeleteProperty);
            EditPropertyCommand = new RelayCommand(EditProperty);

            Db = new();

            Db.Landlords.Load();
            AllLandlords = Db.Landlords.Local.ToObservableCollection();
        }

        public void CreateLandlord()
        {
            Landlord newLandlord = new("","","","","","","","");
            AllLandlords.Add(newLandlord);
            Db.SaveChanges();

            EditLandlord newWindow = new(newLandlord, Db);
            newWindow.Show();
        }

        public void DeleteLandlord()
        {
            if (SelectedLandlord == null) return;
            AllLandlords.Remove(SelectedLandlord);
            Db.SaveChanges();
        }

        public void CreateProperty()
        {
            if (SelectedLandlord == null) return;
            AddProperty newWindow = new(SelectedLandlord, Db);
            newWindow.Show();
        }

        public void EditLandlord()
        {
            if (SelectedLandlord == null) return;
            EditLandlord newWindow = new(SelectedLandlord, Db);
            newWindow.Show();
        }

        public void DeleteProperty()
        {
            if (SelectedProperty == null) return;

            Db.Properties.Remove(SelectedProperty);
            Db.SaveChanges();

            LandlordProperties.Remove(SelectedProperty);
        }

        public void EditProperty()
        {
            if (SelectedProperty == null) return;

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

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<T> ToObservableCollection<T>(IEnumerable<T> enumeration)
        {
            return new ObservableCollection<T>(enumeration);
        }
    }
}
