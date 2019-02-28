using System.Data;
using CarRental.Models.CustomerModels;
using CarRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    [Authorize]     // To let access for only logged in users
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var service = new ServicesCustomer();
            var model = service.SGetListCustomer();
            return View(model);
        }

        //GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModelCustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new ServicesCustomer();

            if (service.SCustomerCreate(model))
            {
                TempData["SaveCustomer"] = "A customer has been added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(" ", "Customer could not be added!, Check customer age >18");
            return View(model);
        }

        //GET: Customer/Detail{id}
        public ActionResult Details(int id)
        {
            var service = new ServicesCustomer();
            var model = service.SGetCustomerById(id);

            return View(model);
        }

        //GET: Customer/Edit{id}
        public ActionResult Edit(int id)
        {
            var service = new ServicesCustomer();
            var details = service.SGetCustomerById(id);

            var model = new ModelCustomerEdit()
            {
                CustomerID = details.CustomerID,
                CustomerName= details.CustomerName,
                CustomerPhone= details.CustomerPhone,
                CustomerAddress= details.CustomerAddress,
                CustomerLiscenceNo= details.CustomerLiscenceNo

            };

            return View(model);
        }

        //POST: Customer/Edit{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ModelCustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerID !=id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            var service = new ServicesCustomer();

            if (service.SCustomerUpdate(model))
            {
                TempData["SaveResult"] = "Your customer was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your customer could not updated");
            return View(model);
        }

        // GET: Delete
        public ActionResult Delete(int id)
        {
            var service = new ServicesCustomer();
            var model = service.SGetCustomerById(id);

            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = new ServicesCustomer();
            var model = service.SCustomerDelete(id);

            TempData["SaveResult"] = "Customer was deleted";

            return RedirectToAction("Index");
        }
    }
}