using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseAccess;
using Newtonsoft.Json;

namespace ParaAvcilariObezlerMerkezi
{
    public partial class Dashboard : System.Web.UI.Page
    {
        public string JsonLabels;
        Database database = new Database();
        public string JsonData;
        protected void Page_Load(object sender, EventArgs e)
        {
    //        if (!IsPostBack)
    //        {
    //            //if (Session["Admin"] == null)
    //            //{
    //            //    Response.Redirect("Login.aspx");
    //            //    return;
    //            //}
    //            Dietitian activeDietitian = (Dietitian)Session["Admin"];
    //            List<Appointment> appointments = database.GetAppointments();
    //            List<Patient> patients = database.GetPatients();

    //            DateTime datenow = DateTime.Now;
    //            int bekleyenRandevu = -1;
    //            int aktifHastalar = -1;
    //            int yaklasanRandevu = -1;
    //            if (appointments != null)
    //            {
    //                bekleyenRandevu = appointments.Count(x => x.Status == true && x.StartTime > datenow && x.DietitianId == activeDietitian.DietitianID);
    //                yaklasanRandevu = appointments.Count(x => x.Status
    //                && x.StartTime > DateTime.Now
    //                && x.StartTime <= DateTime.Now.AddDays(7)); yaklasanRandevu = appointments.Count(x => x.Status && x.StartTime > DateTime.Now && x.DietitianId == activeDietitian.DietitianID);
    //            }
    //            aktifHastalar = patients.Count(x => x.Active == true && x.DietitianID == activeDietitian.DietitianID);
    //            lbl_aktifhastalar.Text = aktifHastalar.ToString();
    //            lbl_bekleyenRandevuSayi.Text = bekleyenRandevu.ToString();
    //            lbl_yaklasanrandevular.Text = yaklasanRandevu.ToString();
    //            LoadChart();
    //        }
    //    }
    //    private void LoadChart()
    //    {
    //        JsonLabels = "[]";
    //        JsonData = "[]";

    //        List<Appointment> appointments = database.GetAppointments();

    //        if (appointments != null && appointments.Count > 0)
    //        {
    //            var istatistik = appointments
    //                .Where(x =>
    //                    x.Status == true &&
    //                    x.StartTime >= DateTime.Today
    //                )
    //                .GroupBy(x => x.StartTime.Date)
    //                .Select(g => new
    //                {
    //                    Tarih = g.Key,
    //                    Sayi = g.Count()
    //                })
    //                .OrderBy(x => x.Tarih)
    //                .ToList();

    //            var labels = istatistik.Select(x => x.Tarih.ToString("dd.MM.yyyy")).ToList();
    //            var counts = istatistik.Select(x => x.Sayi).ToList();
    //            JsonLabels = JsonConvert.SerializeObject(labels);
    //            JsonData = JsonConvert.SerializeObject(counts);
    //        }
        }
    }
}