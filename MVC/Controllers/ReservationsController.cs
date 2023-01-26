using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.ViewModels;

namespace MVC.Controllers
{
   public class ReservationsController : Controller
   {
      // GET: ReservationsController
      public ActionResult Index()
      {
         ReservationView vm = new ReservationView();
         AirBnbContext db = new AirBnbContext();
         vm.Load(db);
         return View(vm);
      }
      // GET: ReservationsController/Details/5
      public ActionResult Details(int id)
      {
         ReservationView vm = new ReservationView();
         AirBnbContext db = new AirBnbContext();
         vm.Load(db, id);
         return View(vm);
      }

      // GET: ReservationsController/Create
      public ActionResult Create()
      {
         return View();
      }

      // POST: ReservationsController/Create
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create(IFormCollection collection)
      {
         try
         {
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }

      // GET: ReservationsController/Edit/5
      public ActionResult Edit(int id)
      {
         return View();
      }

      // POST: ReservationsController/Edit/5
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit(int id, IFormCollection collection)
      {
         try
         {
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }

      // GET: ReservationsController/Delete/5
      public ActionResult Delete(int id)
      {
         return View();
      }

      // POST: ReservationsController/Delete/5
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Delete(int id, IFormCollection collection)
      {
         try
         {
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }
   }
}
