using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace Biblioteca
{
    public partial class BibliotecaContext : DbContext
    {
        public BibliotecaContext()
        {
            Env.Load();
        }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Biblioteca> Bibliotecas { get; set; }

        public virtual DbSet<Estado> Estados { get; set; }

        public virtual DbSet<Libro> Libros { get; set; }

        public virtual DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Biblioteca>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.BibliotecaId).HasColumnName("biblioteca_id");
                entity.Property(e => e.EstadoId).HasColumnName("estado_id");
                entity.Property(e => e.PrecioReposicion).HasColumnName("precio_reposicion");
                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.Biblioteca).WithMany(p => p.Libros)
                    .HasForeignKey(d => d.BibliotecaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Libros_Bibliotecas");

                entity.HasOne(d => d.Estado).WithMany(p => p.Libros)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Libros_Estados");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DiasPrestamo).HasColumnName("dias_prestamo");
                entity.Property(e => e.FueDevuelto).HasColumnName("fue_devuelto");
                entity.Property(e => e.LibroId).HasColumnName("libro_id");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.Libro).WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.LibroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prestamos_Libros");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}

