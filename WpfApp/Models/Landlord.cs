using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnB.Model
{
    public class Landlord
    {
        public ObservableCollection<Landlord> landLordsCollection;
        ///make variables for a landlord
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public Landlord()
        {
            landLordsCollection = new ObservableCollection<Landlord>();
        }

        public Landlord(string firstName, string lastName, string email, string password, string phoneNumber, string address, string city, string zipCode, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
            ZipCode = zipCode;
            Country = country;
        }

        public void AddLandlord(Landlord landlord)
        {
            landLordsCollection.Add(landlord);
        }
    }
}
