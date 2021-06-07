using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class IncapacidadExpMapping : IEntityTypeConfiguration<pivoteIncapacidadExpediente>
    {
       

        public void Configure(EntityTypeBuilder<pivoteIncapacidadExpediente> builder)
        {
            builder.ToTable("tblincapacidad_expediente").HasKey(e => e.idIncapacidadExp);
        }
    }
}
