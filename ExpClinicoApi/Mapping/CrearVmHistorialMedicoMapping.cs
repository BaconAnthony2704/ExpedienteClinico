using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ExpClinicoApi.ViewModels.Crear;

namespace ExpClinicoApi.Mapping
{
    public class CrearVmHistorialMedicoMapping : IEntityTypeConfiguration<ViewModels.Crear.CrearVmHistorialMedico>
    {
        public void Configure(EntityTypeBuilder<CrearVmHistorialMedico> builder)
        {
            builder.ToTable("tblHistorialMedico").HasKey(e=>e.idHistorialMedico);
        }
    }
}
