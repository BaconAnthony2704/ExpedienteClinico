using ExpClinicoApi.Mapping;
using ExpClinicoApi.Mapping.Componets;
using ExpClinicoApi.Models;
using ExpClinicoApi.Models.Components;
using ExpClinicoApi.Models.Global;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi
{
    public class DbContextSystem:DbContext
    {
        
        public DbSet<Album> Albunes { get; set; }
        public DbSet<clsExpediente> Expedientes { get; set; }
        public DbSet<clsInformacionPersonal> InformacionPersonales { get; set; }
        public DbSet<clsInformacionAdicional> InformacionAdicionales { get; set; }
        public DbSet<clsHistorialMedico> HistorialMedicos { get; set; }
        public DbSet<clsIncapacidad> Incapacidades { get; set; }
        public DbSet<clsExploracionFisica> ExploracionesFisicas { get; set; }
        public DbSet<clsAlergia> Alergias { get; set; }
        public DbSet<pivoteAlergiaExp> pivoteAlergiaExps { get; set; }
        public DbSet<pivoteIncapacidadExpediente> pivoteIncapacidadExpedientes { get; set; }

        public DbSet<GlMedicoGrl> medicos  { get; set; }
        public DbSet<GlComSeguro> seguros { get; set; }
        public DbSet<GlGenero> generos { get; set; }
        public DbSet<GlEstadoCivil> EstadoCivils { get; set; }
        public DbSet<GlTipoPiel> TipoPiels { get; set; }
        public DbSet<GlColorCabello> ColorCabellos { get; set; }
        public DbSet<GlHospital> Hospitales { get; set; }
        public DbSet<clsLoginUserModel> Logins { get; set; }


        //nuevos DbSet de examen
        public DbSet<clsExamen> Examenes { get; set; }
        public DbSet<clsPaciente> Pacientes { get; set; }
        public DbSet<clsSolicitudExamen> SolicitudExamenes { get; set; }
        public DbSet<clsDetalleSolicitudExamen> DetalleSolicitudExamenes { get; set; }

        public DbSet<clsCita> citas { get; set; } 

        //DbSet para consulta
        public DbSet<clsTipoConsulta> TipoConsulta { get; set; }
        public DbSet<clsReceta> Receta { get; set; }
        public DbSet<clsConsulta> Consulta { get; set; }
        public DbSet<clsSignosVitales> SignosVitales { get; set; }

        //DbSet de componente Vue
        public DbSet<Tarjeta> Tarjetas { get; set; }

        public string ConnectionString { get; set; }
        public DbContextSystem()
        {
           
        }
        public DbContextSystem(DbContextOptions<DbContext> options):base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AlbumMapping());
            modelBuilder.ApplyConfiguration(new AlergiaExpMapping());
            modelBuilder.ApplyConfiguration(new AlergiaMapping());
            modelBuilder.ApplyConfiguration(new ColorCabelloMapping());
            modelBuilder.ApplyConfiguration(new ConSeguroMapping());
            modelBuilder.ApplyConfiguration(new EstadoCivilMapping());
            modelBuilder.ApplyConfiguration(new ExpedienteMapping());
            modelBuilder.ApplyConfiguration(new ExploracionFisicaMapping());
            modelBuilder.ApplyConfiguration(new GeneroMapping());
            modelBuilder.ApplyConfiguration(new HistorialMedicoMapping());
            modelBuilder.ApplyConfiguration(new HistorialMedicoMapping());
            modelBuilder.ApplyConfiguration(new HospitalMapping());
            modelBuilder.ApplyConfiguration(new IncapacidadMapping());
            modelBuilder.ApplyConfiguration(new IncapacidadExpMapping());
            modelBuilder.ApplyConfiguration(new InformacionAdicionalMapping());
            modelBuilder.ApplyConfiguration(new InformacionPersonalMapping());
            modelBuilder.ApplyConfiguration(new MedicoGrlMapping());
            modelBuilder.ApplyConfiguration(new TipoPielMapping());
            modelBuilder.ApplyConfiguration(new TarjetaMapping());
            //Nuevos mapping
            modelBuilder.ApplyConfiguration(new PacienteMapping());
            modelBuilder.ApplyConfiguration(new ExamenMapping());
            modelBuilder.ApplyConfiguration(new SolicitudExamenMapping());
            modelBuilder.ApplyConfiguration(new DetalleSolicitudExamenMapping());
            //agreggo mapping de citas
            modelBuilder.ApplyConfiguration(new CitaMapping());

            //mapping para la consulta
            modelBuilder.ApplyConfiguration(new TipoConsultaMapping());
            modelBuilder.ApplyConfiguration(new RecetaMapping());
            modelBuilder.ApplyConfiguration(new ConsultaMapping());
            modelBuilder.ApplyConfiguration(new SignosVitalesMapping());

            //mapping de login
            modelBuilder.ApplyConfiguration(new LoginUserMapping());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySQL("server=remotemysql.com;user=3ExE2H1Roh;port=3306;database=3ExE2H1Roh;password='Zr6eXf4jyi';");

                //optionsBuilder.UseMySQL("server=localhost;user=root;database=clinica;port=3306;password='';");
            }
        }
    }
}
