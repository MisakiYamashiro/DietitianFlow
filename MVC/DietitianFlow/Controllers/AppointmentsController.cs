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
    public class AppointmentsController : Controller
    {
        private readonly AppointmentService _appointmentService;
        public AppointmentsController()
        {
            _appointmentService = new AppointmentService();
        }
        // GET: Appointments
        public ActionResult Appointments()
        {
            var ActiveDietitian = SessionHelper.GetActiveDietitian(Session);
            List<uc_Appointments> _Appointments = _appointmentService.GetAppointments(ActiveDietitian.DietitianID);
            
            return View(_Appointments);
        }
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Appointments");

            var app = _appointmentService.GetAppointment(id.Value);

            if (app == null)
                return HttpNotFound();

            return View(app);
        }
    }
}