using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to my car rental application. I am Mohamed Hussein, a Software Developer";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "If you have questions please contact.";
            return View();
        }
    }
}