using MVC.Data;
using MVC.Models;

namespace MVC.ViewModels
{
    public class CustomersView
    {
        public Customer Customer { get; set; }
        public int CustomerAmount { get; set; }
        public List<Customer> Customers { get; set; }
        public void Load(AirBnbContext db, int? id= null)
        {
            CustomerAmount = db.Customers.Count();
            Customers = db.Customers.Where(c => c.Id == id).ToList();
            Customer = db.Customers.Where(c => c.FirstName == "Hi").FirstOrDefault<Customer>();


        }
        public CustomersView()
        {
            Customers = new List<Customer>();
            
        }
    }
}
