using DietitianFlowManuelMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DietitianFlow.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Patients()
        {
            var model = new ManuelModel();
            if (Session["Admin"] == null && Session["Dietitian"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            uc_Dietitian csession = (uc_Dietitian)(Session["Admin"] ?? Session["Dietitian"]);
            List<uc_Patient> _Patients = model.GetPatients(csession.DietitianID).Where(x=> x.Active == true).ToList();
            return View(_Patients);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Patients");

            var model = new ManuelModel();
            var app = model.GetPatient(id.Value);

            if (app == null)
                return HttpNotFound();

            return View(app);
        }
    }
}