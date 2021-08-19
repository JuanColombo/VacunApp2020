using Microsoft.EntityFrameworkCore;
using System;

namespace VacunApp.Models
{
    public class VacunAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database = VacunAppContext; User Id = sa; Password = juampi582674; MultipleActiveResultSets = True; ");
        }
        //Datos Semilla solo se va a ejecutar cuando la base de datos se crea.. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacuna>().HasData(
                new Vacuna { Id = 1, Nombre = "BCG", PeriodoAplicacion = 0, Beneficios = "Tuberculosis (formas invasivas)" },
                new Vacuna { Id = 2, Nombre = "Hepatitis B HB", PeriodoAplicacion = 0, Beneficios = "HB: Hepatitis B)" },
                new Vacuna { Id = 3, Nombre = "Neumococo Conjugada", PeriodoAplicacion = 2, Beneficios = "Previene la meningitis, Neumonia y Septis por Neumococo" },
                new Vacuna { Id = 4, Nombre = "Quintuple Pentavalente DTP-HB-Hib", PeriodoAplicacion = 2, Beneficios = "Difteria, Tétanos, Tos Convulsa, Hep B, Haemophilus Influenzae b" },
                new Vacuna { Id = 5, Nombre = "Polio IPV", PeriodoAplicacion = 2, Beneficios = "Poliovirus inactiva)" }
                );
            modelBuilder.Entity<Tutor>().HasData(
                new Tutor { Id = 1, Nombre = "Juan Pablo", Apellido = "Colombo", Email = "juampicolombosj@gmail.com), " },
                new Tutor { Id = 2, Nombre = "Daiana Antonella", Apellido = "Squaglia", Email = "daisquaglia05@gmail.com), " },
                new Tutor { Id = 3, Nombre = "Patricia Josefa", Apellido = "Garate", Email = "patrigarate4@gmail.com), " },
                new Tutor { Id = 4, Nombre = "Julian Daniel", Apellido = "Parra", Email = "jparra@hotmail.com), " });
            modelBuilder.Entity<Paciente>().HasData(
                new Paciente { Id = 1, Nombre = "Maximo Lisandro", Apellido = "Garcia", Dni = 45665945, Domicilio = "Santa Fe 1685", FechaNacimiento = new DateTime(2000, 1, 30), Sexo = SexoEnum.Masculino, Prematuro = false, Peso = 3, CalendarioId = 1, TutorId = 1 }
                );
            modelBuilder.Entity<Calendario>().HasData(
                new Calendario { Id = 1, Nombre = "Calendario varon", SexoPaciente = SexoEnum.Masculino },
                new Calendario { Id = 2, Nombre = "Calendario mujer", SexoPaciente = SexoEnum.Masculino },
                new Calendario { Id = 3, Nombre = "Calendario varon prematuro", SexoPaciente = SexoEnum.Masculino },
                new Calendario { Id = 4, Nombre = "Calendario mujer prematuro", SexoPaciente = SexoEnum.Masculino }
                );
            modelBuilder.Entity<DetalleCalendario>().HasData(
                new DetalleCalendario { Id = 1, CalendarioId = 1, VacunaId = 1 },
                new DetalleCalendario { Id = 2, CalendarioId = 1, VacunaId = 2 },
                new DetalleCalendario { Id = 3, CalendarioId = 1, VacunaId = 3 },
                new DetalleCalendario { Id = 4, CalendarioId = 1, VacunaId = 4 },
                new DetalleCalendario { Id = 5, CalendarioId = 2, VacunaId = 1 },
                new DetalleCalendario { Id = 6, CalendarioId = 2, VacunaId = 2 },
                new DetalleCalendario { Id = 7, CalendarioId = 2, VacunaId = 3 },
                new DetalleCalendario { Id = 8, CalendarioId = 2, VacunaId = 4 }
                );
        }
               
        public DbSet<Calendario> Calendarios { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<DetalleCalendario> DetalleCalendarios { get; set; }
        public DbSet<VacunaColocada> VacunasColocadas { get; set; }

        public VacunAppContext(DbContextOptions<VacunAppContext> options) : base(options)
        {
            
        }

        public VacunAppContext()
        {
        }
    }
}
