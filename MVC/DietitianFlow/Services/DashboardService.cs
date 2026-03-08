
using DietitianFlow.Views.Dashboard;
using DietitianFlowManuelMethods;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DietitianFlow.Services
{
    public class DashboardService
    {
        private readonly ManuelModel _model;

        public DashboardService()
        {
            _model = new ManuelModel();
        }

        public DashboardViewModel BuildDashboard(int dietitianId)
        {
            List<uc_Appointments> appointments = _model.GetAppointments();
            List<uc_Patient> patients = _model.GetPatients();

            DateTime now = DateTime.Now;

            DashboardViewModel model = new DashboardViewModel
            {
                AktifHastalar = 0,
                BekleyenRandevuSayisi = 0,
                YaklasanRandevular = 0,
                JsonLabels = "[]",
                JsonData = "[]"
            };

            if (appointments != null)
            {
                model.BekleyenRandevuSayisi = appointments.Count(x =>
                    x.StartTime.HasValue &&
                    x.StartTime.Value > now &&
                    x.DietitianID == dietitianId);

                model.YaklasanRandevular = appointments.Count(x =>
                    x.StartTime.HasValue &&
                    x.StartTime.Value > now &&
                    x.StartTime.Value <= now.AddDays(7) &&
                    x.DietitianID == dietitianId);

                DateTime startDate = DateTime.Today.AddDays(-7);
                DateTime endDate = DateTime.Today.AddDays(7);

                var statistics = appointments
                    .Where(x =>
                        x.StartTime.HasValue &&
                        x.StartTime.Value >= startDate &&
                        x.StartTime.Value <= endDate &&
                        x.DietitianID == dietitianId)
                    .GroupBy(x => x.StartTime.Value.Date)
                    .Select(g => new
                    {
                        Tarih = g.Key,
                        Sayi = g.Count()
                    })
                    .OrderBy(x => x.Tarih)
                    .ToList();

                if (statistics.Any())
                {
                    var labels = statistics.Select(x => x.Tarih.ToString("dd.MM")).ToList();
                    var counts = statistics.Select(x => x.Sayi).ToList();

                    model.JsonLabels = JsonConvert.SerializeObject(labels);
                    model.JsonData = JsonConvert.SerializeObject(counts);
                }
            }

            if (patients != null)
            {
                model.AktifHastalar = patients.Count(x =>
                    x.Active == true &&
                    x.DietitianID == dietitianId);
            }

            return model;
        }
    }
}