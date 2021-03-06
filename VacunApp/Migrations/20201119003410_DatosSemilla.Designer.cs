// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VacunApp.Models;

namespace VacunApp.Migrations
{
    [DbContext(typeof(VacunAppContext))]
    [Migration("20201119003410_DatosSemilla")]
    partial class DatosSemilla
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VacunApp.Models.Calendario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PrematuroPaciente")
                        .HasColumnType("bit");

                    b.Property<int>("SexoPaciente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Calendarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Calendario varon",
                            PrematuroPaciente = false,
                            SexoPaciente = 1
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Calendario mujer",
                            PrematuroPaciente = false,
                            SexoPaciente = 1
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Calendario varon prematuro",
                            PrematuroPaciente = false,
                            SexoPaciente = 1
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Calendario mujer prematuro",
                            PrematuroPaciente = false,
                            SexoPaciente = 1
                        });
                });

            modelBuilder.Entity("VacunApp.Models.DetalleCalendario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CalendarioId")
                        .HasColumnType("int");

                    b.Property<int>("VacunaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CalendarioId");

                    b.HasIndex("VacunaId");

                    b.ToTable("DetalleCalendarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CalendarioId = 1,
                            VacunaId = 1
                        },
                        new
                        {
                            Id = 2,
                            CalendarioId = 1,
                            VacunaId = 2
                        },
                        new
                        {
                            Id = 3,
                            CalendarioId = 1,
                            VacunaId = 3
                        },
                        new
                        {
                            Id = 4,
                            CalendarioId = 1,
                            VacunaId = 4
                        },
                        new
                        {
                            Id = 5,
                            CalendarioId = 2,
                            VacunaId = 1
                        },
                        new
                        {
                            Id = 6,
                            CalendarioId = 2,
                            VacunaId = 2
                        },
                        new
                        {
                            Id = 7,
                            CalendarioId = 2,
                            VacunaId = 3
                        },
                        new
                        {
                            Id = 8,
                            CalendarioId = 2,
                            VacunaId = 4
                        });
                });

            modelBuilder.Entity("VacunApp.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CalendarioId")
                        .HasColumnType("int");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.Property<bool>("Prematuro")
                        .HasColumnType("bit");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CalendarioId");

                    b.HasIndex("TutorId");

                    b.ToTable("Pacientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Garcia",
                            CalendarioId = 1,
                            Dni = 45665945,
                            Domicilio = "Santa Fe 1685",
                            FechaNacimiento = new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Maximo Lisandro",
                            Peso = 3.0,
                            Prematuro = false,
                            Sexo = 1,
                            TutorId = 1
                        });
                });

            modelBuilder.Entity("VacunApp.Models.Tutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tutores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Colombo",
                            Email = "juampicolombosj@gmail.com), ",
                            Nombre = "Juan Pablo"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Squaglia",
                            Email = "daisquaglia05@gmail.com), ",
                            Nombre = "Daiana Antonella"
                        },
                        new
                        {
                            Id = 3,
                            Apellido = "Garate",
                            Email = "patrigarate4@gmail.com), ",
                            Nombre = "Patricia Josefa"
                        },
                        new
                        {
                            Id = 4,
                            Apellido = "Parra",
                            Email = "jparra@hotmail.com), ",
                            Nombre = "Julian Daniel"
                        });
                });

            modelBuilder.Entity("VacunApp.Models.Vacuna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beneficios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeriodoAplicacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vacunas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Beneficios = "Tuberculosis (formas invasivas)",
                            Nombre = "BCG",
                            PeriodoAplicacion = 0
                        },
                        new
                        {
                            Id = 2,
                            Beneficios = "HB: Hepatitis B)",
                            Nombre = "Hepatitis B HB",
                            PeriodoAplicacion = 0
                        },
                        new
                        {
                            Id = 3,
                            Beneficios = "Previene la meningitis, Neumonia y Septis por Neumococo",
                            Nombre = "Neumococo Conjugada",
                            PeriodoAplicacion = 2
                        },
                        new
                        {
                            Id = 4,
                            Beneficios = "Difteria, Tétanos, Tos Convulsa, Hep B, Haemophilus Influenzae b",
                            Nombre = "Quintuple Pentavalente DTP-HB-Hib",
                            PeriodoAplicacion = 2
                        },
                        new
                        {
                            Id = 5,
                            Beneficios = "Poliovirus inactiva)",
                            Nombre = "Polio IPV",
                            PeriodoAplicacion = 2
                        });
                });

            modelBuilder.Entity("VacunApp.Models.VacunaColocada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("VacunaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.HasIndex("VacunaId");

                    b.ToTable("VacunasColocadas");
                });

            modelBuilder.Entity("VacunApp.Models.DetalleCalendario", b =>
                {
                    b.HasOne("VacunApp.Models.Calendario", "Calendario")
                        .WithMany()
                        .HasForeignKey("CalendarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VacunApp.Models.Vacuna", "Vacuna")
                        .WithMany()
                        .HasForeignKey("VacunaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VacunApp.Models.Paciente", b =>
                {
                    b.HasOne("VacunApp.Models.Calendario", "Calendario")
                        .WithMany("Pacientes")
                        .HasForeignKey("CalendarioId");

                    b.HasOne("VacunApp.Models.Tutor", "Tutor")
                        .WithMany("Pacientes")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VacunApp.Models.VacunaColocada", b =>
                {
                    b.HasOne("VacunApp.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VacunApp.Models.Vacuna", "Vacuna")
                        .WithMany()
                        .HasForeignKey("VacunaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
