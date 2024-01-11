using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HalfSun_Proj.Data_Model.Models;

public partial class StaffBenefit
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreationDate { get; set; }

    [InverseProperty("Benefit")]
    public virtual ICollection<StaffBenefitsMapping> StaffBenefitsMappings { get; set; } = new List<StaffBenefitsMapping>();
}
