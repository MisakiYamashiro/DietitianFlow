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
