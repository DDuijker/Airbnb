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
    class CustomersViewModel
    {
        public Customer SelectedCustomer { get; set; }
        public virtual ObservableCollection<Customer> AllCustomers { get; set; }
        private AirBnbContext Db { get; set; }

        public ICommand CreateCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand EditCustomerCommand { get; set; }
        public ICommand CreateReservationCommand { get; set; }


        public CustomersViewModel()
        {
            CreateCustomerCommand = new RelayCommand(CreateCustomer);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer);
            EditCustomerCommand = new RelayCommand(EditCustomer);
            CreateReservationCommand = new RelayCommand(CreateReservation);

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
    }
}
