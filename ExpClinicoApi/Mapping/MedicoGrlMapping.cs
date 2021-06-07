using ExpClinicoApi.Models.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class MedicoGrlMapping : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<GlMedicoGrl>
    {
        public void Configure(EntityTypeBuilder<GlMedicoGrl> builder)
        {
            builder.ToTable("glmedicogrl").HasKey(e => e.idMedicoGrl);
        }
    }
}
