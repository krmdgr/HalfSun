using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HalfSun_Proj.Data_Model.Models;

public partial class StaffType
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Creationdate { get; set; }

    [InverseProperty("StaffType")]
    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
