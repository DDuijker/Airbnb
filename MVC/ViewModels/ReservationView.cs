using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using NuGet.Packaging.Signing;
using System.Linq;

namespace MVC.ViewModels
{
   public class ReservationView
   {
      public Reservation Reservation { get; set; }
      public List<Reservation> Reservations { get; set; }
      public string DateTime { get; set; }

      public void Load(AirBnbContext db, int? id = null)
      {
         if (id != null)
         {
            Reservation = db.Reservations.Include("Customer").Include("Property").Where(c => c.Id == id).First();
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, 0); //from start epoch time
            start = start.AddSeconds(Reservation.EpochArrival);
            DateTime = start.ToString("yyyy-MM-dd");
         }
         else
         {
            Reservations = db.Reservations.Include("Customer").Include("Property").ToList();
            Console.WriteLine(Reservations);
         }

      }

   }
}
