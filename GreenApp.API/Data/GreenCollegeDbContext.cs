using System;
using System.Collections.Generic;
using GreenCollege.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenCollege.API.Data;

public partial class GreenCollegeDbContext : DbContext
{
    public GreenCollegeDbContext()
    {
    }

    public GreenCollegeDbContext(DbContextOptions<GreenCollegeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicYear> AcademicYears { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Degree> Degrees { get; set; }

    public virtual DbSet<Major> Majors { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicYear>(entity =>
        {
            entity.ToTable("AcademicYear");

            entity.Property(e => e.AcademicYearId).HasColumnName("AcademicYearID");
            entity.Property(e => e.AcademicYearDuration).HasMaxLength(50);
            entity.Property(e => e.AcademicYearName).HasMaxLength(50);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseName).HasMaxLength(50);
            entity.Property(e => e.MajorId).HasColumnName("MajorID");

            entity.HasOne(d => d.Major).WithMany(p => p.Courses)
                .HasForeignKey(d => d.MajorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_Major");
        });

        modelBuilder.Entity<Degree>(entity =>
        {
            entity.ToTable("Degree");

            entity.Property(e => e.DegreeId).HasColumnName("DegreeID");
            entity.Property(e => e.DegreeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Major>(entity =>
        {
            entity.ToTable("Major");

            entity.Property(e => e.MajorId).HasColumnName("MajorID");
            entity.Property(e => e.DegreeId).HasColumnName("DegreeID");
            entity.Property(e => e.MajorName).HasMaxLength(50);

            entity.HasOne(d => d.Degree).WithMany(p => p.Majors)
                .HasForeignKey(d => d.DegreeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Major_Degree");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.ToTable("Section");

            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.AcademicYearId).HasColumnName("AcademicYearID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.SectionName).HasMaxLength(50);

            entity.HasOne(d => d.AcademicYear).WithMany(p => p.Sections)
                .HasForeignKey(d => d.AcademicYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Section_AcademicYear");

            entity.HasOne(d => d.Course).WithMany(p => p.Sections)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Section_Course");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
