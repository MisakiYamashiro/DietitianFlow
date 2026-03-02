using DietitianFlowManuelMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DietitianFlow.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        ManuelModel model = new ManuelModel();
        public ActionResult DietitiansIndex()
        {
            
            List<uc_Dietitian> dietitians = model.GetDietitians();
            return View(dietitians);
        }
        
    }
}