using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.ViewModels;
namespace MVC.Controllers
{
   public class CustomersController : Controller
   {
      // GET: CustomersController
      public ActionResult Index()
      {
         CustomersView vm = new CustomersView();
         AirBnbContext db = new AirBnbContext();
         vm.Load(db);
         return View(vm);
      }

      // GET: CustomersController/Details/5
      public ActionResult Details(int id)
      {
         CustomersView vm = new CustomersView();
         AirBnbContext db = new AirBnbContext();
         vm.Load(db, id);
         return View(vm);
      }
   }
}
