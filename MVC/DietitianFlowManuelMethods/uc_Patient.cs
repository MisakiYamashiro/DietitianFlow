using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Patients")]
public class uc_Patient
{
    public uc_Patient()
    {
        Appointments = new HashSet<uc_Appointments>();
        BodyMeasurements = new HashSet<uc_BodyMeasurements>();
    }

    [Key]
    public int PatientID { get; set; }

    public int? DietitianID { get; set; }

    [ForeignKey("DietitianID")]
    public virtual uc_Dietitian Dietitian { get; set; }

    [StringLength(50, ErrorMessage = "The 'Name' field can be a maximum of 50 characters.")]
    public string Name { get; set; }

    [StringLength(50, ErrorMessage = "The 'Lastname' field can be a maximum of 50 characters.")]
    public string Lastname { get; set; }

    [StringLength(11, ErrorMessage = "The 'GovernmentIDNumber' field can be a maximum of 11 characters.")]
    [Column(TypeName = "varchar")]
    public string GovernmentIDNumber { get; set; }

    [Column(TypeName = "date")]
    public DateTime? BirthDate { get; set; }

    [StringLength(20, ErrorMessage = "The 'Sex' field can be a maximum of 20 characters.")]
    public string Sex { get; set; }

    public double? Height { get; set; }

    public double? StartingWeight { get; set; }

    public double? TargetWeight { get; set; }

    public double? Weight { get; set; }

    [StringLength(10, ErrorMessage = "The 'BloodGroup' field can be a maximum of 10 characters.")]
    [Column(TypeName = "varchar")]
    public string BloodGroup { get; set; }

    public string TargetDescription { get; set; }
    public string Allergies { get; set; }
    public string Diseases { get; set; }
    public string UsingMeds { get; set; }
    public string OperationHistory { get; set; }

    public bool? IsSmoking { get; set; }

    [StringLength(200, ErrorMessage = "The 'PhysicalActivity' field can be a maximum of 200 characters.")]
    public string PhysicalActivity { get; set; }

    [StringLength(20, ErrorMessage = "The 'PhoneNumber' field can be a maximum of 20 characters.")]
    [Phone(ErrorMessage = "The 'PhoneNumber' field must be a valid phone number.")]
    [Column(TypeName = "varchar")]
    public string PhoneNumber { get; set; }

    [StringLength(150, ErrorMessage = "The 'Email' field can be a maximum of 150 characters.")]
    [EmailAddress(ErrorMessage = "The 'Email' field must be a valid email address.")]
    public string Email { get; set; }

    public string Address { get; set; }

    public DateTime? SystemSignDate { get; set; }
    public string Case { get; set; }
    public string Notes { get; set; }
    public DateTime? LastSessionDate { get; set; }
    public bool? Active { get; set; }

    public virtual ICollection<uc_Appointments> Appointments { get; set; }
    public virtual ICollection<uc_BodyMeasurements> BodyMeasurements { get; set; }
}