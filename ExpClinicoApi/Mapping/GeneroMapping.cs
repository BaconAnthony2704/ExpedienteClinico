using ExpClinicoApi.Models.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class GeneroMapping : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<GlGenero>
    {
        public void Configure(EntityTypeBuilder<GlGenero> builder)
        {
            builder.ToTable("glgenero").HasKey(e => e.idGenero);
        }
    }
}
