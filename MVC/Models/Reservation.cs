using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models
{
    public enum ReservationStatus
    {
        Draft,
        Created,
        Pending,
        Confirmed,
        Cancelled,
        Paid,
        Waiting
    }

    public class Reservation : INotifyPropertyChanged
    {
        private int _id;
        private Customer? _customer;
        private Property? _property;
        private int _amountOfNights;
        private int _epochArrival;
        private int _epochLeave;
        private ReservationStatus _status;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                Notify("Id");
                Notify("Name");
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

        public int AmountOfNights
        {
            get { return _amountOfNights; }
            set
            {
                _amountOfNights = value;
                Notify("AmountOfNights");
                Notify("EpochLeave");
            }
        }

        public int EpochArrival
        {
            get { return _epochArrival; }
            set
            {
                _epochArrival = value;
                EpochLeave = EpochArrival + AmountOfNights * 86400;
                Notify("EpochArrival");
                Notify("DateString");
                Notify("Name");
            }
        }

        public ReservationStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                Notify("Status");
            }
        }

        public string DateString
        {
            get
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(EpochArrival);
                DateTime PickedDate = dateTimeOffset.DateTime;
                return PickedDate.ToString("yyyy-MM-dd");
            }
        }

        public int EpochLeave
        {
            get
            {
                return _epochLeave;
            }
            set
            {
                _epochLeave = value;
                Notify("EpochLeave");
            }
        }

        public string Name
        {
            get
            {
                return Id.ToString() + " - " + DateString;
            }
        }

        public Reservation(
            int amountOfNights = 0,
            int epochArrival = -1,
            ReservationStatus status = ReservationStatus.Draft
        ) {
            this.AmountOfNights = amountOfNights;
            this.EpochArrival = epochArrival;
            this.Status = status;

            if (epochArrival < 0)
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
