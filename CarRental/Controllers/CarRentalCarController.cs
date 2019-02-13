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
    public class CarRentalCarController : Controller
    {
        // GET: CarRentalCar
        public ActionResult Index()
        {
            var service = new CarServices();
            var model = service.GetCarList();
            return View(model);
        }

        // GET: CarRentalCar/Create----view for list of cars
        public ActionResult Create()
        {
            return View();
        }
        // POST: CarRentalCar/Create----Create post on the view
        [HttpPost]
        public ActionResult Create(CarCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new CarServices();
            if (service.CreateCarRentalCar(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Car could not be added!");
            return View(model);
        }
    }
}