using DietitianFlow.Filters;
using DietitianFlowManuelMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DietitianFlow.Services
{
    [AdminAuthentication]
    public class AppointmentService
    {
        private readonly ManuelModel model;
        public AppointmentService()
        {
            model = new ManuelModel();
        }

        public List<uc_Appointments> GetAppointments(int dietitianID)
        {
            return model.GetAppointments(dietitianID);
        }
        public List<uc_Appointments> GetAppointments()
        {
            return model.GetAppointments();
        }
        public uc_Appointments GetAppointment(int PatientID)
        {
            return model.GetAppointment(PatientID);
        }
        public bool CreateAppointment(uc_Appointments aasd)
        {
            return model.CreateAppointment(aasd);
        }
    }
}