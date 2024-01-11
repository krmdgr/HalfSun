using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HalfSun_Proj.Data_Model.Models;

[Table("StaffBenefitsMapping")]
public partial class StaffBenefitsMapping
{
    [Key]
    public int Id { get; set; }

    public int? StaffId { get; set; }

    public int? BenefitId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Amount { get; set; }

    [ForeignKey("BenefitId")]
    [InverseProperty("StaffBenefitsMappings")]
    public virtual StaffBenefit? Benefit { get; set; }

    [ForeignKey("StaffId")]
    [InverseProperty("StaffBenefitsMappings")]
    public virtual Staff? Staff { get; set; }
}
