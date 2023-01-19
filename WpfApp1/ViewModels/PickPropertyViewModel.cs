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
    class PickPropertyViewModel
    {
        public Customer ChosenCustomer { get; set; }
        public Property SelectedProperty { get; set; }
        public virtual ObservableCollection<Property> AllProperties { get; set; }
        private AirBnbContext Db { get; set; }

        public ICommand PickCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public PickPropertyViewModel(Customer _customer, AirBnbContext? _db = null)
        {
            PickCommand = new RelayCommand(Pick);
            CancelCommand = new RelayCommand(Cancel);

            this.ChosenCustomer = _customer;

            if (_db != null)
                this.Db = _db;
            else
            {
                this.Db = new();

                Customer? customer = Db.Customers.Where(customer => customer.Id == _customer.Id).FirstOrDefault();
                if (customer != null)
                {
                    this.ChosenCustomer = customer;
                }
            }

            Db.Properties.Load();
            AllProperties = Db.Properties.Local.ToObservableCollection();
        }


        public void Pick()
        {
            Reservation reservation = new(0, 0);
            Db.Reservations.Add(reservation);
            Db.SaveChanges();

            this.ChosenCustomer.Reservations.Add(reservation);
            reservation.Customer = this.ChosenCustomer;

            this.SelectedProperty.Reservations.Add(reservation);
            reservation.Property = this.SelectedProperty;
            Db.SaveChanges();

            EditReservation newWindow = new(reservation, Db);
            newWindow.Show();

            OnRequestClose();
        }

        public void Cancel()
        {
            OnRequestClose();
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
