using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class IncapacidadMapping : IEntityTypeConfiguration<clsIncapacidad>
    {
        public void Configure(EntityTypeBuilder<clsIncapacidad> builder)
        {
            builder.ToTable("tblincapacidad").HasKey(c => c.idTipoIncapacidad);
        }
    }
}
