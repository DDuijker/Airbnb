using System.Collections.ObjectModel;

namespace WpfApp1.Models
{
    public class Property
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
            set { _id = value; }
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

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int NumberOfRooms
        {
            get { return _numberOfRooms; }
            set { _numberOfRooms = value; }
        }

        public int NumberOfBeds
        {
            get { return _numberOfBeds; }
            set { _numberOfBeds = value; }
        }

        public int NumberOfBathrooms
        {
            get { return _numberOfBathrooms; }
            set { _numberOfBathrooms = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public Landlord? Landlord
        {
            get { return _landlord; }
            set { _landlord = value; }
        }

        public ObservableCollection<Reservation> Reservations
        {
            get { return _reservations; }
            set { _reservations = value; }
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
    }
}
