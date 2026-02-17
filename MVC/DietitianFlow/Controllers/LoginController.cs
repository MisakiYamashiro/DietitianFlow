using DietitianFlow.Models;
using DietitianFlowManuelMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DietitianFlow.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ManuelModel mdb = new ManuelModel();
        Model db = new Model();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            uc_Dietitian dietitian = mdb.Login(password,email);
            if (dietitian != null)
            {
                if (dietitian.Degree == "Admin")
                {
                    Session["Admin"] = dietitian;
                }
                else
                {
                    Session["Dietitian"] = dietitian;
                }
               return RedirectToAction("Index", "Main");
            }
            else
            {
                return View();
            }
            
        }
    }
}