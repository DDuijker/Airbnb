using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Windows;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class HomeViewModel
    {
        public ICommand ShowLandlordsCommand { get; set; }
        public ICommand ShowPropertiesCommand { get; set; }
        public ICommand ShowCustomersCommand { get; set; }
        public ICommand ShowReservationsCommand { get; set; }
        public ICommand GenerateSeedingCommand { get; set; }

         AirBnbContext db { get; set; }

        public HomeViewModel()
        {
            ShowLandlordsCommand = new RelayCommand(ShowLandlords);
            ShowPropertiesCommand = new RelayCommand(ShowProperties);
            ShowCustomersCommand = new RelayCommand(ShowCustomers);
            ShowReservationsCommand = new RelayCommand(ShowReservations);
            GenerateSeedingCommand = new RelayCommand(GenerateSeeding);
        }

        public void ShowLandlords()
        {
            Landlords newWindow = new();
            newWindow.Show();
        }

        public void ShowProperties()
        {
            Properties newWindow = new();
            newWindow.Show();
        }

        public void ShowCustomers()
        {
            Customers newWindow = new();
            newWindow.Show();
        }

        public void ShowReservations()
        {
            Reservations newWindow = new();
            newWindow.Show();
        }

        private void GenerateSeeding()
        {
             AirBnbContext db = new();

            if (db.Customers.Any() || db.Reservations.Any() || db.Landlords.Any() || db.Properties.Any())
            {
                MessageBox.Show("You can only use this if the database is empty", "Error", MessageBoxButton.OK);
            }

            Landlord newLandlord = new()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com",
                PhoneNumber = "+111111111111",
                Address = "John Doe st 1",
                City = "NYC",
                Zip = "84942",
                Country = "USA"
            };
            db.Landlords.Add(newLandlord);

            Property newProperty = new()
            {
                Address = "John Doe st 2",
                City = "NYC",
                Zip = "84942",
                Country = "USA",
                Price = 80,
                NumberOfRooms = 4,
                NumberOfBeds = 2,
                NumberOfBathrooms = 1,
                Title = "Neat appartement",
                Type = "Appartement",
                Description = "Large seaside appartment with nice views on the water, The appartment has 4 rooms with 2 beds. and 1 bathroom"
            };
            db.Properties.Add(newProperty);
            db.SaveChanges();

            newLandlord.Properties.Add(newProperty);
            newProperty.Landlord = newLandlord;
            db.SaveChanges();

            Customer newCustomer = new()
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "janedoe@gmail.com",
                PhoneNumber = "+111111111112"
            };
            db.Customers.Add(newCustomer);
            db.SaveChanges();

            TimeSpan t = DateTime.UtcNow.Date.AddDays(3) - new DateTime(1970, 1, 1);
            Reservation newReservation = new()
            {
                Customer = newCustomer,
                Property = newProperty,
                AmountOfNights = 2,
                EpochArrival = (int)t.TotalSeconds,
                Status = ReservationStatus.Pending
            };
            db.Reservations.Add(newReservation);
            db.SaveChanges();
        }
    }
}
