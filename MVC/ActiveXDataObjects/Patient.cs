using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveXDataObjects
{
    public class Patient
    {
        public int PatientID { get; set; }
        public int DietitianID { get; set; } // Diyetisyen ile ilişki
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string GovernmentIDNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public double Height { get; set; } // cm veya m cinsinden
        public double StartingWeight { get; set; }
        public double TargetWeight { get; set; }
        public double Weight { get; set; } // Güncel kilo
        public string BloodGroup { get; set; }
        public string TargetDescription { get; set; }
        public string Allergies { get; set; }
        public string Diseases { get; set; }
        public string UsingMeds { get; set; }
        public string OperationHistory { get; set; }
        public bool IsSmoking { get; set; } // 'Smoking?' sütunu için
        public string IsSmokingStr { get; set; }
        public string PhysicalActivity { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime SystemSignDate { get; set; }
        public string Case { get; set; }
        public string Notes { get; set; }
        public DateTime LastSessionDate { get; set; }

        public bool Active { get; set; }
    }
}
