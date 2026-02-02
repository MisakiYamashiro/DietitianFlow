using BCrypt;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DatabaseAccess
{

    public class Database : IDisposable
    {
        SqlConnection con;
        SqlCommand cmd;
        public Database()
        {
            con = new SqlConnection(ConnectionString.Connection);
            cmd = con.CreateCommand();
        }

        public string CreatePWHash(string password)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(password);
            return hash;
        }
        public bool HashVerify(string password, string email)
        {
            string dbHash = null;

            using (Database db = new Database())
            {
                cmd.CommandText = "select Password_Hash from Dietitians where Email=@em";

                cmd.Parameters.AddWithValue("@em", email);

                con.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    dbHash = result.ToString();
                }
                else
                {
                    return false;
                }
            }
            bool VerifyResult = BCrypt.Net.BCrypt.Verify(password, dbHash);
            return VerifyResult;
        }
        public Dietitian Login(string password, string email)
        {
            bool VerifyUser = HashVerify(password, email);

            if (VerifyUser)
            {
                using (Database db = new Database())
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT DietitianID, Name, Lastname, BirthDate, Salary, PhotoBinaryFormat, JsonBinaryFormat, GovernmentIDNumber, Sex, Degree, GraduatedUniversityName, Email, PhoneNumber, Address, City, District, Password_Hash, ActiveEmployee, LastLoginDateTime, ShiftStartTime, ShiftEndTime, SessionFee, IBANumber FROM Dietitians where Email=@em";
                    cmd.Parameters.AddWithValue("@em", email);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    Dietitian dietitian = null;
                    if (reader.Read())
                    {
                        dietitian = new Dietitian();
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
        public Dietitian GetDietitian(int id)
        {
            using (Database db = new Database())
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT DietitianID, Name, Lastname, BirthDate, Salary, PhotoBinaryFormat, JsonBinaryFormat, GovernmentIDNumber, Sex, Degree, GraduatedUniversityName, Email, PhoneNumber, Address, City, District, Password_Hash, ActiveEmployee, LastLoginDateTime, ShiftStartTime, ShiftEndTime, SessionFee, IBANumber FROM Dietitians where DietitianID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                Dietitian dietitian = null;
                if (reader.Read())
                {
                    dietitian = new Dietitian();
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
        public List<Appointment> GetAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            using (Database db = new Database())
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "select AppointmentId,DietitianId,PatientId,StartTime,EndTime,Status,Type,Notes from Appointments";
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Appointment appointment = new Appointment();
                    appointment.AppointmentId = reader.GetInt32(0);
                    appointment.DietitianId = reader.GetInt32(1);
                    appointment.PatientId = reader.GetInt32(2);
                    appointment.StartTime = reader.GetDateTime(3);
                    appointment.EndTime = reader.GetDateTime(4);
                    appointment.Status = reader.GetBoolean(5);
                    appointment.Type = reader.GetString(6);
                    appointment.Notes = reader.GetString(7);
                    appointments.Add(appointment);
                }
                reader.Close();
                return appointments;
            }
        }
        public List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>();
            using (Database db = new Database())
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
                    Patient patient1 = new Patient();
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
                    if (patient1.IsSmoking = reader.GetBoolean(17) == true)
                    {
                        patient1.IsSmoking = reader.GetBoolean(17);
                        patient1.IsSmokingStr = "True";
                    }
                    else if (patient1.IsSmoking = reader.GetBoolean(17) == false)
                    {
                        patient1.IsSmoking = reader.GetBoolean(17);
                        patient1.IsSmokingStr = "False";
                    }
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
