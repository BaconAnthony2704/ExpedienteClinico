using ExpClinicoApi.Models.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class ColorCabelloMapping : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<GlColorCabello>
    {
        public void Configure(EntityTypeBuilder<GlColorCabello> builder)
        {
            builder.ToTable("glcolorcabello").HasKey(e => e.idColorCabello);
        }
    }
}
