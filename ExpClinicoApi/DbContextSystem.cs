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
        
        
        public DbSet<Models.Global.GlMedicoGrl> Medicos { get; set; }
        public DbSet<clsSolicitudExamen> solicitudExamens { get; set; }
        public DbSet<clsDetalleSolicitudExamen> DetalleSolicitudExamens { get; set; }
        public DbSet<clsExamen> Examens { get; set; }
        public DbSet<clsExpediente> Expedientes { get; set; }
        public DbSet<ClsCita> citas { get; set; }
        public DbSet<Models.ClsDoctor> MedicosGeneral { get; set; }
        public DbSet<Models.ClsPaciente> Pacientes { get; set; }




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
            
            
            modelBuilder.Entity<clsDetalleSolicitudExamen>().HasKey(x => new {x.clsSolicitudExamenId, x.clsExamenId });
            
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
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;database=prueba;port=3306;password='';");
            }
        }
    }
}
