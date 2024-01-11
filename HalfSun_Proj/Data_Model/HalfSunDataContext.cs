using System;
using System.Collections.Generic;
using HalfSun_Proj.Data_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace HalfSun_Proj.Data_Model;

public partial class HalfSunDataContext : DbContext
{
    public HalfSunDataContext()
    {
    }

    public HalfSunDataContext(DbContextOptions<HalfSunDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffBenefit> StaffBenefits { get; set; }

    public virtual DbSet<StaffBenefitsMapping> StaffBenefitsMappings { get; set; }

    public virtual DbSet<StaffType> StaffTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-BO0Q0RJ; User=sa; Password=111; Database=HalfSun_DB; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblStaff");

            entity.HasOne(d => d.StaffType).WithMany(p => p.Staff).HasConstraintName("FK_Staff_StaffTypes");
        });

        modelBuilder.Entity<StaffBenefit>(entity =>
        {
            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<StaffBenefitsMapping>(entity =>
        {
            entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Benefit).WithMany(p => p.StaffBenefitsMappings).HasConstraintName("FK_StaffBenefitsMapping_StaffBenefits");

            entity.HasOne(d => d.Staff).WithMany(p => p.StaffBenefitsMappings).HasConstraintName("FK_StaffBenefitsMapping_Staff");
        });

        modelBuilder.Entity<StaffType>(entity =>
        {
            entity.Property(e => e.Creationdate).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
