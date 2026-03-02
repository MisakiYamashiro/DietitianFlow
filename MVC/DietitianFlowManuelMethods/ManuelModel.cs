using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DietitianFlowManuelMethods
{
    public class ManuelModel : IDisposable
    {
        SqlConnection con;
        SqlCommand cmd;

        public ManuelModel()
        {
            con = new SqlConnection(ConnectionStrings.LocalConnection);
            cmd = con.CreateCommand();
        }
        public uc_Dietitian GetDietitian(int id)
        {
            using (ManuelModel db = new ManuelModel())
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT DietitianID, Name, Lastname, BirthDate, Salary, PhotoBinaryFormat, JsonBinaryFormat, GovernmentIDNumber, Sex, Degree, GraduatedUniversityName, Email, PhoneNumber, Address, City, District, Password_Hash, ActiveEmployee, LastLoginDateTime, ShiftStartTime, ShiftEndTime, SessionFee, IBANumber FROM Dietitians where DietitianID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                uc_Dietitian dietitian = null;
                if (reader.Read())
                {
                    dietitian = new uc_Dietitian();
                    dietitian.DietitianID = reader.GetInt32(0);
                    dietitian.Name = reader.GetString(1);
                    dietitian.Lastname = reader.GetString(2);
                    dietitian.BirthDate = reader.GetDateTime(3);
                    dietitian.Salary = reader.GetDecimal(4);
                    if (!reader.IsDBNull(5)) dietitian.PhotoBinaryFormat = (byte[])reader[5];
                    if (!reader.IsDBNull(6)) dietitian.JsonBinaryFormat = (byte[])reader[6];
                    dietitian.GovernmentIDNumber = reader.GetString(7);
                    dietitian.Sex = reader.GetString(8);
                    dietitian.Degree = reader.GetString(9);
                    dietitian.GraduatedUniversityName = reader.GetString(10);
                    dietitian.Email = reader.GetString(11);
                    dietitian.PhoneNumber = reader.GetString(12);
                    dietitian.Address = reader.GetString(13);
                    dietitian.City = reader.GetString(14);
                    dietitian.District = reader.GetString(15);
                    dietitian.Password_Hash = reader.GetString(16);
                    dietitian.ActiveEmployee = reader.GetBoolean(17);
                    if (!reader.IsDBNull(18))
                        dietitian.LastLoginDatetime = reader.GetDateTime(18);
                    dietitian.ShiftStartTime = reader.GetTimeSpan(19);
                    dietitian.ShiftEndTime = reader.GetTimeSpan(20);
                    dietitian.SessionFee = reader.GetDecimal(21);
                    dietitian.IBANumber = reader.GetString(22);
                }

                reader.Close();
                return dietitian;
            }
        }
        public List<uc_Dietitian> GetDietitians()
        {
            using (ManuelModel db = new ManuelModel())
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT DietitianID, Name, Lastname, BirthDate, Salary, PhotoBinaryFormat, JsonBinaryFormat, GovernmentIDNumber, Sex, Degree, GraduatedUniversityName, Email, PhoneNumber, Address, City, District, Password_Hash, ActiveEmployee, LastLoginDateTime, ShiftStartTime, ShiftEndTime, SessionFee, IBANumber FROM Dietitians";
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                List<uc_Dietitian> list = new List<uc_Dietitian>();
                
                if (reader.Read())
                {
                    uc_Dietitian dietitian = new uc_Dietitian();
                    dietitian.DietitianID = reader.GetInt32(0);
                    dietitian.Name = reader.GetString(1);
                    dietitian.Lastname = reader.GetString(2);
                    dietitian.BirthDate = reader.GetDateTime(3);
                    dietitian.Salary = reader.GetDecimal(4);
                    if (!reader.IsDBNull(5)) dietitian.PhotoBinaryFormat = (byte[])reader[5];
                    if (!reader.IsDBNull(6)) dietitian.JsonBinaryFormat = (byte[])reader[6];
                    dietitian.GovernmentIDNumber = reader.GetString(7);
                    dietitian.Sex = reader.GetString(8);
                    dietitian.Degree = reader.GetString(9);
                    dietitian.GraduatedUniversityName = reader.GetString(10);
                    dietitian.Email = reader.GetString(11);
                    dietitian.PhoneNumber = reader.GetString(12);
                    dietitian.Address = reader.GetString(13);
                    dietitian.City = reader.GetString(14);
                    dietitian.District = reader.GetString(15);
                    dietitian.Password_Hash = reader.GetString(16);
                    dietitian.ActiveEmployee = reader.GetBoolean(17);
                    if (!reader.IsDBNull(18))
                        dietitian.LastLoginDatetime = reader.GetDateTime(18);
                    dietitian.ShiftStartTime = reader.GetTimeSpan(19);
                    dietitian.ShiftEndTime = reader.GetTimeSpan(20);
                    dietitian.SessionFee = reader.GetDecimal(21);
                    dietitian.IBANumber = reader.GetString(22);
                    list.Add(dietitian);
                }

                reader.Close();
                return list;
            }
        }
        public uc_Dietitian GetDietitian(string Email)
        {
            using (ManuelModel db = new ManuelModel())
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT DietitianID, Name, Lastname, BirthDate, Salary, PhotoBinaryFormat, JsonBinaryFormat, GovernmentIDNumber, Sex, Degree, GraduatedUniversityName, Email, PhoneNumber, Address, City, District, Password_Hash, ActiveEmployee, LastLoginDateTime, ShiftStartTime, ShiftEndTime, SessionFee, IBANumber FROM Dietitians where Email=@email";
                cmd.Parameters.AddWithValue("@email", Email);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                uc_Dietitian dietitian = null;
                if (reader.Read())
                {
                    dietitian = new uc_Dietitian();
                    dietitian.DietitianID = reader.GetInt32(0);
                    dietitian.Name = reader.GetString(1);
                    dietitian.Lastname = reader.GetString(2);
                    dietitian.BirthDate = reader.GetDateTime(3);
                    dietitian.Salary = reader.GetDecimal(4);
                    if (!reader.IsDBNull(5)) dietitian.PhotoBinaryFormat = (byte[])reader[5];
                    if (!reader.IsDBNull(6)) dietitian.JsonBinaryFormat = (byte[])reader[6];
                    dietitian.GovernmentIDNumber = reader.GetString(7);
                    dietitian.Sex = reader.GetString(8);
                    dietitian.Degree = reader.GetString(9);
                    dietitian.GraduatedUniversityName = reader.GetString(10);
                    dietitian.Email = reader.GetString(11);
                    dietitian.PhoneNumber = reader.GetString(12);
                    dietitian.Address = reader.GetString(13);
                    dietitian.City = reader.GetString(14);
                    dietitian.District = reader.GetString(15);
                    dietitian.Password_Hash = reader.GetString(16);
                    dietitian.ActiveEmployee = reader.GetBoolean(17);
                    if (!reader.IsDBNull(18))
                        dietitian.LastLoginDatetime = reader.GetDateTime(18);
                    dietitian.ShiftStartTime = reader.GetTimeSpan(19);
                    dietitian.ShiftEndTime = reader.GetTimeSpan(20);
                    dietitian.SessionFee = reader.GetDecimal(21);
                    dietitian.IBANumber = reader.GetString(22);
                }

                reader.Close();
                return dietitian;
            }
        }
        public bool VerifyHash(string password, string passwordHash)
        {
            try
            {

                bool verified = BCrypt.Net.BCrypt.Verify(password,passwordHash);
                if (verified)
                {
                    return true;
                }
                else if (!verified)
                {
                    return false;
                }
                else 
                {
                    throw new ArgumentException("Sanırım böyle bir kullanıcı yok veya başka bir hata yaşanıyor...");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex + " ah PenPineappleApplePen");
            }
        }

        public uc_Dietitian Login(string password, string email)
        {
            uc_Dietitian dietitian1 = GetDietitian(email);
            bool VerifyUser = VerifyHash(password,dietitian1.Password_Hash);

            if (VerifyUser)
            {
                using (ManuelModel db = new ManuelModel())
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT DietitianID, Name, Lastname, BirthDate, Salary, PhotoBinaryFormat, JsonBinaryFormat, GovernmentIDNumber, Sex, Degree, GraduatedUniversityName, Email, PhoneNumber, Address, City, District, Password_Hash, ActiveEmployee, LastLoginDateTime, ShiftStartTime, ShiftEndTime, SessionFee, IBANumber FROM Dietitians where Email=@em";
                    cmd.Parameters.AddWithValue("@em", email);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    uc_Dietitian dietitian = null;
                    if (reader.Read())
                    {
                        dietitian = new uc_Dietitian();
                        dietitian.DietitianID = reader.GetInt32(0);
                        dietitian.Name = reader.GetString(1);
                        dietitian.Lastname = reader.GetString(2);
                        dietitian.BirthDate = reader.GetDateTime(3);
                        dietitian.Salary = reader.GetDecimal(4);
                        if (!reader.IsDBNull(5)) dietitian.PhotoBinaryFormat = (byte[])reader[5];
                        if (!reader.IsDBNull(6)) dietitian.JsonBinaryFormat = (byte[])reader[6];
                        dietitian.GovernmentIDNumber = reader.GetString(7);
                        dietitian.Sex = reader.GetString(8);
                        dietitian.Degree = reader.GetString(9);
                        dietitian.GraduatedUniversityName = reader.GetString(10);
                        dietitian.Email = reader.GetString(11);
                        dietitian.PhoneNumber = reader.GetString(12);
                        dietitian.Address = reader.GetString(13);
                        dietitian.City = reader.GetString(14);
                        dietitian.District = reader.GetString(15);
                        dietitian.Password_Hash = reader.GetString(16);
                        dietitian.ActiveEmployee = reader.GetBoolean(17);
                        if (!reader.IsDBNull(18))
                            dietitian.LastLoginDatetime = reader.GetDateTime(18);
                        dietitian.ShiftStartTime = reader.GetTimeSpan(19);
                        dietitian.ShiftEndTime = reader.GetTimeSpan(20);
                        dietitian.SessionFee = reader.GetDecimal(21);
                        dietitian.IBANumber = reader.GetString(22);
                    }

                    reader.Close();
                    return dietitian;
                }
            }
            else
            {
                return null;
            }
        }
        public List<uc_Appointments> GetAppointments(int id)
        {
            try
            {
                using (ManuelModel mm = new ManuelModel())
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT A.AppointmentId,D.DietitianId,D.Name AS DietitianName,P.PatientId,P.Name as PatientName,A.StartTime,A.EndTime,A.Status,A.Type,A.Notes FROM Appointments A JOIN Dietitians D ON A.DietitianId=D.DietitianID JOIN Patients P ON A.PatientId=P.PatientID where D.DietitianID = @id";
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var apps = new List<uc_Appointments>();
                    while (reader.Read())
                    {
                        var app = new uc_Appointments();
                        app.AppointmentId = reader.GetInt32(0);
                        app.DietitianID = reader.GetInt32(1);
                        app.DietitianName = reader.GetString(2);
                        app.PatientID = reader.GetInt32(3);
                        app.PatientName = reader.GetString(4);
                        app.StartTime = reader.GetDateTime(5);
                        app.EndTime = reader.GetDateTime(6);
                        app.Status = reader.GetBoolean(7);
                        app.Type = reader.GetString(8);
                        if (reader.IsDBNull(9))
                        {
                            app.Notes = "N/A";
                        }
                        else
                        {
                            app.Notes = reader.GetString(9);
                        }
                        apps.Add(app);
                    }
                    reader.Close();
                    return apps;
                }
            }
            catch (Exception exc)
            {
                throw new ArgumentException(exc + "dying light the beast < dying light 2");
            }
        }
        public List<uc_Appointments> GetAppointments()
        {
            try
            {
                using (ManuelModel mm = new ManuelModel())
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT AppointmentId,DietitianId,PatientId,StartTime,EndTime,Status,Type,Notes from Appointments";
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    var apps = new List<uc_Appointments>();
                    while (reader.Read())
                    {
                        var app = new uc_Appointments();
                        app.AppointmentId = reader.GetInt32(0);
                        app.DietitianID = reader.GetInt32(1);
                        app.PatientID = reader.GetInt32(2);
                        app.StartTime = reader.GetDateTime(3);
                        app.EndTime = reader.GetDateTime(4);
                        app.Status = reader.GetBoolean(5);
                        app.Type = reader.GetString(6);
                        if (reader.IsDBNull(7))
                        {
                            app.Notes = "N/A";
                        }
                        else
                        {
                            app.Notes = reader.GetString(7);
                        }
                        apps.Add(app);
                    }
                    reader.Close();
                    return apps;
                }
            }
            catch (Exception exc)
            {
                throw new ArgumentException(exc + "dying light the beast < dying light 2");
            }
        }

        public uc_Appointments GetAppointment(int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT A.AppointmentId,D.DietitianId,D.Name AS DietitianName,D.Lastname as DietitianLastname,P.PatientId,P.Name as PatientName,P.Lastname as PatientLastname,A.StartTime,A.EndTime,A.Status,A.Type,A.Notes FROM Appointments A JOIN Dietitians D ON A.DietitianId=D.DietitianID JOIN Patients P ON A.PatientId=P.PatientID where A.AppointmentId = @id";
                con.Open();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                var app = new uc_Appointments();
                while (reader.Read())
                {
                    app.AppointmentId = reader.GetInt32(0);
                    app.DietitianID = reader.GetInt32(1);
                    app.DietitianName = reader.GetString(2);
                    app.DietitianLastname = reader.GetString(3);
                    app.PatientID = reader.GetInt32(4);
                    app.PatientName = reader.GetString(5);
                    app.PatientLastname = reader.GetString(6);
                    app.StartTime = reader.GetDateTime(7);
                    app.EndTime = reader.GetDateTime(8);
                    app.Status = reader.GetBoolean(9);
                    app.Type = reader.GetString(10);
                    if (reader.IsDBNull(11))
                    {
                        app.Notes = "N/A";
                    }
                    else
                    {
                        app.Notes = reader.GetString(11);
                    }
                }
                reader.Close();
                return app;
            }
            catch (Exception exc)
            {
                throw new ArgumentException(exc + "dying light the beast < dying light 2");
    }
}
        public List<uc_Patient> GetPatients()
        {
            List<uc_Patient> patients = new List<uc_Patient>();
            using (ManuelModel db = new ManuelModel())
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT PatientID, DietitianID, Name, Lastname, GovernmentIDNumber, BirthDate, Sex, Height, StartingWeight, TargetWeight,Weight, BloodGroup, TargetDescription, Allergies, Diseases, UsingMeds, OperationHistory, IsSmoking, PhysicalActivity, PhoneNumber, Email, Address, SystemSignDate, [Case], Notes, LastSessionDate, Active FROM Patients";
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    uc_Patient patient1 = new uc_Patient();
                    patient1.PatientID = reader.GetInt32(0);
                    patient1.DietitianID = reader.GetInt32(1);
                    patient1.Name = reader.GetString(2);
                    patient1.Lastname = reader.GetString(3);
                    patient1.GovernmentIDNumber = reader.GetString(4);
                    patient1.BirthDate = reader.GetDateTime(5);
                    patient1.Sex = reader.GetString(6);
                    patient1.Height = reader.GetDouble(7);
                    patient1.StartingWeight = reader.GetDouble(8);
                    patient1.TargetWeight = reader.GetDouble(9);
                    patient1.Weight = reader.GetDouble(10);
                    patient1.BloodGroup = reader.GetString(11);
                    patient1.TargetDescription = reader.GetString(12);
                    patient1.Allergies = reader.GetString(13);
                    patient1.Diseases = reader.GetString(14);
                    patient1.UsingMeds = reader.GetString(15);
                    patient1.OperationHistory = reader.GetString(16);
                    patient1.IsSmoking = reader.GetBoolean(17);
                    patient1.PhysicalActivity = reader.GetString(18);
                    patient1.PhoneNumber = reader.GetString(19);
                    patient1.Email = reader.GetString(20);
                    patient1.Address = reader.GetString(21);
                    patient1.SystemSignDate = reader.GetDateTime(22);
                    patient1.Case = reader.GetString(23);
                    patient1.Notes = reader.GetString(24);
                    patient1.LastSessionDate = reader.GetDateTime(25);
                    patient1.Active = reader.GetBoolean(26);
                    patients.Add(patient1);
                }
                reader.Close();
                return patients;
            }
        }
        public uc_Patient GetPatient(int id)
        {
            
            using (ManuelModel db = new ManuelModel())
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT P.PatientID,P.DietitianID, D.Name as DietitianName, P.Name as PatientName, P.Lastname,P.GovernmentIDNumber,P.BirthDate,P.Sex,P.Height,P.StartingWeight,P.TargetWeight,p.Weight,p.BloodGroup,p.TargetDescription,p.Allergies,p.Diseases,p.UsingMeds,p.OperationHistory,p.IsSmoking,p.PhysicalActivity,P.PhoneNumber,p.Email,p.Address,p.SystemSignDate,p.[Case],p.Notes,p.LastSessionDate,p.Active FROM Patients as P join Dietitians as D on P.DietitianID = D.DietitianID where D.DietitianID = 1";
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                uc_Patient patient1 = new uc_Patient();
                while (reader.Read())
                {
                    patient1.PatientID = reader.GetInt32(0);
                    patient1.DietitianID = reader.GetInt32(1);
                    patient1.DietitianName = reader.GetString(2);
                    patient1.Name = reader.GetString(3);
                    patient1.Lastname = reader.GetString(4);
                    patient1.GovernmentIDNumber = reader.GetString(5);
                    patient1.BirthDate = reader.GetDateTime(6);
                    patient1.Sex = reader.GetString(7);
                    patient1.Height = reader.GetDouble(8);
                    patient1.StartingWeight = reader.GetDouble(9);
                    patient1.TargetWeight = reader.GetDouble(10);
                    patient1.Weight = reader.GetDouble(11);
                    patient1.BloodGroup = reader.GetString(12);
                    patient1.TargetDescription = reader.GetString(13);  
                    patient1.Allergies = reader.GetString(14);
                    patient1.Diseases = reader.GetString(15);
                    patient1.UsingMeds = reader.GetString(16);
                    patient1.OperationHistory = reader.GetString(17);
                    patient1.IsSmoking = reader.GetBoolean(18);
                    patient1.PhysicalActivity = reader.GetString(19);
                    patient1.PhoneNumber = reader.GetString(20);
                    patient1.Email = reader.GetString(21);
                    patient1.Address = reader.GetString(22);
                    patient1.SystemSignDate = reader.GetDateTime(23);
                    patient1.Case = reader.GetString(24);
                    patient1.Notes = reader.GetString(25);
                    patient1.LastSessionDate = reader.GetDateTime(26);
                    patient1.Active = reader.GetBoolean(27);
                }
                reader.Close();
                return patient1;
            }
        }
        public List<uc_Patient> GetPatients(int id)
        {
            List<uc_Patient> patients = new List<uc_Patient>();
            using (ManuelModel db = new ManuelModel())
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT P.PatientID,P.DietitianID, D.Name as DietitianName, P.Name as PatientName, P.Lastname,P.GovernmentIDNumber,P.BirthDate,P.Sex,P.Height,P.StartingWeight,P.TargetWeight,p.Weight,p.BloodGroup,p.TargetDescription,p.Allergies,p.Diseases,p.UsingMeds,p.OperationHistory,p.IsSmoking,p.PhysicalActivity,P.PhoneNumber,p.Email,p.Address,p.SystemSignDate,p.[Case],p.Notes,p.LastSessionDate,p.Active FROM Patients as P join Dietitians as D on P.DietitianID = D.DietitianID where D.DietitianID = 1";
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    uc_Patient patient1 = new uc_Patient();
                    patient1.PatientID = reader.GetInt32(0);
                    patient1.DietitianID = reader.GetInt32(1);
                    patient1.DietitianName = reader.GetString(2);
                    patient1.Name = reader.GetString(3);
                    patient1.Lastname = reader.GetString(4);
                    patient1.GovernmentIDNumber = reader.GetString(5);
                    patient1.BirthDate = reader.GetDateTime(6);
                    patient1.Sex = reader.GetString(7);
                    patient1.Height = reader.GetDouble(8);
                    patient1.StartingWeight = reader.GetDouble(9);
                    patient1.TargetWeight = reader.GetDouble(10);
                    patient1.Weight = reader.GetDouble(11);
                    patient1.BloodGroup = reader.GetString(12);
                    patient1.TargetDescription = reader.GetString(13);
                    patient1.Allergies = reader.GetString(14);
                    patient1.Diseases = reader.GetString(15);
                    patient1.UsingMeds = reader.GetString(16);
                    patient1.OperationHistory = reader.GetString(17);
                    patient1.IsSmoking = reader.GetBoolean(18);
                    patient1.PhysicalActivity = reader.GetString(19);
                    patient1.PhoneNumber = reader.GetString(20);
                    patient1.Email = reader.GetString(21);
                    patient1.Address = reader.GetString(22);
                    patient1.SystemSignDate = reader.GetDateTime(23);
                    patient1.Case = reader.GetString(24);
                    patient1.Notes = reader.GetString(25);
                    patient1.LastSessionDate = reader.GetDateTime(26);
                    patient1.Active = reader.GetBoolean(27);
                    patients.Add(patient1);
                }
                reader.Close();
                return patients;
            }
        }
        public void Dispose()
        {

            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
            if (cmd != null) cmd.Dispose();

            GC.SuppressFinalize(this);
        }
    }
    
}
