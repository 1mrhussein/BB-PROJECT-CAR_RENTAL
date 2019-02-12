using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarRental.Data;
using CarRental.Models;

namespace CarRental.Controllers
{
    public class CarRentalCarsController : Controller
    {
        private CarRentalContext db = new CarRentalContext();

        // GET: CarRentalCars
        public ActionResult Index()
        {
            return View(db.CarRentalCars.ToList());
        }

        // GET: CarRentalCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRentalCar carRentalCar = db.CarRentalCars.Find(id);
            if (carRentalCar == null)
            {
                return HttpNotFound();
            }
            return View(carRentalCar);
        }

        // GET: CarRentalCars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarRentalCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarID,CarMake,CarModel,CarSize,CarIsAvailable,CarYear,CarPrice")] CarRentalCar carRentalCar)
        {
            if (ModelState.IsValid)
            {
                db.CarRentalCars.Add(carRentalCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carRentalCar);
        }

        // GET: CarRentalCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRentalCar carRentalCar = db.CarRentalCars.Find(id);
            if (carRentalCar == null)
            {
                return HttpNotFound();
            }
            return View(carRentalCar);
        }

        // POST: CarRentalCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarID,CarMake,CarModel,CarSize,CarIsAvailable,CarYear,CarPrice")] CarRentalCar carRentalCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carRentalCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carRentalCar);
        }

        // GET: CarRentalCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRentalCar carRentalCar = db.CarRentalCars.Find(id);
            if (carRentalCar == null)
            {
                return HttpNotFound();
            }
            return View(carRentalCar);
        }

        // POST: CarRentalCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarRentalCar carRentalCar = db.CarRentalCars.Find(id);
            db.CarRentalCars.Remove(carRentalCar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
