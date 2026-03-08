using DietitianFlow.Filters;
using DietitianFlow.Helpers;
using DietitianFlow.Services;
using DietitianFlowManuelMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DietitianFlow.Controllers
{
    [AdminAuthentication]
    public class PatientController : Controller
    {
        private readonly PatientService _patientService;
        // GET: Patient
        public PatientController()
        {
            _patientService = new PatientService();
        }
        public ActionResult Patients()
        {
            var csession = SessionHelper.GetActiveDietitian(Session);
            List<uc_Patient> _Patients = _patientService.GetPatients(csession.DietitianID).Where(x => x.Active == true).ToList();
            return PartialView(_Patients);
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Patients");

            var app = _patientService.GetPatient(id.Value);

            if (app == null)
                return HttpNotFound();

            var bmis = _patientService.CalculateBMIs(app);

            ViewBag.StartingBMI = bmis.startingBmi;
            ViewBag.TargetBMI = bmis.targetBmi;
            ViewBag.CurrentBMI = bmis.bmi;

            return View(app);
        }
    }
}