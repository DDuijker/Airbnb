using System.ComponentModel;

namespace AirBnB.Model
{
    public class Landlord : INotifyPropertyChanged
    {
        static int ID = 0;

        /// Make variables for a landlord
        private int _landlordID = ID;
        private string _firstName;
        private string _lastName;
        private string _email;
        private int _phoneNumber;
        private string _address;
        private string _city;
        private string _zipCode;
        private string _country;



        public int LandlordID { get { return _landlordID; } set { _landlordID = value; } }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                Notify("FirstName");
                Notify("FullName");
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value; Notify("LastName");
                Notify("FullName");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value; Notify("Email");
            }
        }
        public int PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                Notify("PhoneNumber");
            }
        }
        public string Address { get { return _address; } set { _address = value; Notify("Adress"); } }
        public string City { get { return _city; } set { _city = value; Notify("City"); } }
        public string ZipCode { get { return _zipCode; } set { _zipCode = value; Notify("Zipcode"); } }
        public string Country { get { return _country; } set { _country = value; Notify("Country"); } }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }


        }

        public Landlord(string firstName,
                        string lastName,
                        string email,
                        int phoneNumber,
                        string address,
                        string city,
                        string zipCode,
                        string country
                        )
        {
            ID++;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.City = city;
            this.ZipCode = zipCode;
            this.Country = country;
        }

        private void Notify(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
