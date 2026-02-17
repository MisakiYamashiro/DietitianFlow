using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DietitianFlow.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            if (Session["Admin"] == null && Session["Dietitian"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
    }
}