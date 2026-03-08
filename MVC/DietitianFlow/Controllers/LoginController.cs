
using DietitianFlow.Filters;
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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            //TEMP
            if (email == "dev@dev.com")
            {
                uc_Dietitian tempdata = mdb.GetDietitian(email);
                Session["Admin"] = tempdata;
                return RedirectToAction("Index", "Dashboard");
            }
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
               return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }
            
        }
    }
}