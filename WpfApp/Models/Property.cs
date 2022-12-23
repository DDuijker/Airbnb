﻿using System.ComponentModel;

namespace AirBnB.Models
{
    public class Property : INotifyPropertyChanged
    {
        static int ID = 0;

        // Make variables for a property
        private static int _propertyID = ID;
        private string _address;
        private string _city;
        private string _zipCode;
        private string _country;
        private double _price;
        private int _numberOfRooms;
        private int _numberOfBeds;
        private int _numberOfBathrooms;
        private string _description;
        private string _type;
        private string _title;

        public int PropertyID { 
            get { return _propertyID; } 
            set { 
                _propertyID = value; 
            } 
        }
        public string Address { 
            get { return _address; } 
            set { 
                _address = value; 
                Notify("Address"); 
            } 
        }
        public string City { 
            get { return _city; } 
            set { 
                _city = value; 
                Notify("City"); 
            } 
        }
        public string ZipCode { 
            get { return _zipCode; } 
            set { 
                _zipCode = value; 
                Notify("ZipCode"); 
            }
        }
        public string Country { 
            get { return _country; } 
            set { 
                _country = value; 
                Notify("Country"); 
            } 
        }
        public double Price { 
            get { return _price; } 
            set { 
                _price = value; 
                Notify("Price"); 
            }
        }
        public int NumberOfRooms { 
            get { return _numberOfRooms; } 
            set { 
                _numberOfRooms = value; 
                Notify("NumberOfRooms");
            } 
        }
        public int NumberOfBeds { 
            get { return _numberOfBeds; } 
            set { 
                _numberOfBeds = value; 
                Notify("NumberOfBeds"); 
            } 
        }
        public int NumberOfBathrooms { 
            get { return _numberOfBathrooms; } 
            set { 
                _numberOfBathrooms = value; 
                Notify("NumberOfBathrooms"); 
            } 
        }
        public string Description { 
            get { return _description; } 
            set { 
                _description = value; 
                Notify("Description"); 
            } 
        }
        public string Type { 
            get { return _type; } 
            set { 
                _type = value; Notify("Type"); 
            } 
        }
        public string Title { 
            get { return _title; } 
            set { 
                _title = value; 
                Notify("Title");
            } 
        }

        public int LandlordID { get; set; }

        public Property(
            string address,
            string city,
            string country,
            string zipCode,
            double price,
            int numberOfRooms,
            int numberOfBeds,
            int numberOfBathrooms,
            string description,
            string type,
            string title
        )
        {
            ID++;
            this.PropertyID = ID;
            this.Address = address;
            this.City = city;
            this.Country = country;
            this.ZipCode = zipCode;
            this.Price = price;
            this.NumberOfRooms = numberOfRooms;
            this.NumberOfBeds = numberOfBeds;
            this.NumberOfBathrooms = numberOfBathrooms;
            this.Description = description;
            this.Type = type;
            this.Title = title;

            

        }

        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
