using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Landlord
    {

        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private string _address;
        private string _city;
        private string _zip;
        private string _country;
        private ObservableCollection<Property> _properties;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { 
                _firstName = value;
                Notify("FirstName");
                Notify("FullName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set { 
                _lastName = value;
                Notify("LastName");
                Notify("FullName");
            }
        }

        public string Email
        {
            get { return _email; }
            set { 
                _email = value;
                Notify("Email");
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { 
                _phoneNumber = value;
                Notify("PhoneNumber");
            }
        }

        public string Address
        {
            get { return _address; }
            set { 
                _address = value;
                Notify("Address");
            }
        }

        public string City
        {
            get { return _city; }
            set { 
                _city = value;
                Notify("City");
            }
        }

        public string Zip
        {
            get { return _zip; }
            set { 
                _zip = value;
                Notify("Zip");
            }
        }

        public string Country
        {
            get { return _country; }
            set { 
                _country = value;
                Notify("Country");
            }
        }

        public string FullName
        {
            get
            {
                return _firstName + " " + _lastName;
            }
        }

        public ObservableCollection<Property> Properties 
        { 
            get { return _properties; }
            set { _properties = value; } 
        }


        public Landlord(
            string firstName = "---", 
            string lastName = "---", 
            string email = "---", 
            string phoneNumber = "---", 
            string address = "---", 
            string city = "---", 
            string zip = "---", 
            string country = "---")
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.City = city;
            this.Zip = zip;
            this.Country = country;
            this.Properties = new();
        }

        private void Notify(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
