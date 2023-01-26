using MVC.Data;
using MVC.Models;
using System.Linq;

namespace MVC.ViewModels
{
   public class PropertyDetailsView
   {
      public Property Property { get; set; }
      public Customer Customer { get; set; }
      public Reservation Reservation { get; set; }
      public DateTime PickedDate { get; set; }
      public void Load(AirBnbContext db, int id)
      {
         Property = db.Properties.Where(c => c.Id == id).First();
      }

      public void Store(AirBnbContext db, IFormCollection collection)
      {
         PickedDate = DateTime.Parse(collection["EpochArrival"]);
         Property = db.Properties.Where(p => p.Id == Convert.ToInt32(collection["PropertyId"])).First();
         Customer = new Customer(collection["FirstName"], collection["LastName"], collection["Email"], collection["PhoneNumber"]);
         db.Customers.Add(Customer);
         db.SaveChanges();
         int lastId = Customer.Id;

         /*TimeSpan t = new DateTime(collection["EpochArrival"]);*/
         TimeSpan t = PickedDate - new DateTime(1970, 1, 1);

         Reservation = new Reservation();
         Reservation.EpochArrival = (int)t.TotalSeconds;
         Reservation.Customer = Customer;
         Reservation.Property = Property;
         Reservation.AmountOfNights = Convert.ToInt32(collection["AmountOfNights"]);
         Reservation.EpochLeave = (int)t.TotalSeconds + (Reservation.AmountOfNights * 86400);
         db.Reservations.Add(Reservation);
         db.SaveChanges();


      }

      public PropertyDetailsView()
      {


      }
   }
}
