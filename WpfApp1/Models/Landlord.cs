using System.Collections.ObjectModel;

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
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
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
    }
}
