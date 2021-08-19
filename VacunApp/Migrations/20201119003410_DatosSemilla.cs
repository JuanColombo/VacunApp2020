using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VacunApp.Migrations
{
    public partial class DatosSemilla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    SexoPaciente = table.Column<int>(nullable: false),
                    PrematuroPaciente = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tutores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacunas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    PeriodoAplicacion = table.Column<int>(nullable: false),
                    Beneficios = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Dni = table.Column<int>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    Prematuro = table.Column<bool>(nullable: false),
                    Peso = table.Column<double>(nullable: false),
                    Domicilio = table.Column<string>(nullable: false),
                    TutorId = table.Column<int>(nullable: false),
                    CalendarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Calendarios_CalendarioId",
                        column: x => x.CalendarioId,
                        principalTable: "Calendarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_Tutores_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCalendarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarioId = table.Column<int>(nullable: false),
                    VacunaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCalendarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleCalendarios_Calendarios_CalendarioId",
                        column: x => x.CalendarioId,
                        principalTable: "Calendarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCalendarios_Vacunas_VacunaId",
                        column: x => x.VacunaId,
                        principalTable: "Vacunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacunasColocadas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacunaId = table.Column<int>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacunasColocadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacunasColocadas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacunasColocadas_Vacunas_VacunaId",
                        column: x => x.VacunaId,
                        principalTable: "Vacunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Calendarios",
                columns: new[] { "Id", "Nombre", "PrematuroPaciente", "SexoPaciente" },
                values: new object[,]
                {
                    { 1, "Calendario varon", false, 1 },
                    { 2, "Calendario mujer", false, 1 },
                    { 3, "Calendario varon prematuro", false, 1 },
                    { 4, "Calendario mujer prematuro", false, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tutores",
                columns: new[] { "Id", "Apellido", "Email", "Nombre" },
                values: new object[,]
                {
                    { 1, "Colombo", "juampicolombosj@gmail.com), ", "Juan Pablo" },
                    { 2, "Squaglia", "daisquaglia05@gmail.com), ", "Daiana Antonella" },
                    { 3, "Garate", "patrigarate4@gmail.com), ", "Patricia Josefa" },
                    { 4, "Parra", "jparra@hotmail.com), ", "Julian Daniel" }
                });

            migrationBuilder.InsertData(
                table: "Vacunas",
                columns: new[] { "Id", "Beneficios", "Nombre", "PeriodoAplicacion" },
                values: new object[,]
                {
                    { 1, "Tuberculosis (formas invasivas)", "BCG", 0 },
                    { 2, "HB: Hepatitis B)", "Hepatitis B HB", 0 },
                    { 3, "Previene la meningitis, Neumonia y Septis por Neumococo", "Neumococo Conjugada", 2 },
                    { 4, "Difteria, Tétanos, Tos Convulsa, Hep B, Haemophilus Influenzae b", "Quintuple Pentavalente DTP-HB-Hib", 2 },
                    { 5, "Poliovirus inactiva)", "Polio IPV", 2 }
                });

            migrationBuilder.InsertData(
                table: "DetalleCalendarios",
                columns: new[] { "Id", "CalendarioId", "VacunaId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 5, 2, 1 },
                    { 2, 1, 2 },
                    { 6, 2, 2 },
                    { 3, 1, 3 },
                    { 7, 2, 3 },
                    { 4, 1, 4 },
                    { 8, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "Apellido", "CalendarioId", "Dni", "Domicilio", "FechaNacimiento", "Nombre", "Peso", "Prematuro", "Sexo", "TutorId" },
                values: new object[] { 1, "Garcia", 1, 45665945, "Santa Fe 1685", new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maximo Lisandro", 3.0, false, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCalendarios_CalendarioId",
                table: "DetalleCalendarios",
                column: "CalendarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCalendarios_VacunaId",
                table: "DetalleCalendarios",
                column: "VacunaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_CalendarioId",
                table: "Pacientes",
                column: "CalendarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_TutorId",
                table: "Pacientes",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_VacunasColocadas_PacienteId",
                table: "VacunasColocadas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_VacunasColocadas_VacunaId",
                table: "VacunasColocadas",
                column: "VacunaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleCalendarios");

            migrationBuilder.DropTable(
                name: "VacunasColocadas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Vacunas");

            migrationBuilder.DropTable(
                name: "Calendarios");

            migrationBuilder.DropTable(
                name: "Tutores");
        }
    }
}
