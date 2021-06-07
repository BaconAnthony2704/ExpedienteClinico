using ExpClinicoApi.Models.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class EstadoCivilMapping : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<GlEstadoCivil>
    {
        public void Configure(EntityTypeBuilder<GlEstadoCivil> builder)
        {
            builder.ToTable("glestadocivil").HasKey(e => e.idEstadoCivil);
        }
    }
}
