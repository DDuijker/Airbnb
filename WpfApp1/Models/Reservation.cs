using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Reservation
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
            set { _id = value; }
        }

        public Customer? Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public Property? Property
        {
            get { return _property; }
            set { _property = value; }
        }

        public int AmountOfDays
        {
            get { return _amountOfDays; }
            set { _amountOfDays = value; }
        }

        public int EpochArrival
        {
            get { return _epochArrival; }
            set { _epochArrival = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Reservation(
            int amountOfDays = 1,
            int epochArrival = 0,
            string status = "created"
        ) {
            this.AmountOfDays = amountOfDays;
            this.EpochArrival = epochArrival;
            this.Status = status;
        }
    }
}
