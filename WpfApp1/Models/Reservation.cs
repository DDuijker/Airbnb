using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Reservation : INotifyPropertyChanged
    {
        private int _id;
        private Customer? _customer;
        private Property? _property;
        private int _amountOfDays;
        private int _epochArrival;
        private string _status;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                Notify("Id");
            }
        }

        public Customer? Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                Notify("Customer");
            }
        }

        public Property? Property
        {
            get { return _property; }
            set
            {
                _property = value;
                Notify("Property");
            }
        }

        public int AmountOfDays
        {
            get { return _amountOfDays; }
            set
            {
                _amountOfDays = value;
                Notify("AmountOfDays");
            }
        }

        public int EpochArrival
        {
            get { return _epochArrival; }
            set
            {
                _epochArrival = value;
                Notify("EpochArrival");
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                Notify("Status");
            }
        }

        public Reservation(
            int amountOfDays = 1,
            int epochArrival = 0,
            string status = "created"
        ) {
            this.AmountOfDays = amountOfDays;
            this.EpochArrival = epochArrival;
            this.Status = status;

            if (epochArrival == 0)
            {
                TimeSpan t = DateTime.UtcNow.Date - new DateTime(1970, 1, 1);
                this.EpochArrival = (int)t.TotalSeconds;
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void Notify(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
