using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model.Entities.Sql.DataBase;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividads { get; set; }

    public virtual DbSet<Prospecto> Prospectos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Actividad1");

            entity.ToTable("Actividad");

            entity.Property(e => e.Descripcion).HasMaxLength(250);

            entity.HasOne(d => d.Prospecto).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.ProspectoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Actividad1");
        });

        modelBuilder.Entity<Prospecto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Prospecto1");

            entity.ToTable("Prospecto");

            entity.Property(e => e.Celular).HasMaxLength(20);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(250);
            entity.Property(e => e.Nombre).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
