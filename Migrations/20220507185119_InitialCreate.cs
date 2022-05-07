using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hosApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Tel = table.Column<string>(type: "TEXT", nullable: true),
                    Adress = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Speciality = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Tel = table.Column<string>(type: "TEXT", nullable: true),
                    Adress = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PatientRef = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Case_Patient_PatientRef",
                        column: x => x.PatientRef,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdDoctor = table.Column<int>(type: "INTEGER", nullable: false),
                    doctorID = table.Column<int>(type: "INTEGER", nullable: true),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    Height = table.Column<float>(type: "REAL", nullable: false),
                    diagnostic = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    idCase = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Consultation_Case_idCase",
                        column: x => x.idCase,
                        principalTable: "Case",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultation_Doctor_doctorID",
                        column: x => x.doctorID,
                        principalTable: "Doctor",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idConsul = table.Column<int>(type: "INTEGER", nullable: false),
                    prescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prescription_Consultation_idConsul",
                        column: x => x.idConsul,
                        principalTable: "Consultation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Case_PatientRef",
                table: "Case",
                column: "PatientRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_doctorID",
                table: "Consultation",
                column: "doctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_idCase",
                table: "Consultation",
                column: "idCase",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_idConsul",
                table: "Prescription",
                column: "idConsul",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Consultation");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
