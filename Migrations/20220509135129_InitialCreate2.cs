using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hosApp.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_Case_idCase",
                table: "Consultation");

            migrationBuilder.DropIndex(
                name: "IX_Consultation_idCase",
                table: "Consultation");

            migrationBuilder.AddColumn<int>(
                name: "CaseID",
                table: "Consultation",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_CaseID",
                table: "Consultation",
                column: "CaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_Case_CaseID",
                table: "Consultation",
                column: "CaseID",
                principalTable: "Case",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_Case_CaseID",
                table: "Consultation");

            migrationBuilder.DropIndex(
                name: "IX_Consultation_CaseID",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "CaseID",
                table: "Consultation");

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_idCase",
                table: "Consultation",
                column: "idCase",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_Case_idCase",
                table: "Consultation",
                column: "idCase",
                principalTable: "Case",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
