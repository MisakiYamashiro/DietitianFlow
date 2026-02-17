namespace DietitianFlow.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DietitianFlow.Models.Model>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DietitianFlow.Models.Model context)
        {
            #region İlk Eklemeler
            //context.Dietitians.AddOrUpdate(new Dietitian()
            //{
            //    DietitianID = 1,
            //    Name = "Burcu",
            //    Lastname = "Özdemir",
            //    BirthDate = new DateTime(1993, 4, 12),
            //    Salary = 55000.00m,
            //    SessionFee = 2000.00m,
            //    IBANumber = "TR56000610012345678901234567",
            //    PhotoBinaryFormat = null,
            //    JsonBinaryFormat = null,
            //    GovernmentIDNumber = "22222222222",
            //    Sex = "Kadın",
            //    Degree = "Yüksek Diyetisyen",
            //    GraduatedUniversityName = "Marmara Üniversitesi",
            //    Email = "burcu.ozdemir@diet.com",
            //    PhoneNumber = "05321234567",
            //    Address = "Nişantaşı Mah. Valikonağı Cad.",
            //    City = "İstanbul",
            //    District = "Şişli",
            //    Password_Hash = "$2a$11$BfirA/QPYO02P.EDO1zVoOwfvLZbZX/otir5LJMkVLSSZlj7Pammy", 
            //    ActiveEmployee = true,
            //    LastLoginDatetime = new DateTime(2026, 1, 24, 12, 1, 18, 767),
            //    ShiftStartTime = new TimeSpan(08, 30, 00),
            //    ShiftEndTime = new TimeSpan(17, 30, 00)
            //}

            //);
            //context.Appointments.AddOrUpdate(new Appointments()
            //{
            //    AppointmentId = 1,
            //    DietitianId = 1,
            //    PatientId = 1,
            //    StartTime = new DateTime(2023, 12, 1, 14, 0, 0),
            //    EndTime = new DateTime(2023, 12, 1, 15, 0, 0),
            //    Status = true,
            //    Type = "FaceToFace",
            //    Notes = "İlk kontrol randevusu."
            //});

            //context.Patients.AddOrUpdate(new Patient()
            //{
            //    PatientID = 1,
            //    DietitianID = 1,
            //    Name = "Mehmet",
            //    Lastname = "Kaya",
            //    GovernmentIDNumber = "33333333333",
            //    BirthDate = new DateTime(1985, 8, 20),
            //    Sex = "Erkek",
            //    Height = 182.5,
            //    StartingWeight = 95,
            //    TargetWeight = 80,
            //    Weight = 94.2,
            //    BloodGroup = "A Rh+",
            //    TargetDescription = "Kilo verme ve kas kazanımı",
            //    Allergies = "Fıstık alerjisi",
            //    Diseases = "İnsülin Direnci",
            //    UsingMeds = "Glifor 1000mg",
            //    OperationHistory = "Apandisit (2010)",
            //    IsSmoking = false,
            //    PhysicalActivity = "Haftada 2 gün yürüyüş",
            //    PhoneNumber = "05441234567",
            //    Email = "mehmet.kaya@mail.com",
            //    Address = "Örnek Mah. Çınar Cad. No:5",
            //    SystemSignDate = new DateTime(2026, 1, 24, 12, 1, 18, 777),
            //    Case = "Aktif Danışan",
            //    Notes = "Motivasyonu yüksek.",
            //    LastSessionDate = new DateTime(2026, 1, 24, 12, 1, 18, 777),
            //    Active = true
            //});
            //context.BodyMeasurements.AddOrUpdate(new BodyMeasurements()
            //{
            //    BodyMeasurementId = 1,
            //    PatientId = 1,
            //    DietitianID = 1,
            //    Date = new DateTime(2026, 1, 24, 12, 1, 18, 783),
            //    Weight = 94.2,
            //    BodyFatPercentage = 28.5,
            //    MuscleMassKg = 62.4,
            //    WaterPercentage = 52.1,
            //    VisceralFatLevel = 8,
            //    WaistCircumference = 102.5,
            //    HipCircumference = 110,
            //    Notes = "İlk ölçüm sonuçları."
            //});
            #endregion
        }
    }
}
