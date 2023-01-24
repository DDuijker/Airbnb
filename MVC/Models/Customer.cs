

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVC.Models
{
    public class Customer : INotifyPropertyChanged
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
            set 
            { 
                _id = value;
                Notify("Id");
            }
        }

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
                _lastName = value;
                Notify("LastName");
                Notify("FullName");
            }
        }

        public string Email
        {
            get { return _email; }
            set 
            { 
                _email = value;
                Notify("Email");
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set 
            { 
                _phoneNumber = value;
                Notify("PhoneNumber");
            }
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
            set 
            { 
                _reservations = value;
                Notify("Reservations");
            }
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


        public event PropertyChangedEventHandler? PropertyChanged;
        public void Notify(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
