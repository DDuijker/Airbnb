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
    internal class ReservationsViewModel
    {
        private AirBnbContext Db { get; set; }

        public Reservation SelectedReservation { get; set; }
        public virtual ObservableCollection<Reservation> AllReservations { get; set; }


        public ICommand CreateReservationCommand { get; set; }
        public ICommand DeleteReservationCommand { get; set; }
        public ICommand EditReservationCommand { get; set; }


        public ReservationsViewModel()
        {
            CreateReservationCommand = new RelayCommand(CreateReservation);
            DeleteReservationCommand = new RelayCommand(DeleteReservation);
            EditReservationCommand = new RelayCommand(EditReservation);

            Db = new();

            Db.Reservations.Include("Customer").Include("Property").Load();
            AllReservations = Db.Reservations.Local.ToObservableCollection();
        }

        private void CreateReservation()
        {
            Reservation reservation = new();

            AllReservations.Add(reservation);
            Db.SaveChanges();

            EditReservation newWindow = new(reservation, Db);
            newWindow.Show();
        }

        private void DeleteReservation()
        {
            if (SelectedReservation == null) return;

            AllReservations.Remove(SelectedReservation);
            Db.SaveChanges();
        }

        private void EditReservation()
        {
            if (SelectedReservation == null) return;

            EditReservation newWindow = new(SelectedReservation, Db);
            newWindow.Show();
        }
    }
}
