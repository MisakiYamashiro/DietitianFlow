using DietitianFlowManuelMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DietitianFlow.Controllers
{
    public class AppointmentsController : Controller
    {
        // GET: Appointments
        public ActionResult Appointments()
        {
            var model = new ManuelModel();
            if (Session["Admin"] == null && Session["Dietitian"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            uc_Dietitian csession = (uc_Dietitian)(Session["Admin"] ?? Session["Dietitian"]);
            List<uc_Appointments> _Appointments = model.GetAppointments(csession.DietitianID);

            return View(_Appointments);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Appointments");

            var model = new ManuelModel();
            var app = model.GetAppointment(id.Value);

            if (app == null)
                return HttpNotFound();

            return View(app);
        }
    }
}