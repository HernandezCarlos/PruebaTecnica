using System;
using System.Collections.Generic;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Data;

public partial class DbPruebaContext : DbContext
{
    public DbPruebaContext()
    {
    }

    public DbPruebaContext(DbContextOptions<DbPruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividades { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.IdActividad);

            entity.Property(e => e.ActividadInfo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("actividad");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("create_date");
            entity.Property(e => e.IdActividad)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_actividad");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PaisResidencia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("pais_residencia");
            entity.Property(e => e.RecibirInformacion).HasColumnName("recibir_informacion");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
