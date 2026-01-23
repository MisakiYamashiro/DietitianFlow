using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt;

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
                    cmd.CommandText = "SELECT DietitianID, Name, Lastname, BirthDate, Salary, PhotoBinaryFormat, JsonBinaryFormat, GovernmentIDNumber, Sex, Degree, GraduatedUniversityName, Email, PhoneNumber, Address, City, District, Password_Hash, Active_Employee, LastLoginDateTime, ShiftStartTime, ShiftEndTime, SessionFee, IBANumber FROM Dietitians where Email=@em";
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
