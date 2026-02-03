using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveXDataObjects
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int DietitianId { get; set; }
        public int PatientId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; } // Örn: "Active", "Cancelled", "Completed"
        public string Type { get; set; } // Örn: "Online", "FaceToFace"
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    }
}
