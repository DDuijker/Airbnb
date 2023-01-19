using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class EditCustomerViewModel
    {
        public Customer Customer { get; set; }
        private AirBnbContext Db { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public EditCustomerViewModel(Customer _customer, AirBnbContext? _db = null)
        {
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);

            Customer = _customer;

            if (_db != null)
                Db = _db;
            else
            {
                Db = new();

                Customer? customer = Db.Customers.Where(customer => customer.Id == _customer.Id).FirstOrDefault();
                if (customer != null)
                {
                    Customer = customer;
                }
            }
        }

        public void Save()
        {
            Db.SaveChanges();
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
