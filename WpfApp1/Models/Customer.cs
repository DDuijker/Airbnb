

using System.Collections.ObjectModel;

namespace WpfApp1.Models
{
    public class Customer
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private ObservableCollection<Reservation> _reservations;

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

        public string FullName
        {
            get
            {
                return _firstName + " " + _lastName;
            }
        }

        public ObservableCollection<Reservation> Reservations
        {
            get { return _reservations; }
            set { _reservations = value; }
        }

        public Customer(
            string firstName = "---",
            string lastName = "---",
            string email = "---",
            string phoneNumber = "---"
        ) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Reservations = new();
        }
    }
}
