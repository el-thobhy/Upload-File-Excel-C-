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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
