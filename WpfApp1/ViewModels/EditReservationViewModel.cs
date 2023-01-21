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
using System.Windows;

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
        public Array ReservationStatusArray
        {
            get
            {
                return Enum.GetValues(typeof(ReservationStatus));
            }
        }

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

            // Ik weet dat in je in de WPF applicatie alles moet kunnen aanpassen, maar ik vind het toch echt wel fundamenteel dat je 1 property niet meerdere keren kunt reserveren voor dezelfde data
            if (Reservation.Status != ReservationStatus.Draft && Reservation.Status != ReservationStatus.Cancelled)
            {
                if (Reservation.AmountOfNights < 1)
                {
                    MessageBox.Show("Amount of nights has to be higher than 0 to be able to set status to something else than \"draft\"", "Error", MessageBoxButton.OK);
                    return;
                }

                int reservationsCount = Db.Reservations
                    .Where(_res => _res.Property.Id == Reservation.Property.Id)
                    .Where(_res => _res.Status != ReservationStatus.Draft && _res.Status != ReservationStatus.Cancelled)
                    .Where(_res => 
                        (
                            _res.EpochArrival >= Reservation.EpochArrival && _res.EpochArrival < Reservation.EpochLeave
                        ) || (
                            _res.EpochLeave > Reservation.EpochArrival && _res.EpochLeave  <= Reservation.EpochLeave
                        )
                    ).ToList().Count();

                if (reservationsCount > 0)
                {
                    MessageBox.Show("There is already a reservation for this property on these dates", "Error", MessageBoxButton.OK);
                    return;
                }
            }

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