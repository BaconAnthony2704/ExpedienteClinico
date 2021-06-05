using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ExpClinicoApi.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ArtistaName = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Genre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_album", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clsIncapacidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    estado = table.Column<bool>(nullable: false),
                    tipo = table.Column<bool>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    isRestricciones = table.Column<bool>(nullable: false),
                    isListaAlergia = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clsIncapacidad", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Examens",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GlColorCabello",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idColorCabello = table.Column<int>(nullable: false),
                    colorCabello = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlColorCabello", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GlComSeguro",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    NoPoliza = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlComSeguro", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GlEstadoCivil",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlEstadoCivil", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GlGenero",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlGenero", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GlHospital",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlHospital", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GlTipoPiel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlTipoPiel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    direccionMedico = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "solicitudExamens",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idclsExpediente = table.Column<int>(nullable: false),
                    idGlMedicoGrl = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solicitudExamens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clsInformacionAdicional",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    lugarNacimiento = table.Column<string>(nullable: true),
                    telefonoDomicilio = table.Column<string>(nullable: true),
                    telefonoOficina = table.Column<string>(nullable: true),
                    correo = table.Column<string>(nullable: true),
                    responsableA = table.Column<string>(nullable: true),
                    estadoCivilid = table.Column<int>(nullable: true),
                    conyugue = table.Column<string>(nullable: true),
                    NvoPaciente = table.Column<bool>(nullable: false),
                    fechaIngreso = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clsInformacionAdicional", x => x.id);
                    table.ForeignKey(
                        name: "FK_clsInformacionAdicional_GlEstadoCivil_estadoCivilid",
                        column: x => x.estadoCivilid,
                        principalTable: "GlEstadoCivil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "clsInformacionPersonal",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    titulo = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    domicilio = table.Column<string>(nullable: true),
                    fechaNacimiento = table.Column<DateTime>(nullable: false),
                    generoid = table.Column<int>(nullable: true),
                    NoISSS = table.Column<string>(nullable: true),
                    UrlImagen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clsInformacionPersonal", x => x.id);
                    table.ForeignKey(
                        name: "FK_clsInformacionPersonal_GlGenero_generoid",
                        column: x => x.generoid,
                        principalTable: "GlGenero",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "clsExploracionFisica",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    altura = table.Column<double>(nullable: false),
                    peso = table.Column<double>(nullable: false),
                    tipoPielid = table.Column<int>(nullable: true),
                    marcaNaci = table.Column<string>(nullable: true),
                    colorCabelloid = table.Column<int>(nullable: true),
                    OcupaLentes = table.Column<bool>(nullable: false),
                    PresentaDisca = table.Column<bool>(nullable: false),
                    ProblemaAuditivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clsExploracionFisica", x => x.id);
                    table.ForeignKey(
                        name: "FK_clsExploracionFisica_GlColorCabello_colorCabelloid",
                        column: x => x.colorCabelloid,
                        principalTable: "GlColorCabello",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clsExploracionFisica_GlTipoPiel_tipoPielid",
                        column: x => x.tipoPielid,
                        principalTable: "GlTipoPiel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "clsHistorialMedico",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    medicoGrlid = table.Column<int>(nullable: true),
                    dentistaFamilia = table.Column<string>(nullable: true),
                    ultimaVacuna = table.Column<DateTime>(nullable: false),
                    hospitalid = table.Column<int>(nullable: true),
                    seguroid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clsHistorialMedico", x => x.id);
                    table.ForeignKey(
                        name: "FK_clsHistorialMedico_GlHospital_hospitalid",
                        column: x => x.hospitalid,
                        principalTable: "GlHospital",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clsHistorialMedico_Medicos_medicoGrlid",
                        column: x => x.medicoGrlid,
                        principalTable: "Medicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clsHistorialMedico_GlComSeguro_seguroid",
                        column: x => x.seguroid,
                        principalTable: "GlComSeguro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleSolicitudExamens",
                columns: table => new
                {
                    clsSolicitudExamenId = table.Column<int>(nullable: false),
                    clsExamenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleSolicitudExamens", x => new { x.clsSolicitudExamenId, x.clsExamenId });
                    table.ForeignKey(
                        name: "FK_DetalleSolicitudExamens_Examens_clsExamenId",
                        column: x => x.clsExamenId,
                        principalTable: "Examens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleSolicitudExamens_solicitudExamens_clsSolicitudExamenId",
                        column: x => x.clsSolicitudExamenId,
                        principalTable: "solicitudExamens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expedientes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idInformacionPersonal = table.Column<int>(nullable: true),
                    idInformacionAdicional = table.Column<int>(nullable: true),
                    idExploracionFisica = table.Column<int>(nullable: true),
                    idHistoralMedico = table.Column<int>(nullable: true),
                    idAlergias = table.Column<int>(nullable: true),
                    idIncapacidad = table.Column<int>(nullable: true),
                    informacionPersonalid = table.Column<int>(nullable: true),
                    informacionAdicionalid = table.Column<int>(nullable: true),
                    exploracionFisicaid = table.Column<int>(nullable: true),
                    historialMedicoid = table.Column<int>(nullable: true),
                    incapacidadid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expedientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Expedientes_clsExploracionFisica_exploracionFisicaid",
                        column: x => x.exploracionFisicaid,
                        principalTable: "clsExploracionFisica",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expedientes_clsHistorialMedico_historialMedicoid",
                        column: x => x.historialMedicoid,
                        principalTable: "clsHistorialMedico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expedientes_clsIncapacidad_incapacidadid",
                        column: x => x.incapacidadid,
                        principalTable: "clsIncapacidad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expedientes_clsInformacionAdicional_informacionAdicionalid",
                        column: x => x.informacionAdicionalid,
                        principalTable: "clsInformacionAdicional",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expedientes_clsInformacionPersonal_informacionPersonalid",
                        column: x => x.informacionPersonalid,
                        principalTable: "clsInformacionPersonal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "clsAlergia",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    estado = table.Column<bool>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    clsExpedienteid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clsAlergia", x => x.id);
                    table.ForeignKey(
                        name: "FK_clsAlergia_Expedientes_clsExpedienteid",
                        column: x => x.clsExpedienteid,
                        principalTable: "Expedientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clsAlergia_clsExpedienteid",
                table: "clsAlergia",
                column: "clsExpedienteid");

            migrationBuilder.CreateIndex(
                name: "IX_clsExploracionFisica_colorCabelloid",
                table: "clsExploracionFisica",
                column: "colorCabelloid");

            migrationBuilder.CreateIndex(
                name: "IX_clsExploracionFisica_tipoPielid",
                table: "clsExploracionFisica",
                column: "tipoPielid");

            migrationBuilder.CreateIndex(
                name: "IX_clsHistorialMedico_hospitalid",
                table: "clsHistorialMedico",
                column: "hospitalid");

            migrationBuilder.CreateIndex(
                name: "IX_clsHistorialMedico_medicoGrlid",
                table: "clsHistorialMedico",
                column: "medicoGrlid");

            migrationBuilder.CreateIndex(
                name: "IX_clsHistorialMedico_seguroid",
                table: "clsHistorialMedico",
                column: "seguroid");

            migrationBuilder.CreateIndex(
                name: "IX_clsInformacionAdicional_estadoCivilid",
                table: "clsInformacionAdicional",
                column: "estadoCivilid");

            migrationBuilder.CreateIndex(
                name: "IX_clsInformacionPersonal_generoid",
                table: "clsInformacionPersonal",
                column: "generoid");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSolicitudExamens_clsExamenId",
                table: "DetalleSolicitudExamens",
                column: "clsExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_exploracionFisicaid",
                table: "Expedientes",
                column: "exploracionFisicaid");

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_historialMedicoid",
                table: "Expedientes",
                column: "historialMedicoid");

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_incapacidadid",
                table: "Expedientes",
                column: "incapacidadid");

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_informacionAdicionalid",
                table: "Expedientes",
                column: "informacionAdicionalid");

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_informacionPersonalid",
                table: "Expedientes",
                column: "informacionPersonalid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "album");

            migrationBuilder.DropTable(
                name: "clsAlergia");

            migrationBuilder.DropTable(
                name: "DetalleSolicitudExamens");

            migrationBuilder.DropTable(
                name: "Expedientes");

            migrationBuilder.DropTable(
                name: "Examens");

            migrationBuilder.DropTable(
                name: "solicitudExamens");

            migrationBuilder.DropTable(
                name: "clsExploracionFisica");

            migrationBuilder.DropTable(
                name: "clsHistorialMedico");

            migrationBuilder.DropTable(
                name: "clsIncapacidad");

            migrationBuilder.DropTable(
                name: "clsInformacionAdicional");

            migrationBuilder.DropTable(
                name: "clsInformacionPersonal");

            migrationBuilder.DropTable(
                name: "GlColorCabello");

            migrationBuilder.DropTable(
                name: "GlTipoPiel");

            migrationBuilder.DropTable(
                name: "GlHospital");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "GlComSeguro");

            migrationBuilder.DropTable(
                name: "GlEstadoCivil");

            migrationBuilder.DropTable(
                name: "GlGenero");
        }
    }
}
