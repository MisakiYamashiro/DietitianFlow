using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Appointments")]
public class uc_Appointments
{
    [Key]
    public int AppointmentId { get; set; }

    public int? DietitianID { get; set; }

    [ForeignKey("DietitianID")]
    public virtual uc_Dietitian Dietitian { get; set; }

    public int? PatientID { get; set; }

    [ForeignKey("PatientID")]
    public virtual uc_Patient Patient { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public bool? Status { get; set; }

    [StringLength(50, ErrorMessage = "The 'Type' field can be a maximum of 50 characters.")]
    public string Type { get; set; }

    public string Notes { get; set; }
}