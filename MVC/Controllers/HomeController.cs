using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;
using MVC.Data;
using System.Collections.ObjectModel;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private ObservableCollection<Reservation> _reservations;
        public IActionResult Index()
        {
        /*    Customer customer = new Customer();
            customer.FirstName = "Hi";
            customer.LastName = "bye";
            using( var db = new AirBnbContext())
            {
            db.Add(customer);
            db.SaveChanges();
            }*/
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Overview(string? id, string? category)
        {
            OverviewView vm = new OverviewView();
            AirBnbContext db = new AirBnbContext();
            vm.Load(db);
          
                vm.Sort(attribute: category, metric: id);
            
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}