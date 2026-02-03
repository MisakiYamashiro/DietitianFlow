using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveXDataObjects
{
    public class Dietitian
    {
        public int DietitianID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; } // Para birimi için decimal
        public byte[] PhotoBinaryFormat { get; set; } // Resim verisi
        public byte[] JsonBinaryFormat { get; set; } // JSON binary verisi
        public string GovernmentIDNumber { get; set; } // TC Kimlik vb. işlemler yapılmayacaksa string daha güvenlidir
        public string Sex { get; set; }
        public string Degree { get; set; }
        public string GraduatedUniversityName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Password_Hash { get; set; }
        public bool ActiveEmployee { get; set; }
        public DateTime LastLoginDatetime { get; set; }
        public TimeSpan ShiftStartTime { get; set; }
        public TimeSpan ShiftEndTime { get; set; }
        public decimal SessionFee { get; set; }
        public string IBANumber { get; set; }
    }
}
