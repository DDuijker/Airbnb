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
    class PropertiesViewModel : INotifyPropertyChanged
    {
        private Property _selectedProperty;
        public Property SelectedProperty {
            get
            {
                return _selectedProperty;
            }
            set
            {
                _selectedProperty = value;
                Notify("SelectedProperty");

                if (value == null) return;

                var _propertyReservation = Db.Reservations.Where(reservation => reservation.Property.Id == value.Id);
                PropertyReservations = ToObservableCollection(_propertyReservation);
                Notify("PropertyReservations");
            }
        }
        public Reservation SelectedReservation { get; set; }
        public virtual ObservableCollection<Property> AllProperties { get; set; }
        public virtual ObservableCollection<Reservation> PropertyReservations { get; set; }
        private AirBnbContext Db { get; set; }

        public ICommand CreatePropertyCommand { get; set; }
        public ICommand DeletePropertyCommand { get; set; }
        public ICommand EditPropertyCommand { get; set; }
        public ICommand EditReservationCommand { get; set; }
        public ICommand DeleteReservationCommand { get; set; }

        public PropertiesViewModel()
        {
            CreatePropertyCommand = new RelayCommand(CreateProperty);
            DeletePropertyCommand = new RelayCommand(DeleteProperty);
            EditPropertyCommand = new RelayCommand(EditProperty);
            EditReservationCommand = new RelayCommand(EditReservation);
            DeleteReservationCommand = new RelayCommand(DeleteReservation);

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
            if (SelectedProperty == null) return;

            AllProperties.Remove(SelectedProperty);
            Db.SaveChanges();
        }

        public void EditProperty()
        {
            if (SelectedProperty == null) return;

            EditProperty newWindow = new(SelectedProperty, Db);
            newWindow.Show();
        }

        public void EditReservation()
        {
            if (SelectedReservation == null) return;
            if (SelectedReservation.Property.Id != SelectedProperty.Id) return;

            EditReservation newWindow = new(SelectedReservation, Db);
            newWindow.Show();
        }

        public void DeleteReservation()
        {
            if (SelectedReservation == null) return;
            if (SelectedReservation.Property.Id != SelectedProperty.Id) return;

            Db.Reservations.Remove(SelectedReservation);
            Db.SaveChanges();
            PropertyReservations.Remove(SelectedReservation);
            Notify("PropertyReservations");
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
