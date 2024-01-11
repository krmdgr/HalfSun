using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HalfSun_Proj.Data_Model.Models;

public partial class Staff
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Address1 { get; set; }

    public int? StaffTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreationDate { get; set; }

    [InverseProperty("Staff")]
    public virtual ICollection<StaffBenefitsMapping> StaffBenefitsMappings { get; set; } = new List<StaffBenefitsMapping>();

    [ForeignKey("StaffTypeId")]
    [InverseProperty("Staff")]
    public virtual StaffType? StaffType { get; set; }
}
