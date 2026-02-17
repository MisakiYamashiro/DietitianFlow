using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("BodyMeasurements")]
public class uc_BodyMeasurements
{
    [Key]
    public int BodyMeasurementId { get; set; }

    public int? PatientID { get; set; }

    [ForeignKey("PatientID")]
    public virtual uc_Patient Patient { get; set; }

    public int? DietitianID { get; set; }

    [ForeignKey("DietitianID")]
    public virtual uc_Dietitian Dietitian { get; set; }

    public DateTime? Date { get; set; }

    public double? Weight { get; set; }

    public double? BodyFatPercentage { get; set; }

    public double? MuscleMassKg { get; set; }

    public double? WaterPercentage { get; set; }

    public int? VisceralFatLevel { get; set; }

    public double? WaistCircumference { get; set; }

    public double? HipCircumference { get; set; }

    public string Notes { get; set; }
}