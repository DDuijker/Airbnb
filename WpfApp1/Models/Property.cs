using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApp1.Models
{
    public class Property : INotifyPropertyChanged
    {

        private int _id;
        private string _address;
        private string _city;
        private string _zip;
        private string _country;
        private double _price;
        private int _numberOfRooms;
        private int _numberOfBeds;
        private int _numberOfBathrooms;
        private string _description;
        private string _type;
        private string _title;
        private Landlord? _landlord;
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

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                Notify("Address");
            }
        }

        public string City
        { 
            get { return _city; }
            set
            {
                _city = value;
                Notify("City");
            }
        }

        public string Zip
        {
            get { return _zip; }
            set
            {
                _zip = value;
                Notify("Zip");
            }
        }

        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                Notify("Country");
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                Notify("Price");
            }
        }

        public int NumberOfRooms
        {
            get { return _numberOfRooms; }
            set
            {
                _numberOfRooms = value;
                Notify("NumberOfRooms");
            }
        }

        public int NumberOfBeds
        {
            get { return _numberOfBeds; }
            set
            {
                _numberOfBeds = value;
                Notify("NumberOfBeds");
            }
        }

        public int NumberOfBathrooms
        {
            get { return _numberOfBathrooms; }
            set
            {
                _numberOfBathrooms = value;
                Notify("NumberOfBathrooms");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                Notify("Description");
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                Notify("Type");
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                Notify("Title");
            }
        }

        public Landlord? Landlord
        {
            get { return _landlord; }
            set
            {
                _landlord = value;
                Notify("Landlord");
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


        public Property(
            string address = "---", 
            string city = "---", 
            string zip = "---", 
            string country = "---", 
            double price = 0.00, 
            int numberOfRooms = 0, 
            int numberOfBeds = 0, 
            int numberOfBathrooms = 0, 
            string description = "---", 
            string type = "---", 
            string title = "---")
        {
            this.Address = address;
            this.City = city;
            this.Zip = zip;
            this.Country = country;
            this.Price = price;
            this.NumberOfRooms = numberOfRooms;
            this.NumberOfBeds = numberOfBeds;
            this.NumberOfBathrooms = numberOfBathrooms;
            this.Description = description;
            this.Type = type;
            this.Title = title;
            this.Reservations = new();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void Notify(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
