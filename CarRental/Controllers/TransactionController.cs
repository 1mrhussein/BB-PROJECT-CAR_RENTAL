using CarRental.Models.CustomerModels;
using CarRental.Models.TransactionModels;
using CarRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            var service = new ServicesTransaction();
            var model = service.SGListTransaction();

            var carService = new ServicesCar();
            var cModLis = carService.SGetListAvalailableCars();
            ViewBag.CarID = new SelectList(cModLis, "CarID", "CarModel");

            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            // Available Cars Drop Down List
            var carService = new ServicesCar();
            var carLis = carService.SGetListAvalailableCars();

            ViewBag.CarID = new SelectList(carLis, "CarID", "CarMake");

            // Customer Drop Down List
            var customerService = new ServicesCustomer();
            var customerList = customerService.SGetListCustomer();

            ViewBag.CustomerID = new SelectList(customerList, "CustomerID", "CustomerName");
            
            return View();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(ModelTransactionCreate model)
        {
            //if (!ModelState.IsValid) return View();            
            if (!ModelState.IsValid) return RedirectToAction("Create");

            var service = new ServicesTransaction();
            if (service.STransactionCreate(model))
            {
                TempData["SaveTransaction"] = "Your transaction has been added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Car could not be added!");
            return View(model);
        }

        // GET: Transaction/Details/{id}
        public ActionResult Details(int id)
        {
            var service = new ServicesTransaction();
            var model = service.SGetTransactionById(id);

            return View(model);
        }

        // GET: Transaction/Edit/{id}
        public ActionResult Edit(int id)
        {
            var sercive = new ServicesTransaction();
            var details = sercive.SGetTransactionById(id);

            var model = new ModelTransactionEdit()
            {
                PickUpDate = details.PickUpDate,
                RetunrDate = details.RetunrDate,
                RentalAmount=details.RentalAmount,
                CarID=details.CarID
            };

            return View(model);
        }

        // POST: Transaction/Edit{id}
        [HttpPost]
        public ActionResult Edit(int id, ModelTransactionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TransID != id)
            {
                ModelState.AddModelError("", "Id mismatch!");
                return View(model);
            }

            var service = new ServicesTransaction();

            if (service.STransactionUpdate(model))
            {
                TempData["SaveResult"] = "Your transaction was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your transaction could not be updated");
            return View(model);
        }

        //GET: Transaction/Delete{id}
        public ActionResult Delete(int id)
        {
            var service = new ServicesTransaction();
            var model = service.SGetTransactionById(id);

            return View(model);
        }

        //POST: Transaction/Delete{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new ServicesTransaction();
            var model = service.STransactionDelete(id);

            TempData["SaveResult"] = "Your transaction was deleted";

            return RedirectToAction("Index");
        }
    }
}