using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpClinicoApi.Migrations
{
    public partial class modificaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idGlMedicoGrl",
                table: "solicitudExamens");

            migrationBuilder.DropColumn(
                name: "idclsExpediente",
                table: "solicitudExamens");

            migrationBuilder.AddColumn<int>(
                name: "idClsDoctor",
                table: "solicitudExamens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idClsPaciente",
                table: "solicitudExamens",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idClsDoctor",
                table: "solicitudExamens");

            migrationBuilder.DropColumn(
                name: "idClsPaciente",
                table: "solicitudExamens");

            migrationBuilder.AddColumn<int>(
                name: "idGlMedicoGrl",
                table: "solicitudExamens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idclsExpediente",
                table: "solicitudExamens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
