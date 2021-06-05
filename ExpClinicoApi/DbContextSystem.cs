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
        
        public DbSet<Album> Albunes { get; set; }

        public DbSet<Models.Global.GlMedicoGrl> Medicos { get; set; }
        public DbSet<clsSolicitudExamen> solicitudExamens { get; set; }
        public DbSet<clsDetalleSolicitudExamen> DetalleSolicitudExamens { get; set; }
        public DbSet<clsExamen> Examens { get; set; }
        public DbSet<clsExpediente> Expedientes { get; set; }




        

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

            modelBuilder.Entity<clsDetalleSolicitudExamen>().HasKey(x => new { x.idclsSolicitudExamen, x.idclsExamen });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;database=clinica;port=3306;password='';");
            }
        }
    }
}
