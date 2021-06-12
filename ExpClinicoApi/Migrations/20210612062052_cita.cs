using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ExpClinicoApi.Migrations
{
    public partial class cita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "NvoPaciente",
                table: "clsInformacionAdicional",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "tipo",
                table: "clsIncapacidad",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "isRestricciones",
                table: "clsIncapacidad",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "isListaAlergia",
                table: "clsIncapacidad",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "clsIncapacidad",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "ProblemaAuditivo",
                table: "clsExploracionFisica",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "PresentaDisca",
                table: "clsExploracionFisica",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "OcupaLentes",
                table: "clsExploracionFisica",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "clsAlergia",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "citas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombrePaciente = table.Column<string>(nullable: true),
                    dateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citas", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "citas");

            migrationBuilder.AlterColumn<ulong>(
                name: "NvoPaciente",
                table: "clsInformacionAdicional",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<ulong>(
                name: "tipo",
                table: "clsIncapacidad",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<ulong>(
                name: "isRestricciones",
                table: "clsIncapacidad",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<ulong>(
                name: "isListaAlergia",
                table: "clsIncapacidad",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<ulong>(
                name: "estado",
                table: "clsIncapacidad",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<ulong>(
                name: "ProblemaAuditivo",
                table: "clsExploracionFisica",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<ulong>(
                name: "PresentaDisca",
                table: "clsExploracionFisica",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<ulong>(
                name: "OcupaLentes",
                table: "clsExploracionFisica",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<ulong>(
                name: "estado",
                table: "clsAlergia",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
