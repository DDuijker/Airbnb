using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class PropertiesController : Controller
    {
        // GET: PropertiesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PropertiesController/Details/5
        public ActionResult Details(int id)
        {
            PropertyDetailsView vm = new PropertyDetailsView();
            AirBnbContext db = new AirBnbContext();
            vm.Load(db, id);
            return View(vm);
        }

        public ActionResult createReservation()
        {
           
            return View();
        }

        // GET: PropertiesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertiesController/Create
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
        //POST PropertiesController/createReservation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult createReservation(IFormCollection collection)
        {
            try
            {
             
                PropertyDetailsView vm = new PropertyDetailsView();
                AirBnbContext db = new AirBnbContext();
                vm.Store(db, collection);
                int lastReservationId = vm.Reservation.Id;
                return Redirect("/Reservations/Details/" + lastReservationId);
            }
            catch
            {
                return View();
            }
        }

        // GET: PropertiesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PropertiesController/Edit/5
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

        // GET: PropertiesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PropertiesController/Delete/5
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
