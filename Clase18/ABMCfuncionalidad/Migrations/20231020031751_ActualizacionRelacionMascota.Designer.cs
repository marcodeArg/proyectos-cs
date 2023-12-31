﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Veterinaria;

#nullable disable

namespace ABMCfuncionalidad.Migrations
{
    [DbContext(typeof(VeterinariaContext))]
    [Migration("20231020031751_ActualizacionRelacionMascota")]
    partial class ActualizacionRelacionMascota
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Veterinaria.AtencionMedica", b =>
                {
                    b.Property<int>("AtencionMedicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AtencionMedicaId"));

                    b.Property<decimal>("Importe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoCobro")
                        .HasColumnType("int");

                    b.HasKey("AtencionMedicaId");

                    b.HasIndex("MascotaId");

                    b.ToTable("AtencionMedicas");
                });

            modelBuilder.Entity("Veterinaria.Mascota", b =>
                {
                    b.Property<int>("MascotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MascotaId"));

                    b.Property<bool>("EsHabitual")
                        .HasColumnType("bit");

                    b.Property<int>("Especie")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MascotaId");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("Veterinaria.AtencionMedica", b =>
                {
                    b.HasOne("Veterinaria.Mascota", "Mascota")
                        .WithMany("Atenciones")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("Veterinaria.Mascota", b =>
                {
                    b.Navigation("Atenciones");
                });
#pragma warning restore 612, 618
        }
    }
}
