﻿// <auto-generated />
using System;
using Calculadora_Prestamos.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Calculadora_Prestamos.Migrations
{
    [DbContext(typeof(DbContextSistema))]
    [Migration("20191206233116_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Calculadora_Prestamos.Entidades.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired();

                    b.Property<string>("Celular")
                        .IsRequired();

                    b.Property<string>("Direccion")
                        .IsRequired();

                    b.Property<int>("Edad");

                    b.Property<DateTime>("FechaNacimiennto");

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<decimal>("Salario");

                    b.Property<string>("Telefono")
                        .IsRequired();

                    b.Property<string>("indentificacion")
                        .IsRequired();

                    b.HasKey("ClienteID");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("Calculadora_Prestamos.Entidades.Detalle_Prestamo", b =>
                {
                    b.Property<int>("Detalle_PrestamoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Avances");

                    b.Property<double>("BalanceFinal");

                    b.Property<double>("Capital");

                    b.Property<double>("Cuotas");

                    b.Property<DateTime>("FechaPago");

                    b.Property<double>("Interes");

                    b.Property<double>("InteresAcumulado");

                    b.Property<double>("PagoTotal");

                    b.Property<int>("PrestamoID");

                    b.Property<double>("SaldoInicial");

                    b.HasKey("Detalle_PrestamoID");

                    b.HasIndex("PrestamoID");

                    b.ToTable("detalle_prestamo");
                });

            modelBuilder.Entity("Calculadora_Prestamos.Entidades.Prestamo", b =>
                {
                    b.Property<int>("PrestamoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<double>("InteresAnual");

                    b.Property<double>("MontoPrestamo");

                    b.Property<int>("NumeroPagosAnno");

                    b.Property<double>("PagosAdicionales");

                    b.Property<int>("PrediodoPrestamosAnnos");

                    b.Property<int>("UsuarioID");

                    b.HasKey("PrestamoID");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.HasIndex("UsuarioID");

                    b.ToTable("prestamo");
                });

            modelBuilder.Entity("Calculadora_Prestamos.Entidades.Usuario", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contrasena")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.HasKey("UsuarioID");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("Calculadora_Prestamos.Entidades.Detalle_Prestamo", b =>
                {
                    b.HasOne("Calculadora_Prestamos.Entidades.Prestamo", "Prestamo")
                        .WithMany("Detalle_Prestamo")
                        .HasForeignKey("PrestamoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Calculadora_Prestamos.Entidades.Prestamo", b =>
                {
                    b.HasOne("Calculadora_Prestamos.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Calculadora_Prestamos.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
