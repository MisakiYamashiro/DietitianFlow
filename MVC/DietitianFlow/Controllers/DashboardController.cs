
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DietitianFlowManuelMethods;
using DietitianFlow.Views.Dashboard;

namespace DietitianFlow.Controllers
{
    public class DashboardController : Controller
    {
        ManuelModel database = new ManuelModel();

        public ActionResult Index()
        {
            if (Session["Admin"] == null && Session["Dietitian"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            uc_Dietitian activeDietitian = Session["Admin"] != null
                ? (uc_Dietitian)Session["Admin"]
                : (uc_Dietitian)Session["Dietitian"];

            List<uc_Appointments> appointments = database.GetAppointments();
            List<uc_Patient> patients = database.GetPatients();
            DateTime datenow = DateTime.Now;

            DashboardViewModel model = new DashboardViewModel
            {
                AktifHastalar = 0,
                BekleyenRandevuSayisi = 0,
                YaklasanRandevular = 0,
                JsonLabels = "[]",
                JsonData = "[]"
            };

            if (activeDietitian != null)
            {
                if (appointments != null)
                {
                    model.BekleyenRandevuSayisi = appointments.Count(x =>
                        x.StartTime.HasValue &&
                        x.StartTime.Value > datenow &&
                        x.DietitianID == activeDietitian.DietitianID);

                    model.YaklasanRandevular = appointments.Count(x =>
                        x.StartTime.HasValue &&
                        x.StartTime.Value > datenow &&
                        x.StartTime.Value <= datenow.AddDays(7) &&
                        x.DietitianID == activeDietitian.DietitianID);

                    DateTime startDate = DateTime.Today.AddDays(-7);
                    DateTime endDate = DateTime.Today.AddDays(7);

                    var istatistik = appointments
                        .Where(x =>
                            x.StartTime.HasValue &&
                            x.StartTime.Value >= startDate &&
                            x.StartTime.Value <= endDate &&
                            x.DietitianID == activeDietitian.DietitianID)
                        .GroupBy(x => x.StartTime.Value.Date)
                        .Select(g => new
                        {
                            Tarih = g.Key,
                            Sayi = g.Count()
                        })
                        .OrderBy(x => x.Tarih)
                        .ToList();

                    if (istatistik.Any())
                    {
                        var labels = istatistik.Select(x => x.Tarih.ToString("dd.MM")).ToList(); 
                        var counts = istatistik.Select(x => x.Sayi).ToList();

                        model.JsonLabels = JsonConvert.SerializeObject(labels);
                        model.JsonData = JsonConvert.SerializeObject(counts);
                    }
                }

                if (patients != null)
                {
                    model.AktifHastalar = patients.Count(x =>
                        x.Active == true &&
                        x.DietitianID == activeDietitian.DietitianID);
                }
            }

            return View(model);
        }
    }
}