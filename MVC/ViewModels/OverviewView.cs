using MVC.Data;
using MVC.Models;

namespace MVC.ViewModels
{
    public class OverviewView
    {
        public List<Property> Properties { get; set; }

        public int ReservationCount { get; set; }
        public int PropertyCount { get; set; }
        public List<Reservation> Reservations { get; set; }
        public void Load(AirBnbContext db, int? id= null)
        {
            ReservationCount = db.Reservations.Count();
            /*Customers = db.Customers.Local.ToList();*/
            Reservations = db.Reservations.ToList();
            PropertyCount = db.Properties.Count();
            /*Customers = db.Customers.Local.ToList();*/
            Properties = db.Properties.ToList();



        }
        public OverviewView()
        {
            Reservations = new List<Reservation>();
            Properties = new List<Property>();

        }
    }
}
