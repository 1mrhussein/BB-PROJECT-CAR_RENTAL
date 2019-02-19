using CarRental.Data;
using CarRental.Models.CarModels;
using CarRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            var service = new ServicesCar();
            var model = service.SGetListCar();
            return View(model);
        }

        // GET: Car/Create----view for list of cars
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create----Create post on the view
        [HttpPost]
        public ActionResult Create(ModelCarCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new ServicesCar();
            if (service.SCarCreate(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Car could not be added!");
            return View(model);
        }


        //GET: Car/Detail/{id}
        public ActionResult Details(int Id)
        {
            var service = new ServicesCar();
            var model = service.SGetCarById(Id);

            return View(model);
        }

        //GET: Car/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = new ServicesCar();
            var details = service.SGetCarById(id);

            var model = new ModelCarEdit
            {
                CarID = details.CarID,
                CarMake = details.CarMake,
                CarModel = details.CarModel,
                CarSize = details.CarSize,
                CarYear = details.CarYear,
                CarPrice = details.CarPrice,
                CarIsAvailable=details.CarIsAvailable
            };

            return View(model);
        }

        //POST: Car/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ModelCarEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CarID != id)
            {
                ModelState.AddModelError("", "Id Mismatch!");
                return View(model);
            }

            var service = new ServicesCar();

            if (service.SCarUpdate(model))
            {
                TempData["SaveResult"] = "Your car was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your car could not be updated");
            return View(model);
        }

        //GET: Car/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new ServicesCar();
            var model = service.SGetCarById(id);

            return View(model);
        }

        //POST: Car/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new ServicesCar();
            var model = service.SCarDelete(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
    }
}