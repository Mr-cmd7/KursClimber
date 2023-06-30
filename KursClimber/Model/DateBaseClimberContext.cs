using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KursClimber.Model;

public partial class DateBaseClimberContext : DbContext
{
    public DateBaseClimberContext()
    {
    }

    public DateBaseClimberContext(DbContextOptions<DateBaseClimberContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Climber> Climbers { get; set; }

    public virtual DbSet<ClimbingGroup> ClimbingGroups { get; set; }

    public virtual DbSet<ClimbingRecord> ClimbingRecords { get; set; }

    public virtual DbSet<Mountain> Mountains { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\saall\\Desktop\\KursClimber\\KursClimber\\DateBaseClimber.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Climber>(entity =>
        {
            entity.ToTable("Climber");

            entity.Property(e => e.Address).HasColumnType("TEXT(20)");
            entity.Property(e => e.FirstName).HasColumnType("TEXT(20)");
            entity.Property(e => e.LastName).HasColumnType("TEXT(20)");
            entity.Property(e => e.SecondName).HasColumnType("TEXT(20)");
        });

        modelBuilder.Entity<ClimbingGroup>(entity =>
        {
            entity.HasKey(e => e.GroupId);

            entity.ToTable("ClimbingGroup");

            entity.Property(e => e.Name).HasColumnType("TEXT(20)");
            entity.Property(e => e.StartTime).HasColumnType("TEXT(8)");

            entity.HasOne(d => d.Mountain).WithMany(p => p.ClimbingGroups)
                .HasForeignKey(d => d.MountainId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ClimbingRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId);

            entity.ToTable("ClimbingRecord");

            entity.Property(e => e.EndDate).HasColumnType("TEXT(10)");
            entity.Property(e => e.StartDate).HasColumnType("TEXT(10)");

            entity.HasOne(d => d.Group).WithMany(p => p.ClimbingRecords)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Mountain).WithMany(p => p.ClimbingRecords)
                .HasForeignKey(d => d.MountainId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Mountain>(entity =>
        {
            entity.ToTable("Mountain");

            entity.Property(e => e.Country).HasColumnType("TEXT(20)");
            entity.Property(e => e.Height).HasColumnType("INTEGER(5)");
            entity.Property(e => e.Name).HasColumnType("TEXT(20)");
            entity.Property(e => e.Region).HasColumnType("TEXT(20)");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.ToTable("Participant");

            entity.HasOne(d => d.Climber).WithMany(p => p.Participants)
                .HasForeignKey(d => d.ClimberId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Group).WithMany(p => p.Participants)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Login).HasColumnType("TEXT(20)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
