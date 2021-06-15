﻿// <auto-generated />
using System;
using ExpClinicoApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExpClinicoApi.Migrations
{
    [DbContext(typeof(DbContextSystem))]
    partial class DbContextSystemModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ExpClinicoApi.Models.ClsCita", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("nombrePaciente")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("citas");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.ClsDoctor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nombreDoctor")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("MedicosGeneral");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.ClsPaciente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nombrePaciente")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.Global.GlColorCabello", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("colorCabello")
                        .HasColumnType("text");

                    b.Property<int>("idColorCabello")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("GlColorCabello");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.Global.GlComSeguro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NoPoliza")
                        .HasColumnType("text");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("GlComSeguro");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.Global.GlEstadoCivil", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("estado")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("GlEstadoCivil");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.Global.GlGenero", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("tipo")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("GlGenero");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.Global.GlHospital", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("direccion")
                        .HasColumnType("text");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("GlHospital");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.Global.GlMedicoGrl", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("direccionMedico")
                        .HasColumnType("text");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<string>("telefono")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.Global.GlTipoPiel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("tipo")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("GlTipoPiel");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsAlergia", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("clsExpedienteid")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("clsExpedienteid");

                    b.ToTable("clsAlergia");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsDetalleSolicitudExamen", b =>
                {
                    b.Property<int>("clsSolicitudExamenId")
                        .HasColumnType("int");

                    b.Property<int>("clsExamenId")
                        .HasColumnType("int");

                    b.HasKey("clsSolicitudExamenId", "clsExamenId");

                    b.HasIndex("clsExamenId");

                    b.ToTable("DetalleSolicitudExamens");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsExamen", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Examens");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsExpediente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("exploracionFisicaid")
                        .HasColumnType("int");

                    b.Property<int?>("historialMedicoid")
                        .HasColumnType("int");

                    b.Property<int?>("idAlergias")
                        .HasColumnType("int");

                    b.Property<int?>("idExploracionFisica")
                        .HasColumnType("int");

                    b.Property<int?>("idHistoralMedico")
                        .HasColumnType("int");

                    b.Property<int?>("idIncapacidad")
                        .HasColumnType("int");

                    b.Property<int?>("idInformacionAdicional")
                        .HasColumnType("int");

                    b.Property<int?>("idInformacionPersonal")
                        .HasColumnType("int");

                    b.Property<int?>("incapacidadid")
                        .HasColumnType("int");

                    b.Property<int?>("informacionAdicionalid")
                        .HasColumnType("int");

                    b.Property<int?>("informacionPersonalid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("exploracionFisicaid");

                    b.HasIndex("historialMedicoid");

                    b.HasIndex("incapacidadid");

                    b.HasIndex("informacionAdicionalid");

                    b.HasIndex("informacionPersonalid");

                    b.ToTable("Expedientes");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsExploracionFisica", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("OcupaLentes")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("PresentaDisca")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("ProblemaAuditivo")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("altura")
                        .HasColumnType("double");

                    b.Property<int?>("colorCabelloid")
                        .HasColumnType("int");

                    b.Property<string>("marcaNaci")
                        .HasColumnType("text");

                    b.Property<double>("peso")
                        .HasColumnType("double");

                    b.Property<int?>("tipoPielid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("colorCabelloid");

                    b.HasIndex("tipoPielid");

                    b.ToTable("clsExploracionFisica");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsHistorialMedico", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("dentistaFamilia")
                        .HasColumnType("text");

                    b.Property<int?>("hospitalid")
                        .HasColumnType("int");

                    b.Property<int?>("medicoGrlid")
                        .HasColumnType("int");

                    b.Property<int?>("seguroid")
                        .HasColumnType("int");

                    b.Property<DateTime>("ultimaVacuna")
                        .HasColumnType("datetime");

                    b.HasKey("id");

                    b.HasIndex("hospitalid");

                    b.HasIndex("medicoGrlid");

                    b.HasIndex("seguroid");

                    b.ToTable("clsHistorialMedico");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsIncapacidad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isListaAlergia")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isRestricciones")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<bool>("tipo")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("id");

                    b.ToTable("clsIncapacidad");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsInformacionAdicional", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("NvoPaciente")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("conyugue")
                        .HasColumnType("text");

                    b.Property<string>("correo")
                        .HasColumnType("text");

                    b.Property<int?>("estadoCivilid")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaIngreso")
                        .HasColumnType("datetime");

                    b.Property<string>("lugarNacimiento")
                        .HasColumnType("text");

                    b.Property<string>("responsableA")
                        .HasColumnType("text");

                    b.Property<string>("telefonoDomicilio")
                        .HasColumnType("text");

                    b.Property<string>("telefonoOficina")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("estadoCivilid");

                    b.ToTable("clsInformacionAdicional");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsInformacionPersonal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NoISSS")
                        .HasColumnType("text");

                    b.Property<string>("UrlImagen")
                        .HasColumnType("text");

                    b.Property<string>("apellido")
                        .HasColumnType("text");

                    b.Property<string>("domicilio")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("datetime");

                    b.Property<int?>("generoid")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<string>("titulo")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("generoid");

                    b.ToTable("clsInformacionPersonal");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsSolicitudExamen", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime");

                    b.Property<int>("idClsDoctor")
                        .HasColumnType("int");

                    b.Property<int>("idClsPaciente")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("solicitudExamens");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsAlergia", b =>
                {
                    b.HasOne("ExpClinicoApi.Models.clsExpediente", null)
                        .WithMany("alergias")
                        .HasForeignKey("clsExpedienteid");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsDetalleSolicitudExamen", b =>
                {
                    b.HasOne("ExpClinicoApi.Models.clsExamen", "clsExamen")
                        .WithMany("detalleExamenes")
                        .HasForeignKey("clsExamenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpClinicoApi.Models.clsSolicitudExamen", "clsSolicitudExamen")
                        .WithMany("detalleExamenes")
                        .HasForeignKey("clsSolicitudExamenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsExpediente", b =>
                {
                    b.HasOne("ExpClinicoApi.Models.clsExploracionFisica", "exploracionFisica")
                        .WithMany()
                        .HasForeignKey("exploracionFisicaid");

                    b.HasOne("ExpClinicoApi.Models.clsHistorialMedico", "historialMedico")
                        .WithMany()
                        .HasForeignKey("historialMedicoid");

                    b.HasOne("ExpClinicoApi.Models.clsIncapacidad", "incapacidad")
                        .WithMany()
                        .HasForeignKey("incapacidadid");

                    b.HasOne("ExpClinicoApi.Models.clsInformacionAdicional", "informacionAdicional")
                        .WithMany()
                        .HasForeignKey("informacionAdicionalid");

                    b.HasOne("ExpClinicoApi.Models.clsInformacionPersonal", "informacionPersonal")
                        .WithMany()
                        .HasForeignKey("informacionPersonalid");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsExploracionFisica", b =>
                {
                    b.HasOne("ExpClinicoApi.Models.Global.GlColorCabello", "colorCabello")
                        .WithMany()
                        .HasForeignKey("colorCabelloid");

                    b.HasOne("ExpClinicoApi.Models.Global.GlTipoPiel", "tipoPiel")
                        .WithMany()
                        .HasForeignKey("tipoPielid");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsHistorialMedico", b =>
                {
                    b.HasOne("ExpClinicoApi.Models.Global.GlHospital", "hospital")
                        .WithMany()
                        .HasForeignKey("hospitalid");

                    b.HasOne("ExpClinicoApi.Models.Global.GlMedicoGrl", "medicoGrl")
                        .WithMany()
                        .HasForeignKey("medicoGrlid");

                    b.HasOne("ExpClinicoApi.Models.Global.GlComSeguro", "seguro")
                        .WithMany()
                        .HasForeignKey("seguroid");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsInformacionAdicional", b =>
                {
                    b.HasOne("ExpClinicoApi.Models.Global.GlEstadoCivil", "estadoCivil")
                        .WithMany()
                        .HasForeignKey("estadoCivilid");
                });

            modelBuilder.Entity("ExpClinicoApi.Models.clsInformacionPersonal", b =>
                {
                    b.HasOne("ExpClinicoApi.Models.Global.GlGenero", "genero")
                        .WithMany()
                        .HasForeignKey("generoid");
                });
#pragma warning restore 612, 618
        }
    }
}
