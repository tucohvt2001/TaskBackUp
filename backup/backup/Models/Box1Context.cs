using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoWithEF.Models;

public partial class Box1Context : DbContext
{
    public Box1Context()
    {
    }

    public Box1Context(DbContextOptions<Box1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<DataLogger1> DataLogger1s { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=D:\\Daco\\ProjectWinForm\\DbSQLite\\Box1.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataLogger1>(entity =>
        {
            entity.ToTable("DataLogger1");

            entity.HasIndex(e => e.Time, "Idx_DataLogger1_Time");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.In_Temp1).HasColumnName("In_Temp1");
            entity.Property(e => e.In_Temp35).HasColumnName("In_Temp35");
            entity.Property(e => e.In_Temp36).HasColumnName("In_Temp36");
            entity.Property(e => e.In_Temp40).HasColumnName("In_Temp40");
            entity.Property(e => e.In_Temp41).HasColumnName("In_Temp41");
            entity.Property(e => e.In_Temp42).HasColumnName("In_Temp42");
            entity.Property(e => e.In_Temp43).HasColumnName("In_Temp43");
            entity.Property(e => e.In_Temp44).HasColumnName("In_Temp44");
            entity.Property(e => e.In_Temp49).HasColumnName("In_Temp49");
            entity.Property(e => e.In_Temp50).HasColumnName("In_Temp50");
            entity.Property(e => e.In_Temp51).HasColumnName("In_Temp51");
            entity.Property(e => e.In_Temp52).HasColumnName("In_Temp52");
            entity.Property(e => e.In_Temp53).HasColumnName("In_Temp53");
            entity.Property(e => e.In_Temp54).HasColumnName("In_Temp54");
            entity.Property(e => e.In_Temp55).HasColumnName("In_Temp55");
            entity.Property(e => e.In_Temp56).HasColumnName("In_Temp56");
            entity.Property(e => e.Plat_Temp1).HasColumnName("Plat_Temp1");
            entity.Property(e => e.Plat_Temp35).HasColumnName("Plat_Temp35");
            entity.Property(e => e.Plat_Temp36).HasColumnName("Plat_Temp36");
            entity.Property(e => e.Plat_Temp40).HasColumnName("Plat_Temp40");
            entity.Property(e => e.Plat_Temp41).HasColumnName("Plat_Temp41");
            entity.Property(e => e.Plat_Temp42).HasColumnName("Plat_Temp42");
            entity.Property(e => e.Plat_Temp43).HasColumnName("Plat_Temp43");
            entity.Property(e => e.Plat_Temp44).HasColumnName("Plat_Temp44");
            entity.Property(e => e.Plat_Temp49).HasColumnName("Plat_Temp49");
            entity.Property(e => e.Plat_Temp50).HasColumnName("Plat_Temp50");
            entity.Property(e => e.Plat_Temp51).HasColumnName("Plat_Temp51");
            entity.Property(e => e.Plat_Temp52).HasColumnName("Plat_Temp52");
            entity.Property(e => e.Plat_Temp53).HasColumnName("Plat_Temp53");
            entity.Property(e => e.Plat_Temp54).HasColumnName("Plat_Temp54");
            entity.Property(e => e.Plat_Temp55).HasColumnName("Plat_Temp55");
            entity.Property(e => e.Plat_Temp56).HasColumnName("Plat_Temp56");
            entity.Property(e => e.SystemTagInternalTemperature).HasColumnType("smallint");
            entity.Property(e => e.Time).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
