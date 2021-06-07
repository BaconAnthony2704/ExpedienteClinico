using ExpClinicoApi.Models.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class ConSeguroMapping : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<GlComSeguro>
    {
        public void Configure(EntityTypeBuilder<GlComSeguro> builder)
        {
            builder.ToTable("glcomseguro").HasKey(e => e.idSeguro);
        }
    }
}
