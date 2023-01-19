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

namespace WpfApp1.ViewModels
{
    class EditReservationViewModel
    {
        public Reservation Reservation { get; set; }
        private AirBnbContext Db { get; set; }

        public virtual ObservableCollection<Customer> AllCustomers { get; set; }
        public virtual ObservableCollection<Property> AllProperties { get; set; }

        public DateTime PickedDate { get; set; }

        public ICommand SaveCommand { get; set; }

        public EditReservationViewModel(Reservation _reservation, AirBnbContext? _db = null)
        {
            SaveCommand = new RelayCommand(Save);

            Reservation = _reservation;

            if (_db != null)
                Db = _db;
            else
            {
                Db = new();

                Reservation? res = Db.Reservations.Where(_res => _res.Id == _reservation.Id).FirstOrDefault();
                if (res != null)
                {
                    Reservation = res;
                }
            }

            Db.Properties.Load();
            AllProperties = Db.Properties.Local.ToObservableCollection();

            Db.Customers.Load();
            AllCustomers = Db.Customers.Local.ToObservableCollection();

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(Reservation.EpochArrival);
            PickedDate = dateTimeOffset.DateTime;
        }

        public void Save()
        {
            TimeSpan t = PickedDate - new DateTime(1970, 1, 1);
            Reservation.EpochArrival = (int)t.TotalSeconds;

            Db.SaveChanges();
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
