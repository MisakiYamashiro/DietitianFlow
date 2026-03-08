using DietitianFlow.Filters;
using DietitianFlowManuelMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DietitianFlow.Services
{
    [AdminAuthentication]
    public class PatientService
    {
        private readonly ManuelModel model;
        public PatientService()
        {
            model = new ManuelModel();
        }
        public List<uc_Patient> GetPatients(int dietitianID)
        {
            return model.GetPatients(dietitianID);
        }
        public List<uc_Patient> GetPatients()
        {
            return model.GetPatients();
        }
        public uc_Patient GetPatient(int ID)
        {
            return model.GetPatient(ID);
        }
        public (double startingBmi, double targetBmi, double bmi) CalculateBMIs(uc_Patient app)
        {
            double? starting_bmi = null;
            double? target_bmi = null;
            double? bmi = null;

            if (app.Height.HasValue && app.Height.Value > 0)
            {
                var meter = app.Height.Value / 100.0;
                var heightSquared = meter * meter;

                if (app.StartingWeight.HasValue)
                    starting_bmi = app.StartingWeight.Value / heightSquared;
                else
                    return (-1, -1, -1);

                if (app.TargetWeight.HasValue)
                    target_bmi = app.TargetWeight.Value / heightSquared;
                else
                    return (-1, -1, -1);

                if (app.Weight.HasValue)
                    bmi = app.Weight.Value / heightSquared;
                else
                    return (-1, -1, -1);
            }

            return (starting_bmi ?? -1, target_bmi ?? -1, bmi ?? -1);
        }
    }
}