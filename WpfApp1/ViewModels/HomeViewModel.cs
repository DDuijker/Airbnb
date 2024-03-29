﻿using CommunityToolkit.Mvvm.Input;
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
         Landlord newLandlord2 = new()
         {
            FirstName = "Clarissa",
            LastName = "Fawk",
            Email = "ClarissaFawk@gmail.com",
            PhoneNumber = "+111111111111",
            Address = "Kevin Wales st 5",
            City = "Almere",
            Zip = "1353AW",
            Country = "Netherlands"
         };
         db.Landlords.Add(newLandlord);
         db.Landlords.Add(newLandlord2);

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
         Property newProperty2 = new()
         {
            Address = "Kevin Wales st 5",
            City = "Almere",
            Zip = "1353AW",
            Country = "Netherlands",
            Price = 135,
            NumberOfRooms = 6,
            NumberOfBeds = 3,
            NumberOfBathrooms = 2,
            Title = "Downtown Penthouse",
            Type = "Penthouse",
            Description = "Large penthouse in downtown Almere with great views and 6 rooms, with 3 beds and 2 bathrooms. Allround great property"
         };
         Property newProperty3 = new()
         {
            Address = "Ben Dover st 18",
            City = "Amsterdam",
            Zip = "1871WK",
            Country = "Netherlands",
            Price = 115,
            NumberOfRooms = 3,
            NumberOfBeds = 2,
            NumberOfBathrooms = 1,
            Title = "Canal appartement",
            Type = "Appartement",
            Description = "An appartement in the middle of Amsterdam, seated next to the canals and a bike ride away from the city centre, this property provides great value"
         };
         Property newProperty4 = new()
         {
            Address = "Mike Oxlong st 18",
            City = "Frankfurt",
            Zip = "34682",
            Country = "Germany",
            Price = 225,
            NumberOfRooms = 8,
            NumberOfBeds = 6,
            NumberOfBathrooms = 3,
            Title = "Rural Mansion",
            Type = "Mansion",
            Description = "A huge rural mansion miles away from the city, with a big garden and 8 rooms this mansion is big enough to fit an entire family"
         };
         db.Properties.Add(newProperty);
         db.Properties.Add(newProperty2);
         db.Properties.Add(newProperty3);
         db.Properties.Add(newProperty4);
         db.SaveChanges();

         newLandlord.Properties.Add(newProperty);
         newProperty.Landlord = newLandlord;
         newLandlord2.Properties.Add(newProperty2);
         newLandlord2.Properties.Add(newProperty3);
         newLandlord2.Properties.Add(newProperty4);
         newProperty2.Landlord = newLandlord2;
         newProperty3.Landlord = newLandlord2;
         newProperty4.Landlord = newLandlord2;
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
