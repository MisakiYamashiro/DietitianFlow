using DietitianFlowManuelMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Dietitians")]
public class uc_Dietitian
{
    public uc_Dietitian()
    {
        Patients = new HashSet<uc_Patient>();
        Appointments = new HashSet<uc_Appointments>();
        BodyMeasurements = new HashSet<uc_BodyMeasurements>();
    }

    [Key]
    public int DietitianID { get; set; }

    [StringLength(100, ErrorMessage = "The 'Name' field can be a maximum of 100 characters.")]
    public string Name { get; set; }

    [StringLength(100, ErrorMessage = "The 'Lastname' field can be a maximum of 100 characters.")]
    public string Lastname { get; set; }

    [Column(TypeName = "date")]
    public DateTime? BirthDate { get; set; }

    [Range(0, 999999.99, ErrorMessage = "The 'Salary' field must be a valid decimal number.")]
    public decimal? Salary { get; set; }

    [Range(0, 999999.99, ErrorMessage = "The 'SessionFee' field must be a valid decimal number.")]
    public decimal? SessionFee { get; set; }

    [StringLength(34, ErrorMessage = "The 'IBANumber' field can be a maximum of 34 characters.")]
    [Column(TypeName = "varchar")]
    public string IBANumber { get; set; }

    public byte[] PhotoBinaryFormat { get; set; }

    public byte[] JsonBinaryFormat { get; set; }

    [StringLength(11, ErrorMessage = "The 'GovernmentIDNumber' field can be a maximum of 11 characters.")]
    [Column(TypeName = "varchar")]
    public string GovernmentIDNumber { get; set; }

    [StringLength(20, ErrorMessage = "The 'Sex' field can be a maximum of 20 characters.")]
    public string Sex { get; set; }

    [StringLength(100, ErrorMessage = "The 'Degree' field can be a maximum of 100 characters.")]
    public string Degree { get; set; }

    [StringLength(200, ErrorMessage = "The 'GraduatedUniversityName' field can be a maximum of 200 characters.")]
    public string GraduatedUniversityName { get; set; }

    [StringLength(150, ErrorMessage = "The 'Email' field can be a maximum of 150 characters.")]
    [EmailAddress(ErrorMessage = "The 'Email' field must be a valid email address.")]
    public string Email { get; set; }

    [StringLength(20, ErrorMessage = "The 'PhoneNumber' field can be a maximum of 20 characters.")]
    [Phone(ErrorMessage = "The 'PhoneNumber' field must be a valid phone number.")]
    [Column(TypeName = "varchar")]
    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    [StringLength(50, ErrorMessage = "The 'City' field can be a maximum of 50 characters.")]
    public string City { get; set; }

    [StringLength(50, ErrorMessage = "The 'District' field can be a maximum of 50 characters.")]
    public string District { get; set; }

    [StringLength(500, ErrorMessage = "The 'Password_Hash' field can be a maximum of 500 characters.")]
    public string Password_Hash { get; set; }

    public bool? ActiveEmployee { get; set; }

    public DateTime? LastLoginDatetime { get; set; }

    public TimeSpan? ShiftStartTime { get; set; }

    public TimeSpan? ShiftEndTime { get; set; }

    public virtual ICollection<uc_Patient> Patients { get; set; }
    public virtual ICollection<uc_Appointments> Appointments { get; set; }
    public virtual ICollection<uc_BodyMeasurements> BodyMeasurements { get; set; }
}