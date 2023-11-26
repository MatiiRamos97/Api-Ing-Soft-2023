﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_ing_soft.Data;

#nullable disable

namespace api_ing_soft.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231126003430_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Personas.Persona", b =>
                {
                    b.Property<int>("PersonaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PersonaID");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Personas.Admin", b =>
                {
                    b.HasBaseType("Personas.Persona");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Admin");
                });
#pragma warning restore 612, 618
        }
    }
}