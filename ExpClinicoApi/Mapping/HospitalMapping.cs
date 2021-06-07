using ExpClinicoApi.Models.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class HospitalMapping : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<GlHospital>
    {
        public void Configure(EntityTypeBuilder<GlHospital> builder)
        {
            builder.ToTable("glhospital").HasKey(e => e.idHospital);
        }
    }
}
