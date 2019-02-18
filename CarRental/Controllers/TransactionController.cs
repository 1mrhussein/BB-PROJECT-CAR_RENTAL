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
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            var service = new ServicesTransaction();
            var model = service.SGListTransaction();
            
            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            //Car Drop Down List
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
            if (!ModelState.IsValid) return  RedirectToAction("Create");

            var service = new ServicesTransaction();
            if (service.STransactionCreate(model))
            {
                return RedirectToAction("Index"/*,""*/);
            }

            ModelState.AddModelError("", "Car could not be added!");
            return View(model);
        }
    }
}