using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class CapacitacionMapping : IEntityTypeConfiguration<clsCapacitacion>
    {
        public void Configure(EntityTypeBuilder<clsCapacitacion> builder)
        {
            builder.ToTable("tblcapacitacion").HasKey(c=>c.idCapacitacion);
        }
    }
}
