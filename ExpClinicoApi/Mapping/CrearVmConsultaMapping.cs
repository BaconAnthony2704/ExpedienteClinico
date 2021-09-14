using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpClinicoApi.ViewModels.Crear;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpClinicoApi.Mapping
{
    public class CrearVmConsultaMapping : IEntityTypeConfiguration<CrearVmConsulta>
    {
        public void Configure(EntityTypeBuilder<CrearVmConsulta> builder)
        {
            builder.ToTable("tblconsulta").HasKey(c=>c.idConsulta);
        }
    }
}
