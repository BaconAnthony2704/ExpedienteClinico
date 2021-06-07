using ExpClinicoApi.Models.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class TipoPielMapping : IEntityTypeConfiguration<GlTipoPiel>
    {
        public void Configure(EntityTypeBuilder<GlTipoPiel> builder)
        {
            builder.ToTable("gltipopiel").HasKey(e => e.idTipoPiel);
        }
    }
}
