using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class BodyMeasurement
    {
        public int MeasurementId { get; set; }
        public int PatientId { get; set; }
        public int DietitianID { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public double BodyFatPercentage { get; set; }
        public double MuscleMassKg { get; set; }
        public double WaterPercentage { get; set; }
        public int VisceralFatLevel { get; set; } // Genelde 1-12 arası tam sayı olur
        public double WaistCircumference { get; set; }
        public double HipCircumference { get; set; }
        public string Notes { get; set; }
    }
}
