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
    class CustomersViewModel : INotifyPropertyChanged
    {
        private Customer _selectedCustomer;
        public Customer SelectedCustomer {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                _selectedCustomer = value;
                Notify("SelectedCustomer");

                var _customerReservation = Db.Reservations.Where(reservation => reservation.Customer.Id == value.Id);
                CustomerReservations = ToObservableCollection(_customerReservation);
                Notify("CustomerReservations");
            }
        }
        public Reservation SelectedReservation { get; set; }
        public virtual ObservableCollection<Customer> AllCustomers { get; set; }
        public ObservableCollection<Reservation> CustomerReservations { get; set; }
        private AirBnbContext Db { get; set; }

        public ICommand CreateCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand EditCustomerCommand { get; set; }
        public ICommand CreateReservationCommand { get; set; }
        public ICommand DeleteReservationCommand { get; set; }


        public CustomersViewModel()
        {
            CreateCustomerCommand = new RelayCommand(CreateCustomer);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer);
            EditCustomerCommand = new RelayCommand(EditCustomer);
            CreateReservationCommand = new RelayCommand(CreateReservation);
            DeleteReservationCommand = new RelayCommand(DeleteReservation);

            Db = new();
            Db.Customers.Load();
            AllCustomers = Db.Customers.Local.ToObservableCollection();
        }

        public void CreateCustomer()
        {
            Customer newCustomer = new("", "", "", "");
            AllCustomers.Add(newCustomer);
            Db.SaveChanges();

            EditCustomer newWindow = new(newCustomer);
            newWindow.Show();
            OnRequestClose();
        }

        public void DeleteCustomer()
        {
            if (SelectedCustomer == null) return;

            AllCustomers.Remove(SelectedCustomer);
            Db.SaveChanges();
        }

        public void DeleteReservation()
        {
            if (SelectedReservation == null) return;
            if (SelectedReservation.Customer.Id != SelectedCustomer.Id) return;

            Db.Reservations.Remove(SelectedReservation);
            Db.SaveChanges();

            CustomerReservations.Remove(SelectedReservation);
        }

        public void EditCustomer()
        {
            if (SelectedCustomer == null) return;

            EditCustomer newWindow = new(SelectedCustomer);
            newWindow.Show();
            OnRequestClose();
        }

        public void CreateReservation()
        {
            if (SelectedCustomer == null) return;

            PickProperty newWindow = new(SelectedCustomer);
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
