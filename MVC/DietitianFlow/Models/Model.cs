using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DietitianFlow.Models
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=DietitianFlowConnection")
        {
        }
        public DbSet<uc_Dietitian> Dietitians { get; set; }
        public DbSet<uc_Patient> Patients { get; set; }
        public DbSet<uc_BodyMeasurements> BodyMeasurements { get; set; }
        public DbSet<uc_Appointments> Appointments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
