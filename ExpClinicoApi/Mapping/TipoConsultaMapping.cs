using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class TipoConsultaMapping : IEntityTypeConfiguration<clsTipoConsulta>
    {
        public void Configure(EntityTypeBuilder<clsTipoConsulta> builder)
        {
            builder.ToTable("tbltipoconsulta").HasKey(e => e.idTipoConsulta);
        }
    }
}
