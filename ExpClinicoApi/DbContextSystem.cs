using ExpClinicoApi.Mapping;
using ExpClinicoApi.Models;
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
