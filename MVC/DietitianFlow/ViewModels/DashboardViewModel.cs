using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DietitianFlow.Views.Dashboard
{
    public class DashboardViewModel
    {
        public int AktifHastalar { get; set; }
        public int BekleyenRandevuSayisi { get; set; }
        public int YaklasanRandevular { get; set; }
        public string JsonLabels { get; set; }
        public string JsonData { get; set; }
    }
}