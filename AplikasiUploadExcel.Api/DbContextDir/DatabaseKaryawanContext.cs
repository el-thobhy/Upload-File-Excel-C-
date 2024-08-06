using System;
using System.Collections.Generic;
using AplikasiUploadExcel.Api.DataModel;
using Microsoft.EntityFrameworkCore;

namespace AplikasiUploadExcel.Api.DbContextDir;

public partial class DatabaseKaryawanContext : DbContext
{
    public DatabaseKaryawanContext()
    {
    }

    public DatabaseKaryawanContext(DbContextOptions<DatabaseKaryawanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Biodata> Biodata { get; set; }
    public virtual DbSet<CC_Category> CC_Categories { get; set; }
    public virtual DbSet<CC_Priority> CC_Priorities { get; set; }
    public virtual DbSet<MaterialPlant> MaterialPlants { get; set; }
    public virtual DbSet<Org_Dept> Org_Depts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Biodata>(entity =>
        {
            entity.ToTable("Biodata");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.DeletedBy).HasMaxLength(50);
            entity.Property(e => e.Dob).HasMaxLength(10);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.Pob).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasIndex(e => e.BiodataId, "IX_Employee_BiodataId");

            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.DeletedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.Nip).HasMaxLength(5);
            entity.Property(e => e.Status).HasMaxLength(10);
        });

        modelBuilder.Entity<CC_Category>(entity =>
        {
            entity.ToTable("CC_Category");
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<CC_Priority>(entity =>
        {
            entity.ToTable("CC_Priority");
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<MaterialPlant>(entity =>
        {
            entity.ToTable("Material_Plant");
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Org_Dept>(entity =>
        {
            entity.ToTable("Org_Dept");
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.OrgCode).IsRequired(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
